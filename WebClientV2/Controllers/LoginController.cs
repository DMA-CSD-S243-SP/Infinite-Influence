using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebClientV2.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("Login/Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginModel)
        {
            var jsonData = JsonConvert.SerializeObject(loginModel);

            var content = new StringContent(
                jsonData,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response =
                new APIClient().PostAsync("Login/Login", content).Result;

            string? TokenString = null;

            if (response.IsSuccessStatusCode)
            {
                TokenString = (string?)JObject.Parse(response.Content.ReadAsStringAsync().Result)["token"];
            }

            

            if (TokenString != null)
            {
                JwtSecurityToken Jst = new(TokenString);

                List<Claim> theApiClaims = (List<Claim>)Jst.Claims.ToList();
                theApiClaims.Add(new Claim("token", TokenString));

                var claimsIdentity = new ClaimsIdentity(theApiClaims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
