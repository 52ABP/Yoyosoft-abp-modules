using System;

namespace Yoyo.Abp.Vod.Enum
{

    /// <summary>
    /// 阿里云VOD中视频涉及的常量，如枚举，字段信息等
    /// </summary>

    public static class AliyunVodAppConts
    {  /// <summary>
        /// 搜索媒体资源的类型
        /// </summary>
        public static class MediaTypeConsts
        {

            /// <summary>
            /// 视频，默认值
            /// </summary>
            public const string Video = "video";
            /// <summary>
            /// （音频）
            /// </summary>
            public const string Audio = "audio";
            /// <summary>
            /// （图片）
            /// </summary>
            public const string Image = "image";
            /// <summary>
            /// (辅助媒资）
            /// </summary>
            public const string Attached = "attached";



        }

        /// <summary>
        /// 管理媒体资源的常用返回字段
        /// </summary>
        public static class SearchMediaCommonFilds
        {


            


            /// <summary>
            /// 返回视频的常用字段
            /// </summary>
            public static  string VideoCommonFilds = $"VideoId,MediaSource,MediaType,Title," +
                                                             $"Tags,Status,Size,Duration," +
                                                             $"Description,ModificationTime," +
                                                             $"CreationTime,CoverURL," +
                                                             "CateId,CateName,DownloadSwitch," +
                                                             "PreprocessStatus," +
                                                             "StorageLocation,RegionId," +
                                                             "TranscodeMode,AuditStatus," +
                                                             "AuditAIStatus,AuditManualStatus," +
                                                             "AuditAIResult,AuditTemplateId," +
                                                             "customMediaInfo,AppId";

            public static  string AudioCommonFilds = $"AudioId,mediaSource,Title,Tags,Status,Size,Duration,Description," +
                                                             "ModificationTime,CreationTime,CoverURL,CateId,CateName," +
                                                             "DownloadSwitch,PreprocessStatus,StorageLocation,RegionId," +
                                                             "TranscodeMode,AuditStatus,AuditAIStatus,AuditManualStatus," +
                                                             "AuditAIResult,AuditTemplateId,CustomMediaInfo,AppId";


            public static string ImageCommonFilds = $"Title,ImageId,CateId,CateName,Ext," +
                                                    "CreationTime,ModificationTime,Tags,Type,Url," +
                                                    "Status,Description,StorageLocation,RegionId,AppId";


            public static string AttachedMediaCommonFilds = $"Title,mediaId,Ext," +
                                                            "CreationTime,ModificationTime,Tags,BusinessType,Url," +
                                                            "Status,Description,StorageLocation,RegionId,AppId,Icon," +
                                                            "OnlineStatus";



        }


    }






}