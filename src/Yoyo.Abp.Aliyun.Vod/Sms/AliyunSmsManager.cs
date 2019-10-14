using System;
using Abp.Domain.Services;
using Abp.UI;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Yoyo.Abp.Configuration;

namespace Yoyo.Abp.Sms
{

    /// <summary>
    /// 阿里云短信服务
    /// </summary>
    public class AliyunSmsManager:DomainService
    {



        public string InitMethod()
        {

            return "短信方法注册成功";
        }


        /// <summary>
        /// 初始化Sms获取客户端信息
        /// </summary>
        /// <param name="regionId">默认为default</param>
        /// <returns></returns>
        public DefaultAcsClient InitSmsClient(string regionId="default")
        {

            IClientProfile profile = DefaultProfile.GetProfile(regionId, AliyunAccessConfigInfo.AccessKeyId, AliyunAccessConfigInfo.AccessKeySecret);

            try
            {
                var client = new DefaultAcsClient(profile);
                return client;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new UserFriendlyException(e.Message);
            }
        }


        /// <summary>
        /// 初始化Sms获取客户端信息
        /// </summary>
        /// <param name="regionId">默认为default</param>
        /// <returns></returns>
        public DefaultAcsClient InitSmsClient(string accessKeyId,string accessKeySecret, string regionId = "default")
        {

            IClientProfile profile = DefaultProfile.GetProfile(regionId, accessKeyId, accessKeySecret);

            try
            {
                var client = new DefaultAcsClient(profile);
                return client;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new UserFriendlyException(e.Message);
            }
        }


        public void SendSms()
        {

            InitSmsClient();


        }



        public void QuerySendDetails()
        {


        }




        public void SendBatchSms()
        {


        }



    }
}