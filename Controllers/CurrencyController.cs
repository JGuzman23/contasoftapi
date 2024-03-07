using contasoft_api.DTOs.Outputs;
using contasoft_api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using contasoft_api.Data;
using Microsoft.AspNetCore.Authorization;
using contasoft_api.Models;
using Microsoft.EntityFrameworkCore;

namespace contasoft_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ContaSoftDbContext _context;

        public CurrencyController(ContaSoftDbContext context)
        {
            _context = context;
        }

     
        [HttpGet]
        public async Task<IActionResult> GetBank()
        {
            List<Currency> ListadeMoneda = new List<Currency>();
            var response = new DefaultResponse();
            if (_context.Currency == null)
            {
                return NotFound();
            }

            ListadeMoneda = await _context.Currency.ToListAsync();


            response.Message = "Success";
            response.StatusCode = 1;
            response.Success = true;
            response.Data = ListadeMoneda;

            return Ok(response);
        }
    }
}
