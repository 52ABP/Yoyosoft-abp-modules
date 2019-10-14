namespace Yoyo.Abp.Configuration
{
    public class AliyunOssConfigInfo : AliyunAccessConfigInfo
    {
        public static string Endpoint => ConfigHelper.GetSection(AliyunAppConsts.Oss.Endpoint);

        public static string BucketName => ConfigHelper.GetSection(AliyunAppConsts.Oss.BucketName);
    }
}
