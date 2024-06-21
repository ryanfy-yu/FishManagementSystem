using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FishManagementSystem.JWT
{
    public class JwtToken
    {
        // private readonly IConfiguration _configuration;


        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expired;

        public JwtToken(IConfiguration configuration)
        {
            //_configuration = configuration;

            var jwtConfig = configuration.GetSection("JwtConfig");
            _secretKey = jwtConfig.GetValue<string>("SecretKey");
            _issuer = jwtConfig.GetValue<string>("Issuer");
            _audience = jwtConfig.GetValue<string>("Audience");
            _expired = jwtConfig.GetValue<int>("Expired");
        }

        public string CreateToken(string username, string[] rolename)
        {
            // 1. 定义需要使用到的Claims

            var claims = new[]
            {
      new Claim(JwtRegisteredClaimNames.Iss,_issuer),
                new Claim(JwtRegisteredClaimNames.Aud,_audience),
                new Claim("Guid",Guid.NewGuid().ToString("D")),
                //new Claim(ClaimTypes.Role,"system"),
                //new Claim(ClaimTypes.Role,"admin"),
        };

            // 2. 从 appsettings.json 中读取SecretKey
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

            // 3. 选择加密算法
            var algorithm = SecurityAlgorithms.HmacSha256;

            // 4. 生成Credentials
            var signingCredentials = new SigningCredentials(secretKey, algorithm);



            // 5. 根据以上，生成token
            var jwtSecurityToken = new JwtSecurityToken(
                _issuer,     //Issuer
                _audience,   //Audience
                claims,                          //Claims,
                DateTime.Now,                    //notBefore
                DateTime.Now.AddMinutes(_expired),    //expires
                signingCredentials               //Credentials
            );

            // 6. 将token变为string
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
