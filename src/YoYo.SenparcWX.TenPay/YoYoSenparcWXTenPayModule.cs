using Abp;
using Abp.Modules;
using Senparc.Weixin;
using Senparc.Weixin.TenPay.V2;
using Senparc.Weixin.TenPay.V3;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoYo
{
    /// <summary>
    /// YoYo Soft Senparc.WeiXin.TenPay  Module
    /// </summary>
    [DependsOn(typeof(AbpKernelModule))]
    public class YoYoSenparcWXTenPayModule : AbpModule
    {
     
    }
}
