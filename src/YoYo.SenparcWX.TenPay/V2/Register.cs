using Senparc.Weixin.TenPay.V2;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoYo.V2
{
    /// <summary>
    /// V2微信支付注册
    /// </summary>
    public class Register<UserKeyType, TenantKeyType>
    {
        /// <summary>
        /// 手动注册微信支付（V2）
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <param name="tenPayInfo">()=>new TenPayInfo()</param>
        /// <param name="name"></param>
        public static void RegisterTenpayOld(UserKeyType userId, TenantKeyType tenantId, Func<TenPayInfo> tenPayInfo, string name)
        {
            RegisterInfoCollection<UserKeyType, TenantKeyType>.Register(userId, tenantId, tenPayInfo().PartnerId);
            TenPayInfoCollection.Register(tenPayInfo(), name);
        }
    }

    /// <summary>
    /// V2微信支付注册
    /// </summary>
    public class Register: Register<long, long>
    {

    }
}
