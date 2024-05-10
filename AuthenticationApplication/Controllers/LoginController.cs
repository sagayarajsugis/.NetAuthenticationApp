using AuthenticationApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AuthenticationApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest loginRequest)
        {

            if(loginRequest != null)
            {
                if (loginRequest.userName == "Sagayaraj")
                {
                    //your logic for login process
                    //If login usrename and password are correct then proceed to generate token

                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                      _config["Jwt:Issuer"],
                      null,
                      expires: DateTime.Now.AddMinutes(120),
                      signingCredentials: credentials);

                    var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                    return Ok(token);

                }
                else return  BadRequest();
            }
            else return Ok("Please give the value");
           
        }

    }
}
