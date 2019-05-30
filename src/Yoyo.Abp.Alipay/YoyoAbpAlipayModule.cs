using Abp.Modules;
using Abp.Reflection.Extensions;
using System;

namespace YoYo
{
    /// <summary>
    /// YoyoSoft Abp 支付宝模块
    /// </summary>
    public class YoyoAbpAlipayModule : AbpModule
    {

        public override void Initialize()
        {
            var thisAssembly = typeof(YoyoAbpAlipayModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);
        }

        public override void PostInitialize()
        {

        }

        public override void PreInitialize()
        {

        }
    }
}
