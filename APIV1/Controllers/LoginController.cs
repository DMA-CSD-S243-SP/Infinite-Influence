using DataAccessLibrary;
using DataAccessLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static DataAccessLibrary.Interfaces.ILoginDao;

namespace APIV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[controller]")]
        public IActionResult APILogin([FromBody] LoginDTO model)
        {
            try
            {
                ILoginDao loginDao = DefaultValues.DefaultLoginDao;
                ILoginDao.User foundUser = loginDao.AttemptLogin(model.Username, model.Password);

                Claim[] authClaims = new[]
                {
                    new Claim(ClaimTypes.UserData, foundUser.id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Typ, foundUser.username),
                    new Claim(ClaimTypes.Role, foundUser.role.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                string key = _configuration.GetValue<string>("SecurityKey"); // Grabs security key from appsettings
                SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)); // Converts alphanummeric format into bytes

                var token = new JwtSecurityToken(
                issuer: "https://infiniteinfluence.gov",
                audience: "https://infiniteinfluence.gov",
                expires: DateTime.Now.AddDays(5),
                claims: authClaims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            catch (InvalidLoginException iex)
            {
                return StatusCode(403, "Bad Username/Password");
            }
        }
    }
}
