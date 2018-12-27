using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP;
using System;
using System.Collections.Generic;
using System.Text;
using YoYo.Containers;

namespace YoYo
{
    /// <summary>
    /// YoYo Soft 对 Senparc.Weixin.MP 的扩展
    /// </summary>
    public static class YoYoSenparcWXMPExtensions
    {
        /// <summary>
        /// 注册公众号（或小程序）信息
        /// </summary>
        /// <typeparam name="UserKeyType">用户唯一Id类型</typeparam>
        /// <typeparam name="TenantKeyType">租户唯一Id类型</typeparam>
        /// <param name="registerService">RegisterService</param>
        /// <param name="appId">微信公众号后台的【开发】>【基本配置】中的“AppID(应用ID)”</param>
        /// <param name="appSecret">微信公众号后台的【开发】>【基本配置】中的“AppSecret(应用密钥)”</param>
        /// <param name="name">标记AccessToken名称（如微信公众号名称），帮助管理员识别</param>
        /// <param name="token">token</param>
        /// <param name="encodingAESKey">encodingAESKey</param>
        /// <param name="key">获取公众号信息Key</param>
        /// <param name="userId">用户Id</param>
        /// <param name="tenantId">租户Id</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcMpAccount<UserKeyType,TenantKeyType>(this IRegisterService registerService, string appId, string appSecret, string name, string token, string encodingAESKey, string key, UserKeyType userId = default(UserKeyType), TenantKeyType tenantId = default(TenantKeyType))
        {
            MpInfoContainer<UserKeyType, TenantKeyType>.Register(key, appId, appSecret, token, encodingAESKey, name, default(UserKeyType), default(TenantKeyType));
            return registerService.RegisterMpAccount(appId, appSecret, name);
        }

        /// <summary>
        /// 注册公众号（或小程序）信息
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="appId">微信公众号后台的【开发】>【基本配置】中的“AppID(应用ID)”</param>
        /// <param name="appSecret">微信公众号后台的【开发】>【基本配置】中的“AppSecret(应用密钥)”</param>
        /// <param name="name">标记AccessToken名称（如微信公众号名称），帮助管理员识别</param>
        /// <param name="token">token</param>
        /// <param name="encodingAESKey">encodingAESKey</param>
        /// <param name="key">获取公众号信息Key</param>
        /// <param name="userId">用户Id</param>
        /// <param name="tenantId">租户Id</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcMpAccount(this IRegisterService registerService, string appId, string appSecret, string name, string token, string encodingAESKey, string key, long userId = default(long), long tenantId = default(long))
        {
            MpInfoContainer.Register(appId,appSecret,name,token,encodingAESKey,key, userId, tenantId);
            return registerService.RegisterMpAccount(appId, appSecret, name);
        }

        /// <summary>
        /// 根据 SenparcWeixinSetting 自动注册公众号信息（包括JsApi）
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="weixinSettingForMP">SenparcWeixinSetting</param>
        /// <param name="token">token</param>
        /// <param name="encodingAESKey">encodingAESKey</param>
        /// <param name="key">获取公众号信息Key</param>
        /// <param name="name">统一标识，如果为null，则使用 weixinSettingForMP.ItemKey </param>
        /// <param name="userId">用户Id</param>
        /// <param name="tenantId">租户Id</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcMpAccount<UserKeyType, TenantKeyType>(this IRegisterService registerService, ISenparcWeixinSettingForMP weixinSettingForMP, string token, string encodingAESKey, string key, string name = null, UserKeyType userId = default(UserKeyType), TenantKeyType tenantId = default(TenantKeyType))
        {
            MpInfoContainer.Register(key, weixinSettingForMP.WeixinAppId, weixinSettingForMP.WeixinAppSecret, token, encodingAESKey, name, default(long), default(long));
            return registerService.RegisterMpAccount(weixinSettingForMP, name);
        }
        /// <summary>
        /// 根据 SenparcWeixinSetting 自动注册公众号信息（包括JsApi）
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="weixinSettingForMP">SenparcWeixinSetting</param>
        /// <param name="token">token</param>
        /// <param name="encodingAESKey">encodingAESKey</param>
        /// <param name="key">获取公众号信息Key</param>
        /// <param name="name">统一标识，如果为null，则使用 weixinSettingForMP.ItemKey </param>
        /// <param name="userId">用户Id</param>
        /// <param name="tenantId">租户Id</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcMpAccount(this IRegisterService registerService, ISenparcWeixinSettingForMP weixinSettingForMP, string token, string encodingAESKey, string key, string name = null, long userId = default(long), long tenantId = default(long))
        {
            MpInfoContainer.Register(key, weixinSettingForMP.WeixinAppId, weixinSettingForMP.WeixinAppSecret, token, encodingAESKey, name, userId, tenantId);
            return registerService.RegisterMpAccount(weixinSettingForMP, name);
        }

        /// <summary>
        /// 注册公众号（或小程序）的JSApi（RegisterMpAccount注册过程中已包含）
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="appId">微信公众号后台的【开发】>【基本配置】中的“AppID(应用ID)”</param>
        /// <param name="appSecret">微信公众号后台的【开发】>【基本配置】中的“AppSecret(应用密钥)”</param>
        /// <param name="name">标记AccessToken名称（如微信公众号名称），帮助管理员识别</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcMpJsApiTicket(this IRegisterService registerService, string appId, string appSecret, string name)
        {
            return registerService.RegisterMpJsApiTicket(appId, appSecret, name);
        }
    }
}
