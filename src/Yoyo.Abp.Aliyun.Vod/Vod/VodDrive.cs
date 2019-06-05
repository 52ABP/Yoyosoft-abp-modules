using System;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.vod.Model.V20170321;
using Yoyo.Abp.Configuration;
using Yoyo.Abp.Response;

namespace Yoyo.Abp.Vod
{
    public class VodDrive
    {
        private static DefaultAcsClient _client = null;
        private static readonly object SingletonLock = new object();

        public DefaultAcsClient GetClient()
        {
            if (_client == null)
            {

                lock (SingletonLock)
                {
                    if (_client == null)
                    {
                        _client = InitVodClient();
                    }
                }
            }
            return _client;
        }

        /// <summary>
        /// 初始化vod服务
        /// </summary>
        /// <returns></returns>
        public  DefaultAcsClient InitVodClient()
        {
            IClientProfile profile = DefaultProfile.GetProfile(AliyunVodConfigInfo.RegionId, AliyunVodConfigInfo.AccessKeyId, AliyunVodConfigInfo.AccessKeySecret);
            return new DefaultAcsClient(profile);
        }

        public ServerResponse<GetPlayInfoResponse> GetPlayInfoRequest(GetPlayInfoRequest input)
        {
            try
            {
                var client = GetClient();
                GetPlayInfoResponse response = client.GetAcsResponse(input);

                return ResponseProvider.Success(response, "成功");
            }
            catch (Exception ex)
            {
                return ResponseProvider.Error<GetPlayInfoResponse>(ex.Message);
            }
        }

    }
}
