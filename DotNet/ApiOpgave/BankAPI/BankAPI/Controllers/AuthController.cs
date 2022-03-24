using BankAPIDTO.DTO.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private string username = "Admin";
        private string password = "Admin";

        private IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public async Task<IActionResult> GetMethod(string username, string password)
        {
            //string token = null;
            //if (username == this.username && password == this.password)
            //{
            //    //generate token
            //    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            //    byte[] key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            //    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            //    {
            //        Subject = new ClaimsIdentity(new Claim[]{
            //            new Claim(ClaimTypes.NameIdentifier, username),
            //            new Claim(ClaimTypes.Email, $"{username}@Email.com")
            //        }),
            //        Expires = DateTime.Now.AddDays(1),
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            //    };

            //    SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            //    token = tokenHandler.WriteToken(securityToken);
            //}
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            string token = null;
            if(login.Username == this.username && login.Password == this.password)
            {
                //generate token
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]{
                        new Claim(ClaimTypes.NameIdentifier, username),
                        new Claim(ClaimTypes.Email, $"{username}@Email.com")
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
                token = tokenHandler.WriteToken(securityToken);
            }

            return Ok(token);
        }
    }
}
