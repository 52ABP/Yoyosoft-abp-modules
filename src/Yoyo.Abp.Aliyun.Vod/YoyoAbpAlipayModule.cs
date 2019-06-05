using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Yoyo.Abp
{
    /// <summary>
    /// YoyoSoft Abp 阿里云VOD模块
    /// </summary>
    public class YoyoAbpAliyunVodModule : AbpModule
    {

        public override void Initialize()
        {
            var thisAssembly = typeof(YoyoAbpAliyunVodModule).GetAssembly();

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
