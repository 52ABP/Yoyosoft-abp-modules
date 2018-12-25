using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP;
using System;
using System.Collections.Generic;
using System.Text;

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
        /// <param name="registerService">RegisterService</param>
        /// <param name="appId">微信公众号后台的【开发】>【基本配置】中的“AppID(应用ID)”</param>
        /// <param name="appSecret">微信公众号后台的【开发】>【基本配置】中的“AppSecret(应用密钥)”</param>
        /// <param name="name">标记AccessToken名称（如微信公众号名称），帮助管理员识别</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcMpAccount(this IRegisterService registerService, string appId, string appSecret, string name)
        {
            return registerService.RegisterMpAccount(appId, appSecret, name);
        }

        /// <summary>
        /// 根据 SenparcWeixinSetting 自动注册公众号信息（包括JsApi）
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="weixinSettingForMP">SenparcWeixinSetting</param>
        /// <param name="name">统一标识，如果为null，则使用 weixinSettingForMP.ItemKey </param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcMpAccount(this IRegisterService registerService, ISenparcWeixinSettingForMP weixinSettingForMP, string name = null)
        {
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
