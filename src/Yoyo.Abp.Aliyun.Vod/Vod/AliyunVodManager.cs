using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;
using Abp.UI;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.vod.Model.V20170321;
using JetBrains.Annotations;
using Yoyo.Abp.Configuration;

namespace Yoyo.Abp.Vod
{
    /// <summary>
    /// 阿里云VOD的领域服务
    /// </summary>
    public class AliyunVodManager:DomainService
    {

        /// <summary>
        /// 初始化vod获取客户端信息
        /// </summary>
        /// <param name="regionId">如果是外国的源可以用这个方法</param>
        /// <returns></returns>
        public DefaultAcsClient InitVodClient(string regionId)
        {
            

           IClientProfile profile = DefaultProfile.GetProfile(regionId, AliyunAccessConfigInfo.AccessKeyId, AliyunAccessConfigInfo.AccessKeySecret);
           DefaultProfile.AddEndpoint(regionId, regionId, "vod", "vod." + regionId + ".aliyuncs.com");
           var client= new DefaultAcsClient(profile);
           return client;
        }

        /// <summary>
        /// 默认初始化vod服务，读取setting中的内容
        /// </summary>
        /// <returns></returns>
        public DefaultAcsClient InitVodClient()
        {
            IClientProfile profile = DefaultProfile.GetProfile(AliyunVodConfigInfo.RegionId, AliyunAccessConfigInfo.AccessKeyId, AliyunAccessConfigInfo.AccessKeySecret);

            var client = new DefaultAcsClient(profile);
            return client;
        }


        /// <summary>
        /// 获取视频的播放信息
        /// </summary>
        /// <param name="input">参数：https://help.aliyun.com/document_detail/56124.html?spm=a2c4g.11186623.2.14.140f6872F2JNHX</param>
        public GetPlayInfoResponse GetPlayInfo(GetPlayInfoRequest input)
        {
            var client = InitVodClient();
            // 发起请求，并得到 response


            try
            {
                GetPlayInfoResponse response = client.GetAcsResponse(input);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new UserFriendlyException($"获取视频信息报错:{e.Message}");

            }

        }


        /// <summary>
        ///  获取视频播放的凭证信息，加密播放。
        /// </summary>
        /// <param name="input">参数：https://help.aliyun.com/document_detail/52833.html?spm=a2c4g.11186623.2.15.140f6872F2JNHX</param>
        public GetVideoPlayAuthResponse GetVideoPlayAuth(GetVideoPlayAuthRequest  input)
        {
            var client = InitVodClient();
           var   response = client.GetAcsResponse(input);

            return response;

        }

        
    }
}