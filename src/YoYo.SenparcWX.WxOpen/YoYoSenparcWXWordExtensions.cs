using System;
using System.Collections.Generic;
using System.Text;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin.Entities;
using Senparc.Weixin.WxOpen;

namespace YoYo
{
    /// <summary>
    /// YoYo Soft 对 Senparc.Weixin.WxOpen 的扩展
    /// </summary>
    public static class YoYoSenparcWXWxOpenExtensions
    {
        /// <summary>
        /// 根据 SenparcWeixinSetting 自动注册小程序信息
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="weixinSettingForWxOpen">SenparcWeixinSetting</param>
        /// <param name="name">统一标识，如果为null，则使用 SenparcWeixinSetting.ItemKey </param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcWxOpenAccount(this IRegisterService registerService, ISenparcWeixinSettingForWxOpen weixinSettingForWxOpen, string name = null)
        {
            return registerService.RegisterWxOpenAccount(weixinSettingForWxOpen, name);
        }


    }
}
