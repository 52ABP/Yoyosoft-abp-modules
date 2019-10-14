using Alipay.AopSdk.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yoyo.Abp.WebPay
{
    public class WebPayInput
    {
        /// <summary>
        /// 业务参数
        /// </summary>
        public AlipayTradePagePayModel Data { get; set; }

        /// <summary>
        /// 同步回调地址
        /// </summary>
        public string SynchronizationCallbackUrl { get; set; }

        /// <summary>
        /// 异步通知接收地址
        /// </summary>
        public string AsyncNotifyUrl { get; set; }

    }
}
