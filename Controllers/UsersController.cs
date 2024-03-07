using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using contasoft_api.Data;
using contasoft_api.Models;
using contasoft_api.DTOs.Inputs;
using contasoft_api.Interfaces;
using contasoft_api.DTOs;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace contasoft_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ContaSoftDbContext _context;
        private readonly IPasswordService _passwordService;

        public UsersController(ContaSoftDbContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUserMyUser(int userId, int companyId)
        {
            var response = new DefaultResponse();
            var users = new List<User>();
            if (_context.User == null)
            {
                return NotFound();
            }

            var UserCompany = await _context.UserCompany
                .Where(x => x.CompanyId == companyId)
                .Where(user => user.UserId != userId)
                .Include(x => x.User)
              
                .ToListAsync();



            response.StatusCode = 1;
            response.Success = true;
            response.Data = UserCompany;

            return Ok(response);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var response = new DefaultResponse();

            if (_context.User == null)
            {
                return NotFound();
            }
            var user = await _context.User
                
                .Where(user=>user.Id==id).FirstOrDefaultAsync();

            if (user == null)
            {
                response.Message = "Usuario no encontrado!";
                response.StatusCode = 0;
                response.Success = false;
                return Ok(response);
            }

            response.StatusCode = 1;
            response.Success = true;
            response.Data = user;

            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserInput model)
        {
            var response = new DefaultResponse();
            if (_context.User == null)
            {
                return Problem("Entity set 'ContaSoftDbContext.User'  is null.");
            }


            User newUser = new User()
            {
                FullName = model.FullName,
                Email = model.Email,
                Cellphone = model.Cellphone,
                Username = model.Username,
                RolId = model.RoleId,
                PlanId = model.PlanId,
                CreateDate = DateTime.Now,
                UserCode = "Root",
                IsActive = true

            };
            newUser.Password = _passwordService.Hash(model.Password);

            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            response.Message = "Usuario creado con éxito!";
            response.StatusCode = 1;
            response.Success = true;


            return Ok(response);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
