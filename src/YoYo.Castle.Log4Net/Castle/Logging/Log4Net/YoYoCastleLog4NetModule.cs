using Abp;
using Abp.Modules;

namespace YoYo.Castle.Logging.Log4Net
{
    /// <summary>
    /// YoYo ABP Castle Log4Net module.
    /// </summary>
    [DependsOn(typeof(AbpKernelModule))]
    public class YoYoCastleLog4NetModule : AbpModule
    {

    }
}