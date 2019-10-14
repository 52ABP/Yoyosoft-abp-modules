using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Yoyo.Abp
{

    /// <summary>
    /// 获取配置信息的帮助类
    /// </summary>
    public static  class ConfigHelper
    {
        private static readonly IConfiguration Configuration;

        static ConfigHelper()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .Build();
        }

        public static T GetSection<T>(string key) where T : class, new()
        {
            var obj = new ServiceCollection()
                .AddOptions()
                .Configure<T>(Configuration.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return obj;
        }

        public static string GetSection(string key)
        {
            return Configuration.GetValue<string>(key);
        }


    }
}
