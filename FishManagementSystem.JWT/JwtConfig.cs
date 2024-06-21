using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FishManagementSystem.JWT
{
    public class JwtConfig
    {
        /// <summary>
        /// 密钥
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// 发布者
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 接受者
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 过期时间（min）
        /// </summary>
        public int Expired { get; set; }
    }

}
