namespace FishManagementSystem.Commons
{

    /// <summary>
    /// 统一返回对象
    /// </summary>
    public class ApiResult
    {

        public bool IsSuccess { get; set; }

        public string Error { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public dynamic? Data { get; set; }

    }
}
