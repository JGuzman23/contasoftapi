using contasoft_api.Data;
using contasoft_api.DTOs;
using contasoft_api.DTOs.Inputs;
using contasoft_api.DTOs.Outputs;
using contasoft_api.Models;
using DocumentFormat.OpenXml.Office.CoverPageProps;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contasoft_api.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ContaSoftDbContext _contaSoftDbContext;
        public CompanyController(ContaSoftDbContext contaSoftDbContext)
        {
            _contaSoftDbContext = contaSoftDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int userID)
        {
            var response = new DefaultResponse();
            if (userID == 0 && userID == null)
            {
                return BadRequest();
            }

            List<CompanyOutput> ReturnCompany = new List<CompanyOutput>();

            var company = await _contaSoftDbContext.UserCompany
                .Where(x => x.UserId == userID)
                .Include(x => x.Company)
                .Where(company => company.Company.IsActive)
                .ToListAsync();

            foreach (var item in company)
            {
                CompanyOutput companyOutput = new CompanyOutput()
                {
                    Name = item.Company.Name,
                    RNC = item.Company.RNC,
                    Id = item.Company.Id,

                };
                ReturnCompany.Add(companyOutput);
            }
            response.Message = "Success";
            response.StatusCode = 1;
            response.Success = true;
            response.Data = ReturnCompany;

            return Ok(response);

        }
        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetOneAsync(int companyId)
        {
            var response = new DefaultResponse();



            var company = await _contaSoftDbContext.Company
                .Where(x => x.Id == companyId)
                .FirstOrDefaultAsync();


            CompanyOutput companyOutput = new CompanyOutput()
            {
                Name = company.Name,
                RNC = company.RNC,
                Id = company.Id,
                Telefono = company.Telefono,
                Address = company.Address,
                Photo = company.Photo,
                IsActive = company.IsActive,
            };


            response.Message = "Success";
            response.StatusCode = 1;
            response.Success = true;
            response.Data = companyOutput;

            return Ok(response);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyInput model)
        {
            var response = new DefaultResponse();
            List<CompanyOutput> ReturnCompany = new List<CompanyOutput>();
            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                Company newCompany = new Company()
                {
                    Name = model.Name,
                    RNC = model.RNC,
                    Address = model.Address,
                    Telefono = model.Telefono,
                    Photo = model.Photo,
                    CreateDate = DateTime.Now,
                    UserCode = "root",
                    IsActive = true
                };


                await _contaSoftDbContext.Company.AddAsync(newCompany);
                await _contaSoftDbContext.SaveChangesAsync();
                UserCompany userCompany = new UserCompany()
                {
                    UserId = model.UserId,
                    CompanyId = newCompany.Id,
                    CreateDate = DateTime.Now,
                    UserCode = "root",
                    IsActive = true
                };
                await _contaSoftDbContext.UserCompany.AddAsync(userCompany);
                await _contaSoftDbContext.SaveChangesAsync();

                response.Message = "Creada correctamente";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = $"Error al crear: {ex.Message}";
                response.StatusCode = 0;
                response.Success = false;

            }

            var company = await _contaSoftDbContext.UserCompany
                .Where(x => x.UserId == model.UserId)
                .Include(x => x.Company)
                .ToListAsync();

            foreach (var item in company)
            {
                CompanyOutput companyOutput = new CompanyOutput()
                {
                    Name = item.Company.Name,
                    RNC = item.Company.RNC,
                    Id = item.Company.Id,

                };
                ReturnCompany.Add(companyOutput);
            }
            response.Data = ReturnCompany;

            return Ok(response);


        }

        [HttpPut]
        public async Task<IActionResult> Update(CreateCompanyInput model)
        {
            var response = new DefaultResponse();

            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                var company = await _contaSoftDbContext.Company.FirstOrDefaultAsync(x => x.Id == model.Id);

                company.Name = model.Name;
                company.RNC = model.RNC;
                company.Address = model.Address;
                company.Telefono = model.Telefono;
                company.Photo = model.Photo;
                company.IsActive = model.IsActive;

                _contaSoftDbContext.Company.Update(company);
                await _contaSoftDbContext.SaveChangesAsync();


                response.Message = "Actualizado correctamente";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = $"Error al actualizar: {ex.Message}";
                response.StatusCode = 0;
                response.Success = false;

            }



            return Ok(response);


        }
    }
}
