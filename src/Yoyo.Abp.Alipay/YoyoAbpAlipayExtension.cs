using System;
using Alipay.AopSdk.AspnetCore;
using Microsoft.Extensions.DependencyInjection;
using Yoyo.Abp.FTF;

namespace Yoyo.Abp
{
    public static class YoYoAlipayExtension
    {
        /// <summary>
        /// 添加 YoYo Alipay 全局配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="alipayOptionsCreateFunc">支付配置信息创建函数</param>
        /// <param name="ftfConfigCreateAction">面对面支付基本信息创建函数</param>
        /// <returns></returns>
        public static IServiceCollection AddYoYoAlipay(this IServiceCollection services,
            Func<AlipayOptions> alipayOptionsCreateFunc,
            Action<FTFConfig> ftfConfigCreateAction)
        {
            return services.AddAlipay(options =>
                {
                    options.SetOption(alipayOptionsCreateFunc.Invoke());
                })
                .Configure(ftfConfigCreateAction);
        }
    }
}