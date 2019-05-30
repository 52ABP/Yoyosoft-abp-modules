using Senparc.Weixin.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yoyo.Abp.V3
{
    /// <summary>
    /// 用户注册微信支付（V3）InfoCollection
    /// </summary>
    /// <typeparam name="UserKeyType">用户主键类型</typeparam>
    /// <typeparam name="TenantKeyType">租户主键类型</typeparam>
    public class RegisterV3InfoCollection<UserKeyType, TenantKeyType> : Dictionary<string, string>
    {
        public static RegisterV3InfoCollection<UserKeyType, TenantKeyType> Data = new RegisterV3InfoCollection<UserKeyType, TenantKeyType>();

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tenantId"></param>
        /// <param name="MchId">商户Id</param>
        public static void Register(UserKeyType userId, TenantKeyType tenantId, string MchId)
        {
            var key = $"{userId.ToString()}-{tenantId.ToString()}";
            Data[key] = MchId;
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

        public RegisterV3InfoCollection()
             : base(StringComparer.OrdinalIgnoreCase)
        {
        }
    }

    /// <summary>
    /// 用户注册微信支付（V3）InfoCollection
    /// </summary>
    public class RegisterV3InfoCollection: RegisterV3InfoCollection<long, long>
    {

    }
}
