using System;
using System.IO;
using Aliyun.OSS;
using Yoyo.Abp.Configuration;
using Yoyo.Abp.Response;

namespace Yoyo.Abp.Oss
{
    public class OssDrive
    {
        private static readonly OssClient Client = new OssClient(AliyunOssConfigInfo.Endpoint, AliyunOssConfigInfo.AccessKeyId, AliyunOssConfigInfo.AccessKeySecret);

        public static ServerResponse<OssFileData> UpLoad(string key, string fileToUpload)
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
                return ResponseProvider.Success(fielData, "成功");
            }
            catch (Exception ex)
            {
                return ResponseProvider.Error<OssFileData>(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">文件名称，包含后缀名称</param>
        /// <param name="fileToUpload"></param>
        /// <returns></returns>
        public static ServerResponse<OssFileData> UpLoad(string fileName, Stream fileToUpload)
        {
            try
            {
                Client.PutObject(AliyunOssConfigInfo.BucketName, fileName, fileToUpload);
                var fielData = new OssFileData
                {
                    Url = AliyunOssConfigInfo.BucketName + "." + AliyunOssConfigInfo.Endpoint + "/" + fileName
                };
                return ResponseProvider.Success(fielData, "成功");
            }
            catch (Exception ex)
            {
                return ResponseProvider.Error<OssFileData>(ex.Message);
            }
        }
    }
}
