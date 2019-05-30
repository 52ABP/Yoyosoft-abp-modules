using Senparc.Weixin.TenPay.V3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yoyo.Abp.V3
{
    /// <summary>
    /// V3微信支付注册
    /// </summary>
    public class Register<UserKeyType, TenantKeyType>
    {
        /// <summary>
        /// 手动注册微信支付（V3）
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <param name="tenPayV3Info">()=>new TenPayV3Info()</param>
        /// <param name="name"></param>
        public static void RegisterTenpayV3(UserKeyType userId, TenantKeyType tenantId, Func<TenPayV3Info> tenPayV3Info, string name)
        {
            RegisterV3InfoCollection<UserKeyType, TenantKeyType>.Register(userId, tenantId, tenPayV3Info().MchId);
            TenPayV3InfoCollection.Register(tenPayV3Info(), name);
        }
    }
    public class Register: Register<long, long>
    {

    }
}
