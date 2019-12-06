using Senparc.Weixin.MP.Containers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yoyo.Abp.Containers;

namespace Yoyo.Abp
{
    /// <summary>
    /// 公众号操作
    /// </summary>
    public class YoyoAbpWechatMP
    {
        /// <summary>
        /// 注册公众号
        /// </summary>
        /// <typeparam name="UserKeyType">用户唯一Id类型</typeparam>
        /// <typeparam name="TenantKeyType">租户唯一Id类型</typeparam>
        /// <param name="key">获取公众号信息Key</param>
        /// <param name="appId">公众号AppId</param>
        /// <param name="appSecret">公众号AppSecret</param>
        /// <param name="token">公众号Token</param>
        /// <param name="encodingAESKey">公众号EncodingAESKey</param>
        /// <param name="name">公众号名称</param>
        /// <param name="userId">用户Id</param>
        /// <param name="tenantId">租户Id</param>
        public static async Task RegisterMpAccount<UserKeyType, TenantKeyType>(string key, string appId, string appSecret, string token, string encodingAESKey, string name = null, UserKeyType userId = default(UserKeyType), TenantKeyType tenantId = default(TenantKeyType))
        {
            MpInfoContainer<UserKeyType, TenantKeyType>.Register(key, appId, appSecret, token, encodingAESKey, name, userId, tenantId);
            await AccessTokenContainer.RegisterAsync(appId, appSecret, name);
            await JsApiTicketContainer.RegisterAsync(appId, appSecret, name);
            await WxCardApiTicketContainer.RegisterAsync(appId, appSecret, name);
        }

        /// <summary>
        /// 注册公众号
        /// </summary>
        /// <param name="key">获取公众号信息Key</param>
        /// <param name="appId">公众号AppId</param>
        /// <param name="appSecret">公众号AppSecret</param>
        /// <param name="token">公众号Token</param>
        /// <param name="encodingAESKey">公众号EncodingAESKey</param>
        /// <param name="name">公众号名称</param>
        /// <param name="userId">用户Id</param>
        /// <param name="tenantId">租户Id</param>
        public static void RegisterMpAccount(string key, string appId, string appSecret, string token, string encodingAESKey, string name = null, long userId = default(long), long tenantId = default(long))
        {
            var task = RegisterMpAccountAsync(key, appId, appSecret, token, encodingAESKey, name, userId, tenantId);
            Task.WaitAll(new[] { task }, 10000);
        }
        /// <summary>
        /// 注册公众号
        /// </summary>
        /// <param name="key">获取公众号信息Key</param>
        /// <param name="appId">公众号AppId</param>
        /// <param name="appSecret">公众号AppSecret</param>
        /// <param name="token">公众号Token</param>
        /// <param name="encodingAESKey">公众号EncodingAESKey</param>
        /// <param name="name">公众号名称</param>
        /// <param name="userId">用户Id</param>
        /// <param name="tenantId">租户Id</param>
        public static async Task RegisterMpAccountAsync(string key, string appId, string appSecret, string token, string encodingAESKey, string name = null, long userId = default(long), long tenantId = default(long))
        {
            await RegisterMpAccount<long, long>(key, appId, appSecret, token, encodingAESKey, name, userId, tenantId);
        }

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="appId">公众号AppId</param>
        /// <param name="getNewToken">是否强制重新获取新的Token</param>
        /// <returns></returns>
        public static string GetAccessToken(string appId, bool getNewToken = false)
        {
            return AccessTokenContainer.GetAccessToken(appId, getNewToken);
        }

        /// <summary>
        /// 获取AccessToken（异步）
        /// </summary>
        /// <param name="appId">公众号AppId</param>
        /// <param name="getNewToken">是否强制重新获取新的Token</param>
        /// <returns></returns>
        public static async Task<string> GetAccessTokenAsync(string appId, bool getNewToken = false)
        {
            return await AccessTokenContainer.GetAccessTokenAsync(appId, getNewToken);
        }

        /// <summary>
        /// 获取可用JsApiTicket
        /// </summary>
        /// <param name="appId">公众号AppId</param>
        /// <param name="getNewTicket">是否强制重新获取新的Ticket</param>
        /// <returns></returns>
        public static string GetJsApiTicket(string appId, bool getNewTicket = false)
        {
            return JsApiTicketContainer.GetJsApiTicket(appId, getNewTicket);
        }

        /// <summary>
        /// 获取可用JsApiTicket(异步)
        /// </summary>
        /// <param name="appId">公众号AppId</param>
        /// <param name="getNewTicket">是否强制重新获取新的Ticket</param>
        /// <returns></returns>
        public static async Task<string> GetJsApiTicketAsync(string appId, bool getNewTicket = false)
        {
            return await JsApiTicketContainer.GetJsApiTicketAsync(appId, getNewTicket);
        }
        /// <summary>
        /// 获取可用CardApiTicket
        /// </summary>
        /// <param name="appId">公众号AppId</param>
        /// <param name="getNewTicket">是否强制重新获取新的Ticket</param>
        /// <returns></returns>
        public static string GetWxCardApiTicket(string appId, bool getNewTicket = false)
        {
            return WxCardApiTicketContainer.GetWxCardApiTicket(appId, getNewTicket);
        }

        /// <summary>
        /// 获取可用CardApiTicket(异步)
        /// </summary>
        /// <param name="appId">公众号AppId</param>
        /// <param name="getNewTicket">是否强制重新获取新的Ticket</param>
        /// <returns></returns>
        public static async Task<string> GetWxCardApiTicketAsync(string appId, bool getNewTicket = false)
        {
            return await WxCardApiTicketContainer.GetWxCardApiTicketAsync(appId, getNewTicket);
        }
    }
}
