using Senparc.CO2NET;
using Senparc.CO2NET.RegisterServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yoyo.Abp
{
    /// <summary>
    /// 快捷注册类，YoYoSoft 实现的 IRegisterService
    /// </summary>
    public class YoyoAbpWechatRegisterService : IRegisterService
    {
        private YoyoAbpWechatRegisterService(SenparcSetting senparcSetting)
        {
            Config.SenparcSetting = (senparcSetting ?? new SenparcSetting());
        }

        /// <summary>
        /// 开始 Senparc.CO2NET SDK 初始化参数流程（.NET Core）
        /// </summary>
        /// <param name="senparcSetting"></param>
        /// <param name="contentRootPath">asp.net core应用中IHostingEnvironment对象的ContentRootPath</param>
        /// <returns></returns>
        public static IRegisterService Start(SenparcSetting senparcSetting, string contentRootPath = "")
        {
            if (!string.IsNullOrWhiteSpace(contentRootPath))
            {
                Config.RootDictionaryPath = contentRootPath;
            }
            var registerService = new YoyoAbpWechatRegisterService(senparcSetting);
            registerService.RegisterThreads();
            return registerService;
        }
    }
}
