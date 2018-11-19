
using System;
using System.Collections.Generic;
using System.Text;
using Senparc.CO2NET.RegisterServices;
using Senparc.CO2NET;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Senparc.Weixin.Entities;
using Senparc.CO2NET.Cache;
using Microsoft.AspNetCore.Builder;
using Senparc.Weixin.Cache.Redis;
using Senparc.Weixin;

namespace YoYo
{
    /// <summary>
    /// YoYo Soft 对 Senparc.Weixin、CO2NET、Redis 的扩展
    /// </summary>
    public static class YoYoSenparcWXExtensions
    {


        #region 写在 Startup.cs ConfigureServices 函数中


        /// <summary>
        /// 添加YoYo Senparc CO2NET和Weixin
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddYoYoSenparc(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection.AddYoYoSenparcCO2NET(configuration)
                                    .AddYoYoSenparcWeixin(configuration);
        }


        /// <summary>
        /// 添加YoYo Senparc CO2NET
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddYoYoSenparcCO2NET(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            SenparcDI.GlobalServiceCollection = serviceCollection;
            serviceCollection.Configure<SenparcSetting>(configuration.GetSection("SenparcSetting"));

            /*
             * appsettings.json 中添加节点：
 //CO2NET 设置
  "SenparcSetting": {
    "IsDebug": true,
    "DefaultCacheNamespace": "DefaultCache"
  },
             */

            return serviceCollection;
        }

        /// <summary>
        /// 添加YoYo Senparc Weixin
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddYoYoSenparcWeixin(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<SenparcWeixinSetting>(configuration.GetSection("SenparcWeixinSetting"));

            /*
             * appsettings.json 中添加节点：
  //Senparc.Weixin SDK 设置
    //Senparc.Weixin SDK 设置
  "SenparcWeixinSetting": {
    //微信全局
    "IsDebug": true,
    //公众号
    "Token": "weixin",
    "EncodingAESKey": "",
    "WeixinAppId": "WeixinAppId",
    "WeixinAppSecret": "WeixinAppSecret",
    //小程序
    "WxOpenAppId": "WxOpenAppId",
    "WxOpenAppSecret": "WxOpenAppSecret",
    //企业微信
    "WeixinCorpId": "WeixinCorpId",
    "WeixinCorpSecret": "WeixinCorpSecret",

    //微信支付
    //微信支付V2（旧版）
    "WeixinPay_PartnerId": "WeixinPay_PartnerId",
    "WeixinPay_Key": "WeixinPay_Key",
    "WeixinPay_AppId": "WeixinPay_AppId",
    "WeixinPay_AppKey": "WeixinPay_AppKey",
    "WeixinPay_TenpayNotify": "WeixinPay_TenpayNotify",
    //微信支付V3（新版）
    "TenPayV3_MchId": "TenPayV3_MchId",
    "TenPayV3_Key": "TenPayV3_Key",
    "TenPayV3_AppId": "TenPayV3_AppId",
    "TenPayV3_AppSecret": "TenPayV3_AppId",
    "TenPayV3_TenpayNotify": "TenPayV3_TenpayNotify",

    //开放平台
    "Component_Appid": "Component_Appid",
    "Component_Secret": "Component_Secret",
    "Component_Token": "Component_Token",
    "Component_EncodingAESKey": "Component_EncodingAESKey",

    //分布式缓存
    //"Cache_Redis_Configuration": "localhost:6379", 
    "Cache_Memcached_Configuration": "Memcached配置"
  }
  */

            return serviceCollection;
        }


        #endregion



        #region 写在  Startup.cs Configure 函数中

        /// <summary>
        /// 开始YoYo Senparc.CO2NET SDK 初始化参数流程
        /// 
        /// (关于 UseYoYoSenparc() 的更多用法见 CO2NET Demo 中的 UseSenparcGlobal：https://github.com/Senparc/Senparc.CO2NET/blob/master/Sample/Senparc.CO2NET.Sample.netcore/Startup.cs)
        /// </summary>
        /// <param name="senparcSetting"></param>
        /// <param name="contentRootPath">提供网站根目录(env.ContentRootPath,env类型为IHostingEnvironment)</param>
        /// <param name="autoScanExtensionCacheStrategies">是否自动扫描全局的扩展缓存(会增加系统启动时间)</param>
        /// <param name="extensionCacheStrategiesFunc">
        /// <para>需要手动注册的扩展缓存策略</para>
        /// <para>（LocalContainerCacheStrategy、RedisContainerCacheStrategy、MemcacheContainerCacheStrategy已经自动注册），</para>
        /// <para>如果设置为 null（注意：不是委托返回 null，是整个委托参数为 null），则自动使用反射扫描所有可能存在的扩展缓存策略</para>
        /// </param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcCO2NET(
            this SenparcSetting senparcSetting,
            string contentRootPath = "",
            bool autoScanExtensionCacheStrategies = false,
            Func<IList<IDomainExtensionCacheStrategy>> extensionCacheStrategiesFunc = null)
        {
            var registerService = YoYoSenparcRegisterService.Start(senparcSetting, contentRootPath);

            CacheStrategyDomainWarehouse.AutoScanDomainCacheStrategy(autoScanExtensionCacheStrategies, extensionCacheStrategiesFunc);

            return registerService;
        }








        /// <summary>
        /// YoYo Senparc CO2NET 全局缓存配置（按需）
        /// </summary>
        /// <param name="registerService"></param>
        /// <param name="applicationBuilder"></param>
        /// <param name="senparcSetting"></param>
        /// <param name="customCacheNamespace">当同一个分布式缓存同时服务于多个网站（应用程序池）时，可以使用命名空间将其隔离（非必须）</param>
        /// <param name="configRedisAction">配置全局使用Redis缓存（按需，独立）,此函数返回结果为true将启用redis</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcCO2NETGlobalCache(
            this IRegisterService registerService,
            IApplicationBuilder applicationBuilder,
            SenparcSetting senparcSetting,
            string customCacheNamespace = null,
            Func<SenparcSetting, bool> configRedisAction = null)
        {
            // 全局缓存配置（按需）
            if (!string.IsNullOrWhiteSpace(customCacheNamespace))
            {
                // 当同一个分布式缓存同时服务于多个网站（应用程序池）时，可以使用命名空间将其隔离（非必须）
                registerService.ChangeDefaultCacheNamespace(customCacheNamespace);
            }


            // 配置全局使用Redis缓存
            if (configRedisAction == null)
            {
                return registerService;
            }

            // 回调函数,返回true表示使用redis
            if (configRedisAction(senparcSetting))
            {
                applicationBuilder.UseSenparcWeixinCacheRedis();
            }

            return registerService;
        }


        /// <summary>
        /// YoYo Senparc CO2NET 跟踪日志
        /// </summary>
        /// <param name="registerService"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcCO2NETTraceLog(this IRegisterService registerService, Action action)
        {
            action();
            return registerService;
        }


        /// <summary>
        /// 开始 Senparc.Weixin SDK 初始化参数流程
        /// </summary>
        /// <param name="registerService"></param>
        /// <param name="senparcWeixinSetting">微信全局设置参数，必填</param>
        /// <param name="senparcSetting">用于提供 SenparcSetting.Cache_Redis_Configuration 和 Cache_Memcached_Configuration 两个参数，如果不使用这两种分布式缓存可传入null</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcWeixin(
            this IRegisterService registerService,
            SenparcWeixinSetting senparcWeixinSetting,
            SenparcSetting senparcSetting = null)
        {
            return registerService.UseSenparcWeixin(senparcWeixinSetting, senparcSetting);
        }

        #endregion


    }
}