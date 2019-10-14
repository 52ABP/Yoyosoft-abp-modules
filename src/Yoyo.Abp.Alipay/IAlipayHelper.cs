using System;
using System.Threading.Tasks;
using Abp.Dependency;
using Alipay.AopSdk.AspnetCore;
using Alipay.AopSdk.Core.Domain;
using Alipay.AopSdk.Core.Response;
using Alipay.AopSdk.F2FPay.Business;
using Alipay.AopSdk.F2FPay.Domain;
using Microsoft.AspNetCore.Http;
using Yoyo.Abp.FTF;
using Yoyo.Abp.Other;
using Yoyo.Abp.WapPay;
using Yoyo.Abp.WebPay;

namespace Yoyo.Abp
{
    /// <summary>
    /// 支付宝支付
    /// </summary>
    public interface IAlipayHelper : ISingletonDependency
    {
        /// <summary>
        /// 面对面支付(异步消息通知),返回生成的图片二维码byte数组
        /// </summary>
        /// <param name="input">支付信息</param>
        /// <param name="asyncNotifyUrl">异步消息通知地址</param>
        /// <param name="fTFConfig">面对面支付配置信息(不填则使用全局配置的)</param>
        /// <returns>二维码图片字节数组</returns>
        Task<FTFOutput> FTFPay(AlipayTradePrecreateContentBuilder input, string asyncNotifyUrl, FTFConfig fTFConfig = null);

        /// <summary>
        /// 面对面支付(轮询),返回生成的图片二维码byte数组
        /// </summary>
        /// <param name="input">支付信息</param>
        /// <param name="loopQueryAction">轮询的回调函数</param>
        /// <param name="fTFConfig">面对面支付配置信息(不填则使用全局配置的)</param>
        /// <returns></returns>
        Task<FTFOutput> FTFPay(AlipayTradePrecreateContentBuilder input, Action<AlipayF2FPrecreateResult> loopQueryAction, FTFConfig fTFConfig = null);

        /// <summary>
        /// 面对面支付结果查询
        /// </summary>
        /// <param name="outTradeNo"></param>
        /// <returns></returns>
        Task<AlipayF2FQueryResult> FTFQuery(string outTradeNo);

        /// <summary>
        /// PC Web 支付
        /// </summary>
        /// <param name="input">支付信息和回调通知信息</param>
        /// <param name="options">支付选项,如果为空则使用添加时内置的</param>
        /// <returns></returns>
        Task<WebPayOutput> WebPay(WebPayInput input, AlipayOptions options = null);

        /// <summary>
        /// 手机Web支付
        /// </summary>
        /// <param name="input">支付信息和回调通知信息</param>
        /// <param name="options">支付选项,如果为空则使用添加时内置的</param>
        /// <returns></returns>
        Task<WapPayOutput> WapPay(WapPayInput input, AlipayOptions options = null);

        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="input">查询数据</param>
        /// <returns></returns>
        Task<AlipayTradeQueryResponse> Query(OrderQueryInput input);
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="input">查询数据</param>
        /// <returns></returns>
        Task<AlipayTradeQueryResponse> Query(AlipayTradeQueryModel input);
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="tradeNo">商户系统订单编码</param>
        /// <param name="alipayTradeNo">支付宝订单编码</param>
        /// <returns></returns>
        Task<AlipayTradeQueryResponse> Query(string tradeNo, string alipayTradeNo);


        /// <summary>
        /// 订单退款
        /// </summary>
        /// <param name="input">退款数据</param>
        /// <returns></returns>
        Task<AlipayTradeRefundResponse> Refund(RefundInput input);
        /// <summary>
        /// 订单退款
        /// </summary>
        /// <param name="input">退款数据</param>
        /// <returns></returns>
        Task<AlipayTradeRefundResponse> Refund(AlipayTradeRefundModel input);

        /// <summary>
        /// 订单退款
        /// </summary>
        /// <param name="tradeno">商户订单号</param>
        /// <param name="alipayTradeNo">支付宝交易号</param>
        /// <param name="refundAmount">退款金额</param>
        /// <param name="refundReason">退款原因</param>
        /// <param name="refundNo">退款单号</param>
        /// <returns></returns>
        Task<AlipayTradeRefundResponse> Refund(string tradeno, string alipayTradeNo, string refundAmount, string refundReason, string refundNo);

        /// <summary>
        /// 订单退款查询
        /// </summary>
        /// <param name="input">查询数据</param>
        /// <returns></returns>
        Task<AlipayTradeFastpayRefundQueryResponse> RefundQuery(RefundQueryInput input);

        /// <summary>
        /// 订单退款查询
        /// </summary>
        /// <param name="model">查询数据</param>
        /// <returns></returns>
        Task<AlipayTradeFastpayRefundQueryResponse> RefundQuery(AlipayTradeFastpayRefundQueryModel input);

        /// <summary>
        /// 订单退款查询
        /// </summary>
        /// <param name="tradeno">商户订单号</param>
        /// <param name="alipayTradeNo">支付宝交易号</param>
        /// <param name="refundNo">退款单号</param>
        /// <returns></returns>
        Task<AlipayTradeFastpayRefundQueryResponse> RefundQuery(string tradeno, string alipayTradeNo, string refundNo);

        /// <summary>
		/// 关闭订单
		/// </summary>
		/// <param name="input">关闭订单数据</param>
		/// <returns></returns>
        Task<AlipayTradeCloseResponse> OrderClose(OrderCloseInput input);
        /// <summary>
        /// 关闭订单
        /// </summary>
		/// <param name="input">关闭订单数据</param>
        /// <returns></returns>
        Task<AlipayTradeCloseResponse> OrderClose(AlipayTradeCloseModel input);
        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="tradeNo">商户订单号</param>
        /// <param name="alipayTradeNo">支付宝交易号</param>
        /// <returns></returns>
        Task<AlipayTradeCloseResponse> OrderClose(string tradeNo, string alipayTradeNo);


        /// <summary>
        /// 校验,在支付同步回调中 或 支付异步回调通知
        /// </summary>
        /// <returns></returns>
        Task<PayRequestCheckOutput> PayRequestCheck(HttpRequest request);
    }
}
