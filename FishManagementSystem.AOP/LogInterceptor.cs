using Castle.DynamicProxy;
using System.Numerics;
using Microsoft.Extensions.Logging;

namespace FishManagementSystem.AOP
{
    public class LogInterceptor : IInterceptor
    {

        private readonly ILogger<LogInterceptor> _logger;


        public LogInterceptor(ILogger<LogInterceptor> logger)
        {

            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                _logger.LogInformation($"-----------------Start:{invocation.Method}-----------------");

                invocation.Proceed();

                _logger.LogInformation($"-----------------End:{invocation.Method}-----------------");

            }
            catch (Exception ex)
            {
                _logger.LogError($"-----------------Exception:{ex.ToString()}-----------------");
            }


        }
    }
}
