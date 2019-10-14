using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Yoyo.Abp
{
    public class YoYoAlipayModule : AbpModule
    {
        public YoYoAlipayModule()
        {

        }

        public override void Initialize()
        {
            var thisAssembly = typeof(YoYoAlipayModule).GetAssembly();

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