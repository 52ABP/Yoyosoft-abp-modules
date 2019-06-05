namespace Yoyo.Abp
{
    /// <summary>
    /// 阿里云服务的常量信息对应json文件
    /// </summary>
    public static class AliyunAppConsts
    {

        public const string AccessKeyId = "Aliyun:AccessKeyId";
      
        public const string AccessKeySecret = "Aliyun:AccessKeySecret";

        /// <summary>
        /// OSS服务
        /// </summary>
        public static class  Oss
        {
            public const string Endpoint = "Aliyun:Oss:Endpoint";
            public const string BucketName = "Aliyun:Oss:BucketName";

        }

        /// <summary>
        /// VOD服务
        /// </summary>
        public static class  Vod
        {
            public const string RegionId = "Aliyun:Vod:RegionId";


        }
    }
}