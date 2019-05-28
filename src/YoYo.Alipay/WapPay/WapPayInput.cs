using Alipay.AopSdk.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoYo.WapPay
{
    public class WapPayInput
    {
        public AlipayTradeWapPayModel Data { get; set; }

        /// <summary>
        /// 支付中途退出返回商户网站地址
        /// </summary>
        public string QuitUrl { get; set; }


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
