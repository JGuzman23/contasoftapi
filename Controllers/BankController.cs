using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using contasoft_api.Data;
using contasoft_api.Models;
using contasoft_api.DTOs;
using contasoft_api.DTOs.Outputs;
using System.ComponentModel.Design;
using contasoft_api.DTOs.Inputs;
using Microsoft.AspNetCore.Authorization;

namespace contasoft_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly ContaSoftDbContext _context;

        public BankController(ContaSoftDbContext context)
        {
            _context = context;
        }

        // GET: api/Bank

        [HttpGet]
        public async Task<IActionResult> GetBank()
        {
            List<BankOutput> ListaBancos = new List<BankOutput>();
            var response = new DefaultResponse();
            if (_context.Bank == null)
            {
                return NotFound();
            }

            var banks = await _context
              .Bank.ToListAsync();

            if (banks == null)
            {
                return NotFound();
            }

            banks.ForEach(bank =>
            {
                BankOutput output = new BankOutput();

                output.Name = bank.Name;
                output.Id = bank.Id;
                ListaBancos.Add(output);
            });


            response.Message = "Success";
            response.StatusCode = 1;
            response.Success = true;
            response.Data = ListaBancos;

            return Ok(response);
        }

        // GET: api/Bank/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Bank>> GetBank(int id)
        //{
        //  if (_context.Bank == null)
        //  {
        //      return NotFound();
        //  }
        //    var bank = await _context.Bank.FindAsync(id);

        //    if (bank == null)
        //    {
        //        return NotFound();
        //    }

        //    return bank;
        //}

        [HttpGet("{companyID}")]
        public async Task<IActionResult> GetBankByCompany(int companyID)
        {
            List<BankOutput> ListaBancos = new List<BankOutput>();
            var response = new DefaultResponse();
            if (_context.Bank == null)
            {
                return NotFound();
            }
            var bankSelectedList = await _context
                .BankSelected.Where(bs => bs.CompanyId == companyID)
                .Include(i => i.Bank).ToListAsync();

            if (bankSelectedList == null)
            {
                return NotFound();
            }

            bankSelectedList.ForEach(bs =>
            {
                BankOutput output = new BankOutput();

                output.AccountNumber = bs.AccountNumber;
                output.Name = bs.Bank.Name;
                output.Id = bs.Bank.Id;
                output.BankSelectedID = bs.Id;
                ListaBancos.Add(output);
            });



            response.Message = "Success";
            response.StatusCode = 1;
            response.Success = true;
            response.Data = ListaBancos;

            return Ok(response);
        }

        // PUT: api/Bank/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBank(int id, BankInput bank)
        {
            var response = new DefaultResponse();


            if (id != bank.BankSelectedID)
            {
                return BadRequest();
            }

            try
            {
                var bancoSelected = await _context.BankSelected.Where(b => b.Id == id).FirstOrDefaultAsync();

                if (bancoSelected != null)
                {
                    bancoSelected.AccountNumber = bank.AccountNumber;
                    bancoSelected.UpdateDate = DateTime.Now;
                    bancoSelected.UserCode = "root";
           
                // _context.Entry(bankSelected).State = EntityState.Modified;
                    _context.BankSelected.Update(bancoSelected);
                    await _context.SaveChangesAsync();


                    response.Message = "Banco Actualizado con éxito. ";
                    response.StatusCode = 1;
                    response.Success = true;
                }
                else
                {
                    response.Message = "Banco No Encontrado. ";
                    response.StatusCode = 0;
                    response.Success = false;

                }




                return Ok(response);
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.StatusCode = 0;
                response.Success = false;
                return BadRequest(response);

            }


        }

        // POST: api/Bank
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostBank(BankInput bank)
        {
            var response = new DefaultResponse();
            if (_context.Bank == null)
            {
                return Problem("Entity set 'ContaSoftDbContext.Bank'  is null.");
            }

            BankSelected bankSelected = new BankSelected()
            {
                BankId = bank.BankSelectedID,
                AccountNumber = bank.AccountNumber,
                CompanyId = bank.CompanyId,
                CreateDate = DateTime.Now,
                UserCode = "root",
                IsActive = true


            };

            _context.BankSelected.Add(bankSelected);
            await _context.SaveChangesAsync();

            response.Message = "Creado con Éxito.";
            response.StatusCode = 1;
            response.Success = true;


            return Ok(response);
        }

        // DELETE: api/Bank/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank(int id)
        {
            var response = new DefaultResponse();

            if (_context.BankSelected == null)
            {
                return NotFound();
            }
            var bankSelected = await _context.BankSelected.FindAsync(id);
            if (bankSelected == null)
            {
                return NotFound();
            }
            try
            {

                _context.BankSelected.Remove(bankSelected);
                await _context.SaveChangesAsync();


                response.Message = "Banco eliminado con éxito. ";
                response.StatusCode = 1;
                response.Success = true;
                return Ok(response);
            }
            catch (Exception)
            {

                response.Message = "Error al eliminar ";
                response.StatusCode = 0;
                response.Success = false;
                return BadRequest(response);
            }


        }

        private bool BankExists(int id)
        {
            return (_context.BankSelected?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
