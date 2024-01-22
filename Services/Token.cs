using contasoft_api.DTOs.Outputs;
using contasoft_api.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace contasoft_api.Services
{
    public class Token: IToken
    {
        readonly IConfiguration _configuration;
        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task GenerateToken(LoginOutput dto)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("id", dto.ID.ToString()),
                new Claim("username", dto.Username.ToString()),
                new Claim("email", dto.Email.ToString()),
                new Claim("fullname", dto.FullName.ToString()),

            };

            var Sectoken = new JwtSecurityToken(_configuration["Authentication:Issuer"],
              _configuration["Authentication:Issuer"],claims,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

              dto.Token = new JwtSecurityTokenHandler().WriteToken(Sectoken);




            //var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            //var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            //var header = new JwtHeader(signingCredentials);

           

            //foreach (var campues in dto.Campuses)
            //{
            //    claims.Add(new Claim("campuses", campues.Code));
            //}
            //foreach (var access in dto?.Accesses)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, access.Name));

            //}
            //var payload = new JwtPayload
            //(
            //    _configuration["Authentication:Issuer"],
            //    _configuration["Authentication:Issuer"],
            //    claims,
            //    DateTime.Now,
            //    DateTime.UtcNow.AddDays(5)

            //);

            //var token = new JwtSecurityToken(header, payload);
            //dto.Token = await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
