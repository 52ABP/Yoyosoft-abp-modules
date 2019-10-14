using Alipay.AopSdk.Core.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yoyo.Abp.WebPay
{
    public class WebPayOutput
    {
        /// <summary>
        /// 支付的响应信息
        /// </summary>
        public AlipayTradePagePayResponse Response { get; set; }

        /// <summary>
        /// 默认创建的回调地址
        /// </summary>
        public string RedirectUrl { get; set; }

    }
}
