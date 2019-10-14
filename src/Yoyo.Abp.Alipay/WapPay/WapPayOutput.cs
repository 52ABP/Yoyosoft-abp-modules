using Alipay.AopSdk.Core.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yoyo.Abp.WapPay
{
    public class WapPayOutput
    {
        public AlipayTradeWapPayResponse Response { get; set; }

        public string Body { get; set; }

    }
}
