using Senparc.Weixin.Open.ComponentAPIs;
using Senparc.Weixin.Open.Containers;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin.Open;
using System;

namespace YoYo
{
    /// <summary>
    /// YoYo Soft 对 Senparc.Weixin.Open 的扩展
    /// </summary>
    public static class YoYoSenparcWXOpenExtensions
    {

        /// <summary>
        /// 注册第三方平台信息
        /// </summary>
        /// <param name="registerService"></param>
        /// <param name="componentAppId"></param>
        /// <param name="componentAppSecret"></param>
        /// <param name="getComponentVerifyTicketFunc">获取ComponentVerifyTicket的方法</param>
        /// <param name="getAuthorizerRefreshTokenFunc">从数据库中获取已存的AuthorizerAccessToken的方法</param>
        /// <param name="authorizerTokenRefreshedFunc">AuthorizerAccessToken更新后的回调</param>
        /// <param name="name">标记名称（如开放平台名称），帮助管理员识别</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcOpenComponent(this IRegisterService registerService,
            string componentAppId, string componentAppSecret,
            Func<string, string> getComponentVerifyTicketFunc,
            Func<string, string, string> getAuthorizerRefreshTokenFunc,
            Action<string, string, RefreshAuthorizerTokenResult> authorizerTokenRefreshedFunc,
            string name = null)
        {
            return registerService.RegisterOpenComponent(
                componentAppId,
                componentAppSecret,
                getComponentVerifyTicketFunc,
                getAuthorizerRefreshTokenFunc,
                authorizerTokenRefreshedFunc,
                name);
        }


        /// <summary>
        /// 根据 SenparcWeixinSetting 自动注册第三方平台信息
        /// </summary>
        /// <param name="registerService"></param>
        /// <param name="weixinSettingForOpen">SenparcWeixinSetting</param>
        /// <param name="getComponentVerifyTicketFunc"></param>
        /// <param name="getAuthorizerRefreshTokenFunc"></param>
        /// <param name="authorizerTokenRefreshedFunc"></param>
        /// <param name="name">统一标识，如果为null，则使用 SenparcWeixinSetting.ItemKey</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcOpenComponent(this IRegisterService registerService,
            Senparc.Weixin.Entities.ISenparcWeixinSettingForOpen weixinSettingForOpen,
            Func<string, string> getComponentVerifyTicketFunc,
            Func<string, string, string> getAuthorizerRefreshTokenFunc,
            Action<string, string, RefreshAuthorizerTokenResult> authorizerTokenRefreshedFunc,
            string name = null)
        {
            return registerService.RegisterOpenComponent(
                weixinSettingForOpen,
                getComponentVerifyTicketFunc,
                getAuthorizerRefreshTokenFunc,
                authorizerTokenRefreshedFunc,
                name
                );
        }
    }
}
