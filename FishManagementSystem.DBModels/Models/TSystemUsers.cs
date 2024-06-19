using FishManagementSystem.DBModels.Utils;

namespace FishManagementSystem.DBModels.Models
{

    /// <summary>
    /// 系统用户
    /// </summary>
    public class TSystemUsers : ModelBase
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public int? UserType { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }


        public int? Status { get; set; }


    }
}
