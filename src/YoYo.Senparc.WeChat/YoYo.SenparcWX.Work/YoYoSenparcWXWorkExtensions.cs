using System;
using System.Collections.Generic;
using System.Text;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin.Work.Containers;
using Senparc.Weixin.Work;

namespace YoYo
{
    /// <summary>
    /// YoYo Soft 对 Senparc.Weixin.Work 的扩展
    /// </summary>
    public static class YoYoSenparcWXWorkExtensions
    {
        /// <summary>
        /// 注册公众号（或小程序）信息
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="weixinCorpId">weixinCorpId</param>
        /// <param name="weixinCorpSecret">weixinCorpSecret</param>
        /// <param name="name">标记AccessToken名称（如微信公众号名称），帮助管理员识别</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcWorkAccount(this IRegisterService registerService, string weixinCorpId, string weixinCorpSecret, string name = null)
        {
            return registerService.RegisterWorkAccount(weixinCorpId, weixinCorpSecret, name);
        }

        /// <summary>
        /// 根据 SenparcWeixinSetting 自动注册第三方平台信息
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="weixinSettingForWork">SenparcWeixinSetting</param>
        /// <param name="name">统一标识，如果为null，则使用 SenparcWeixinSetting.ItemKey </param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcWorkAccount(this IRegisterService registerService, Senparc.Weixin.Entities.ISenparcWeixinSettingForWork weixinSettingForWork,
            string name = null)
        {
            return registerService.RegisterWorkAccount(weixinSettingForWork, name);
        }
    }
}
