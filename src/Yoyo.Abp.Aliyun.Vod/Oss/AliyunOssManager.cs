using System;
using System.IO;
using Abp.Domain.Services;
using Abp.UI;
using Aliyun.OSS;
using Yoyo.Abp.Configuration;

namespace Yoyo.Abp.Oss
{
    /// <summary>
    /// 阿里云OSS的服务类
    /// </summary>
    public class AliyunOssManager:DomainService
    {
        private static readonly OssClient Client = new OssClient(AliyunOssConfigInfo.Endpoint, AliyunOssConfigInfo.AccessKeyId, AliyunOssConfigInfo.AccessKeySecret);


        public  OssFileData UpLoad(string key, string fileToUpload)
        {
            var fileExtensionName = Path.GetExtension(fileToUpload);//文件扩展名
            var filePath = $"{key}{fileExtensionName}";//云文件保存路径  
            try
            {
                Client.PutObject(AliyunOssConfigInfo.BucketName, filePath, fileToUpload);
                var fielData = new OssFileData
                {
                    Url = AliyunOssConfigInfo.BucketName + "." + AliyunOssConfigInfo.Endpoint + "/" + filePath
                };
                return fielData;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException($"文件上传失败:{e.Message}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// &lt;param name="fileName"&gt;文件名称，包含后缀名称&lt;/param&gt;
        /// <param name="fileName"></param>
        /// <param name="fileToUpload"></param>
        /// <returns></returns>
        public static OssFileData UpLoad(string fileName, Stream fileToUpload)
        {
            try
            {
                Client.PutObject(AliyunOssConfigInfo.BucketName, fileName, fileToUpload);
                var fielData = new OssFileData
                {
                    Url = AliyunOssConfigInfo.BucketName + "." + AliyunOssConfigInfo.Endpoint + "/" + fileName
                };
                return fielData;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException($"文件上传失败:{e.Message}");
            }
        }

    }
}