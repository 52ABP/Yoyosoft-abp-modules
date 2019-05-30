using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin.Entities;
using Senparc.Weixin.TenPay;
using Senparc.Weixin.TenPay.V2;
using Senparc.Weixin.TenPay.V3;
using System;
using System.Collections.Generic;
using System.Text;
using Yoyo.Abp.V2;
using Yoyo.Abp.V3;

namespace Yoyo.Abp
{
    /// <summary>
    /// YoYo Soft 对 Senparc.Weixin.TenPay 的扩展
    /// </summary>
    public static class YoyoAbpWechatTenPayExtensions
    {
        /// <summary>
        /// 注册微信支付Tenpay（注意：新注册账号请使用 UseYoYoSenparcTenpayV3！
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="tenPayInfo">微信支付（旧版本）参数</param>
        /// <param name="name">公众号唯一标识名称</param>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcTenpayV2<UserKeyType, TenantKeyType>(this IRegisterService registerService, Func<TenPayInfo> tenPayInfo, string name, UserKeyType userId = default(UserKeyType), TenantKeyType tenantId = default(TenantKeyType))
        {
            RegisterInfoCollection<UserKeyType, TenantKeyType>.Register(userId, tenantId, tenPayInfo().PartnerId);
            return registerService.RegisterTenpayOld(tenPayInfo, name);
        }
        /// <summary>
        /// 注册微信支付Tenpay（注意：新注册账号请使用 UseYoYoSenparcTenpayV3！
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="tenPayInfo">微信支付（旧版本）参数</param>
        /// <param name="name">公众号唯一标识名称</param>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcTenpayV2(this IRegisterService registerService, Func<TenPayInfo> tenPayInfo, string name, long userId, long tenantId)
        {
            RegisterInfoCollection.Register(userId, tenantId, tenPayInfo().PartnerId);
            return registerService.RegisterTenpayOld(tenPayInfo, name);
        }


        /// <summary>
        /// 根据 SenparcWeixinSetting 自动注册微信支付Tenpay（注意：新注册账号请使用 UseYoYoSenparcTenpayV3！）
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="weixinSettingForOldTepay">ISenparcWeixinSetting</param>
        /// <param name="name">统一标识，如果为null，则使用 weixinSettingForOldTepay.ItemKey </param>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcTenpayV2<UserKeyType, TenantKeyType>(this IRegisterService registerService, ISenparcWeixinSettingForOldTenpay weixinSettingForOldTepay, string name, UserKeyType userId = default(UserKeyType), TenantKeyType tenantId = default(TenantKeyType))
        {
            RegisterInfoCollection<UserKeyType, TenantKeyType>.Register(userId, tenantId, weixinSettingForOldTepay.WeixinPay_PartnerId);
            return registerService.RegisterTenpayOld(weixinSettingForOldTepay, name ?? weixinSettingForOldTepay.ItemKey);
        }
        /// <summary>
        /// 根据 SenparcWeixinSetting 自动注册微信支付Tenpay（注意：新注册账号请使用 UseYoYoSenparcTenpayV3！）
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="weixinSettingForOldTepay">ISenparcWeixinSetting</param>
        /// <param name="name">统一标识，如果为null，则使用 weixinSettingForOldTepay.ItemKey </param>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcTenpayV2(this IRegisterService registerService, ISenparcWeixinSettingForOldTenpay weixinSettingForOldTepay, string name, long userId, long tenantId)
        {
            RegisterInfoCollection.Register(userId, tenantId, weixinSettingForOldTepay.WeixinPay_PartnerId);
            return registerService.RegisterTenpayOld(weixinSettingForOldTepay, name ?? weixinSettingForOldTepay.ItemKey);
        }


        /// <summary>
        /// 注册微信支付TenpayV3
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="tenPayV3Info">微信支付（新版本 V3）参数</param>
        /// <param name="name">公众号唯一标识名称</param>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcTenpayV3<UserKeyType, TenantKeyType>(this IRegisterService registerService, Func<TenPayV3Info> tenPayV3Info, string name, UserKeyType userId = default(UserKeyType), TenantKeyType tenantId = default(TenantKeyType))
        {
            RegisterV3InfoCollection<UserKeyType, TenantKeyType>.Register(userId, tenantId, tenPayV3Info().MchId);
            return registerService.RegisterTenpayV3(tenPayV3Info, name);
        }
        /// <summary>
        /// 注册微信支付TenpayV3
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="tenPayV3Info">微信支付（新版本 V3）参数</param>
        /// <param name="name">公众号唯一标识名称</param>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcTenpayV3(this IRegisterService registerService, Func<TenPayV3Info> tenPayV3Info, string name, long userId, long tenantId)
        {
            RegisterV3InfoCollection.Register(userId, tenantId, tenPayV3Info().MchId);
            return registerService.RegisterTenpayV3(tenPayV3Info, name);
        }

        /// <summary>
        /// 根据 SenparcWeixinSetting 自动注册微信支付Tenpay（注意：新注册账号请使用 UseYoYoSenparcTenpayV3！
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="weixinSettingForTenpayV3">ISenparcWeixinSetting</param>
        /// <param name="name">统一标识，如果为null，则使用 SenparcWeixinSetting.ItemKey </param>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcTenpayV3<UserKeyType, TenantKeyType>(this IRegisterService registerService, ISenparcWeixinSettingForTenpayV3 weixinSettingForTenpayV3, string name, UserKeyType userId = default(UserKeyType), TenantKeyType tenantId = default(TenantKeyType))
        {
            RegisterV3InfoCollection<UserKeyType, TenantKeyType>.Register(userId, tenantId, weixinSettingForTenpayV3.TenPayV3_MchId);
            return registerService.RegisterTenpayV3(weixinSettingForTenpayV3, name);
        }
        /// <summary>
        /// 根据 SenparcWeixinSetting 自动注册微信支付Tenpay（注意：新注册账号请使用 UseYoYoSenparcTenpayV3！
        /// </summary>
        /// <param name="registerService">RegisterService</param>
        /// <param name="weixinSettingForTenpayV3">ISenparcWeixinSetting</param>
        /// <param name="name">统一标识，如果为null，则使用 SenparcWeixinSetting.ItemKey </param>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static IRegisterService UseYoYoSenparcTenpayV3(this IRegisterService registerService, ISenparcWeixinSettingForTenpayV3 weixinSettingForTenpayV3, string name, long userId, long tenantId)
        {
            RegisterV3InfoCollection.Register(userId, tenantId, weixinSettingForTenpayV3.TenPayV3_MchId);
            return registerService.RegisterTenpayV3(weixinSettingForTenpayV3, name);
        }

    }
}
