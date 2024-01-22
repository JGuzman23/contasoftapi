using contasoft_api.Data;
using contasoft_api.DTOs;
using contasoft_api.DTOs.Inputs;
using contasoft_api.DTOs.Outputs;
using contasoft_api.Interfaces;
using contasoft_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contasoft_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        private readonly ContaSoftDbContext _context;
        private readonly IToken _token;
        public AuthController(IPasswordService passwordService, ContaSoftDbContext context, IToken token)
        {
            _passwordService = passwordService;
            _context = context;
            _token = token;
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginInput model)
        {
            var response = new DefaultResponse();
            LoginOutput lgO = new LoginOutput();
            var ValidateUser = await _context.User.Where(x => x.Email == model.Value || x.Username == model.Value || x.Cellphone == model.Value).FirstOrDefaultAsync();
            
            if(ValidateUser != null)
            {
                var isValid = _passwordService.Check(ValidateUser.Password,model.Key);
                if(isValid)
                {
                    lgO.Email = ValidateUser.Email;
                    lgO.ID = ValidateUser.Id;
                    lgO.FullName = ValidateUser.FullName;
                    lgO.Username = ValidateUser.Username;
                    await _token.GenerateToken(lgO);
                    response.Message = "Success";
                    response.StatusCode = 1;
                    response.Success = true;
                    response.Data = lgO;
                }
                else
                {
                    response.Message = "Usuario o contraseña incorrecta";
                    response.StatusCode = 01;
                    response.Success = false;
                }

            }
            else
            {
                response.Message = "Error, usuario no encontrado";
                response.StatusCode =01;
                response.Success = false;
                
            }

            return Ok(response);
        }
    }
}
