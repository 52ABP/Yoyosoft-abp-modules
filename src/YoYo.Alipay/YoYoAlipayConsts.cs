using System;
using System.Collections.Generic;
using System.Text;

namespace YoYo
{
    /// <summary>
    /// 常量
    /// </summary>
    public class YoYoAlipayConsts
    {
        /// <summary>
        /// 销售产品码 PC支付 FAST_INSTANT_TRADE_PAY
        /// </summary>
        public const string ProductCode_FAST_INSTANT_TRADE_PAY = "FAST_INSTANT_TRADE_PAY";

        /// <summary>
        /// 销售产品码 H5/WAP支付 QUICK_WAP_WAY
        /// </summary>
        public const string ProductCode_QUICK_WAP_WAY = "QUICK_WAP_WAY";

        /// <summary>
        /// 支付宝交易号	
        /// </summary>
        public const string trade_no = "trade_no";

        /// <summary>
        /// 开发者的app_id	
        /// </summary>
        public const string app_id = "app_id";

        /// <summary>
        /// 卖家支付宝用户号	
        /// </summary>
        public const string seller_id = "seller_id";

        /// <summary>
        /// 商户订单号		
        /// </summary>
        public const string out_trade_no = "out_trade_no";

        /// <summary>
        /// 实收金额	
        /// </summary>
        public const string receipt_amount = "receipt_amount";

        /// <summary>
        /// 交易状态
        /// </summary>
        public const string trade_status = "trade_status";

        /// <summary>
        /// (同步)该笔订单的资金总额，单位为RMB-Yuan。取值范围为[0.01，100000000.00]，精确到小数点后两位。
        /// </summary>
        public const string total_amount = "total_amount";
    }
}
