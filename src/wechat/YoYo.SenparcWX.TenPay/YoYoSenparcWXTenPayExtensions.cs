using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin.Entities;
using Senparc.Weixin.TenPay;
using Senparc.Weixin.TenPay.V2;
using Senparc.Weixin.TenPay.V3;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoYo
{
    /// <summary>
    /// YoYo Soft 对 Senparc.Weixin.TenPay 的扩展
    /// </summary>
    public static class YoYoSenparcWXTenPayExtensions
    {
        /// <summary>
        /// 注册微信支付Tenpay（注意：新注册账号请使用 UseYoYoSenparcTenpayV3！
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="tenPayInfo">微信支付（旧版本）参数</param>
        /// <param name="name">公众号唯一标识名称</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcTenpayV2(this IRegisterService registerService, Func<TenPayInfo> tenPayInfo, string name)
        {
            return registerService.RegisterTenpayOld(tenPayInfo, name);
        }


        /// <summary>
        /// 根据 SenparcWeixinSetting 自动注册微信支付Tenpay（注意：新注册账号请使用 UseYoYoSenparcTenpayV3！）
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="weixinSettingForOldTepay">ISenparcWeixinSetting</param>
        /// <param name="name">统一标识，如果为null，则使用 weixinSettingForOldTepay.ItemKey </param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcTenpayV2(this IRegisterService registerService, ISenparcWeixinSettingForOldTenpay weixinSettingForOldTepay, string name)
        {
            return registerService.RegisterTenpayOld(weixinSettingForOldTepay, name ?? weixinSettingForOldTepay.ItemKey);
        }


        /// <summary>
        /// 注册微信支付TenpayV3
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="tenPayV3Info">微信支付（新版本 V3）参数</param>
        /// <param name="name">公众号唯一标识名称</param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcTenpayV3(this IRegisterService registerService, Func<TenPayV3Info> tenPayV3Info, string name)
        {
            return registerService.RegisterTenpayV3(tenPayV3Info, name);
        }

        /// <summary>
        /// 根据 SenparcWeixinSetting 自动注册微信支付Tenpay（注意：新注册账号请使用 UseYoYoSenparcTenpayV3！
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="weixinSettingForTenpayV3">ISenparcWeixinSetting</param>
        /// <param name="name">统一标识，如果为null，则使用 SenparcWeixinSetting.ItemKey </param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcTenpayV3(this IRegisterService registerService, ISenparcWeixinSettingForTenpayV3 weixinSettingForTenpayV3, string name)
        {
            return registerService.RegisterTenpayV3(weixinSettingForTenpayV3, name);
        }

    }
}
