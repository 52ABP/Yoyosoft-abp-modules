using Senparc.Weixin.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yoyo.Abp.V2
{
    /// <summary>
    /// 用户注册微信支付（V2）InfoCollection
    /// </summary>
    /// <typeparam name="UserKeyType">用户主键类型</typeparam>
    /// <typeparam name="TenantKeyType">租户主键类型</typeparam>
    public class RegisterInfoCollection<UserKeyType, TenantKeyType> : Dictionary<string, string>
    {
        public static RegisterInfoCollection<UserKeyType, TenantKeyType> Data = new RegisterInfoCollection<UserKeyType, TenantKeyType>();
        
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <param name="PartnerId">商户Id</param>
        public static void Register(UserKeyType userId, TenantKeyType tenantId, string PartnerId)
        {
            var key = $"{userId.ToString()}-{tenantId.ToString()}";
            Data[key] = PartnerId;
        }

        public new string this[string key]
        {
            get
            {
                if (!base.ContainsKey(key))
                {
                    throw new WeixinException(string.Format("该用户 {0} 尚未注册Partner", key));
                }
                else
                {
                    return base[key];
                }
            }
            set
            {
                base[key] = value;
            }
        }

        public RegisterInfoCollection()
             : base(StringComparer.OrdinalIgnoreCase)
        {
        }
    }

    /// <summary>
    /// 用户注册微信支付（V2）InfoCollection
    /// </summary>
    public class RegisterInfoCollection: RegisterInfoCollection<long, long>
    {

    }
}
