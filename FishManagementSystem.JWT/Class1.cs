using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FishManagementSystem.JWT
{
    public class Class1
    {

        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Expired { get; set; }
        public DateTime NotBefore => DateTime.UtcNow;
        public DateTime IssuedAt => DateTime.UtcNow;
        public DateTime Expiration => IssuedAt.AddMinutes(Expired);
        private SecurityKey SigningKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        public SigningCredentials SigningCredentials =>
            new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256);


    }
}
