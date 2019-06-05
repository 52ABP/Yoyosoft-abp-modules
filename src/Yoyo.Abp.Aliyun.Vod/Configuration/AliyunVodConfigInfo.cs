namespace Yoyo.Abp.Configuration
{


    /// <summary>
    /// 阿里云视频点播配置信息
    /// </summary>
    public class AliyunVodConfigInfo : AliyunAccessConfigInfo
    {
        /// <summary>
        /// 点播服务器区域
        /// </summary>
        public static string RegionId
        {
            get { return ConfigHelper.GetSection(AliyunAppConsts.Vod.RegionId); }
        }
    }
}
