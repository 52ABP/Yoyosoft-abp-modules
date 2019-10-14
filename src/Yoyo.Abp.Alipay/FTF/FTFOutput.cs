using System;
using System.Collections.Generic;
using System.Text;

namespace Yoyo.Abp.FTF
{
    public class FTFOutput
    {
        /// <summary>
        /// 二维码图片字节数组
        /// </summary>
        public byte[] QRCodeImageBuffer { get; set; }

        /// <summary>
        /// 是否成功发起支付
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
    }
}
