using System;
using System.Collections.Generic;
using System.Text;

namespace YoYo.FTF
{
    /// <summary>
    /// 面对面支付配置
    /// </summary>
    public class FTFConfig
    {
        /// <summary>
        /// 二维码中间的图标全路径
        /// </summary>
        public string QRCodeIconFullPath { get; set; }

        /// <summary>
        /// 二维码生成错误读取的图片全路径
        /// </summary>
        public string QRCodeGenErrorImageFullPath { get; set; }
    }
}
