namespace Yoyo.Abp.Configuration
{

    /// <summary>
    /// 阿里云访问权限的信息获取
    /// </summary>
    public class AliyunAccessConfigInfo
    {
        public static string AccessKeyId => ConfigHelper.GetSection(AliyunAppConsts.AccessKeyId);

        public static string AccessKeySecret => ConfigHelper.GetSection(AliyunAppConsts.AccessKeySecret);
    }
}
