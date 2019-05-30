using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

using Abp.Extensions;
using QRCoder;

using Alipay.AopSdk.AspnetCore;
using Alipay.AopSdk.F2FPay.Domain;
using Alipay.AopSdk.F2FPay.Business;
using Alipay.AopSdk.Core.Request;
using Alipay.AopSdk.Core.Domain;

using F2FResultEnum = Alipay.AopSdk.F2FPay.Model.ResultEnum;
using Alipay.AopSdk.Core.Response;

using Yoyo.Abp.WapPay;
using Yoyo.Abp.FTF;
using Yoyo.Abp.WebPay;
using Yoyo.Abp.Other;

namespace Yoyo.Abp
{
    /// <summary>
    /// 支付宝支付默认实现
    /// </summary>
    public class DefatultAlipayHelper : IAlipayHelper
    {
        private readonly AlipayF2FService _alipayF2FService;
        private readonly AlipayService _alipayService;
        private readonly FTFConfig _fTFConfig;

        public DefatultAlipayHelper(
            AlipayF2FService alipayF2FService,
            AlipayService alipayService,
            IOptions<FTFConfig> fTFConfigOptions
            )
        {
            _alipayF2FService = alipayF2FService;
            _alipayService = alipayService;
            _fTFConfig = fTFConfigOptions.Value;
        }


        #region 面对面支付


        /// <summary>
        /// 面对面支付(异步消息通知),返回生成的图片二维码byte数组
        /// </summary>
        /// <param name="input">支付信息</param>
        /// <param name="asyncNotifyUrl">异步消息通知地址</param>
        /// <param name="fTFConfig">面对面支付配置信息(不填则使用全局配置的)</param>
        /// <returns>二维码图片字节数组</returns>
        public async Task<FTFOutput> FTFPay(AlipayTradePrecreateContentBuilder input, string asyncNotifyUrl, FTFConfig fTFConfig = null)
        {
            return await this.FTFGenQRCode(input, asyncNotifyUrl, null, fTFConfig);
        }

        /// <summary>
        /// 面对面支付(轮询),返回生成的图片二维码byte数组
        /// </summary>
        /// <param name="input">支付信息</param>
        /// <param name="loopQueryAction"></param>
        /// <param name="fTFConfig">面对面支付配置信息(不填则使用全局配置的)</param>
        /// <returns></returns>
        public async Task<FTFOutput> FTFPay(AlipayTradePrecreateContentBuilder input, Action<AlipayF2FPrecreateResult> loopQueryAction, FTFConfig fTFConfig = null)
        {
            return await this.FTFGenQRCode(input, null, loopQueryAction, fTFConfig);
        }

        /// <summary>
        /// 面对面支付结果查询
        /// </summary>
        /// <param name="outTradeNo"></param>
        /// <returns></returns>
        public async Task<AlipayF2FQueryResult> FTFQuery(string outTradeNo)
        {
            return await _alipayF2FService.TradeQueryAsync(outTradeNo);
        }

        #endregion


        #region PC Web 支付

        /// <summary>
        /// PC Web 支付，返回支付宝支付链接
        /// </summary>
        /// <param name="input">支付信息和回调通知信息</param>
        /// <param name="options">支付选项,如果为空则使用添加时内置的</param>
        /// <returns>返回支付宝支付链接</returns>
        public async Task<WebPayOutput> WebPay(WebPayInput input, AlipayOptions options = null)
        {
            await Task.Yield();

            if (input.Data.ProductCode.IsNullOrWhiteSpace())
            {
                input.Data.ProductCode = YoyoAbpAlipayConsts.ProductCode_FAST_INSTANT_TRADE_PAY;
            }


            var request = new AlipayTradePagePayRequest();

            // 设置同步回调地址
            request.SetReturnUrl(input.SynchronizationCallbackUrl);
            // 设置异步通知接收地址
            request.SetNotifyUrl(input.AsyncNotifyUrl);
            // 将业务model载入到request
            request.SetBizModel(input.Data);

            // 发起支付
            var response = this._alipayService.SdkExecute(request);

            // 返回回调地址
            var tmpOptions = options ?? _alipayService.Options;

            return new WebPayOutput()
            {
                Response = response,
                RedirectUrl = $"{tmpOptions.Gatewayurl}?{response.Body}"
            };
        }

        #endregion


        #region Mobile WAP 支付

        public async Task<WapPayOutput> WapPay(WapPayInput input, AlipayOptions options = null)
        {
            await Task.Yield();

            // 设置产品代码
            if (input.Data.ProductCode.IsNullOrWhiteSpace())
            {
                input.Data.ProductCode = YoyoAbpAlipayConsts.ProductCode_QUICK_WAP_WAY;
            }
            // 设置支付中途退出返回商户网站地址
            if (input.Data.QuitUrl.IsNullOrWhiteSpace())
            {
                input.Data.QuitUrl = input.QuitUrl;
            }

            var request = new AlipayTradeWapPayRequest();
            // 设置同步回调地址
            request.SetReturnUrl(input.SynchronizationCallbackUrl);
            // 设置异步通知接收地址
            request.SetNotifyUrl(input.AsyncNotifyUrl);
            // 将业务model载入到request
            request.SetBizModel(input.Data);

            // 发起支付
            var response = await this._alipayService.PageExecuteAsync(request);

            return new WapPayOutput()
            {
                Response = response,
                Body = response.Body
            };
        }

        #endregion

        #region 订单查询


        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="input">查询数据</param>
        /// <returns></returns>
        public async Task<AlipayTradeQueryResponse> Query(OrderQueryInput input)
        {
            return await this.Query(input.Data);
        }

        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="input">查询数据</param>
        /// <returns></returns>
        public async Task<AlipayTradeQueryResponse> Query(AlipayTradeQueryModel input)
        {
            var request = new AlipayTradeQueryRequest();
            request.SetBizModel(input);

            var response = await _alipayService.ExecuteAsync(request);

            return response;
        }

        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="tradeNo">商户系统订单编码</param>
        /// <param name="alipayTradeNo">支付宝订单编码</param>
        /// <returns></returns>
        public async Task<AlipayTradeQueryResponse> Query(string tradeNo, string alipayTradeNo)
        {
            AlipayTradeQueryModel model = new AlipayTradeQueryModel
            {
                OutTradeNo = tradeNo,
                TradeNo = alipayTradeNo
            };

            return await this.Query(model);
        }

        #endregion


        #region 订单退款

        /// <summary>
        /// 订单退款
        /// </summary>
        /// <param name="input">退款数据</param>
        /// <returns></returns>
        public async Task<AlipayTradeRefundResponse> Refund(RefundInput input)
        {
            return await this.Refund(input.Data);
        }

        /// <summary>
        /// 订单退款
        /// </summary>
        /// <param name="input">退款数据</param>
        /// <returns></returns>
        public async Task<AlipayTradeRefundResponse> Refund(AlipayTradeRefundModel input)
        {
            AlipayTradeRefundRequest request = new AlipayTradeRefundRequest();
            request.SetBizModel(input);

            var response = await _alipayService.ExecuteAsync(request);

            return response;
        }

        /// <summary>
        /// 订单退款
        /// </summary>
        /// <param name="tradeno">商户订单号</param>
        /// <param name="alipayTradeNo">支付宝交易号</param>
        /// <param name="refundAmount">退款金额</param>
        /// <param name="refundReason">退款原因</param>
        /// <param name="refundNo">退款单号</param>
        /// <returns></returns>
        public async Task<AlipayTradeRefundResponse> Refund(string tradeno, string alipayTradeNo, string refundAmount, string refundReason, string refundNo)
        {
            var model = new AlipayTradeRefundModel();
            model.OutTradeNo = tradeno;
            model.TradeNo = alipayTradeNo;
            model.RefundAmount = refundAmount;
            model.RefundReason = refundReason;
            model.OutRequestNo = refundNo;

            return await this.Refund(model);
        }

        #endregion


        #region 订单退款查询

        /// <summary>
        /// 订单退款查询
        /// </summary>
        /// <param name="input">查询信息</param>
        /// <returns></returns>
        public async Task<AlipayTradeFastpayRefundQueryResponse> RefundQuery(RefundQueryInput input)
        {
            return await this.RefundQuery(input.Data);
        }

        /// <summary>
        /// 订单退款查询
        /// </summary>
        /// <param name="model">查询信息</param>
        /// <returns></returns>
        public async Task<AlipayTradeFastpayRefundQueryResponse> RefundQuery(AlipayTradeFastpayRefundQueryModel input)
        {
            if (string.IsNullOrEmpty(input.OutRequestNo))
            {
                input.OutRequestNo = input.OutTradeNo;
            }

            var request = new AlipayTradeFastpayRefundQueryRequest();
            request.SetBizModel(input);

            AlipayTradeFastpayRefundQueryResponse response = await _alipayService.ExecuteAsync(request);
            return response;
        }

        /// <summary>
        /// 订单退款查询
        /// </summary>
        /// <param name="tradeno">商户订单号</param>
        /// <param name="alipayTradeNo">支付宝交易号</param>
        /// <param name="refundNo">退款单号</param>
        /// <returns></returns>
        public async Task<AlipayTradeFastpayRefundQueryResponse> RefundQuery(string tradeno, string alipayTradeNo, string refundNo)
        {
            var model = new AlipayTradeFastpayRefundQueryModel();
            model.OutTradeNo = tradeno;
            model.TradeNo = alipayTradeNo;
            model.OutRequestNo = refundNo;

            return await this.RefundQuery(model);
        }

        #endregion


        #region 关闭订单


        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="input">关闭订单数据</param>
        /// <returns></returns>
        public async Task<AlipayTradeCloseResponse> OrderClose(OrderCloseInput input)
        {
            return await this.OrderClose(input.Data);
        }

        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="input">关闭订单数据</param>
        /// <returns></returns>
        public async Task<AlipayTradeCloseResponse> OrderClose(AlipayTradeCloseModel input)
        {

            var request = new AlipayTradeCloseRequest();
            request.SetBizModel(input);

            var response = await _alipayService.ExecuteAsync(request);

            return response;
        }


        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="tradeno">商户订单号</param>
        /// <param name="alipayTradeNo">支付宝交易号</param>
        /// <returns></returns>
        public async Task<AlipayTradeCloseResponse> OrderClose(string tradeno, string alipayTradeNo)
        {
            var model = new AlipayTradeCloseModel()
            {
                OutTradeNo = tradeno,
                TradeNo = alipayTradeNo,
            };

            return await this.OrderClose(model);
        }



        #endregion


        #region 回调获取请求数据

        public async Task<PayRequestCheckOutput> PayRequestCheck(HttpRequest request)
        {
            await Task.Yield();

            var result = new PayRequestCheckOutput();

            if (request.Method.ToLower() == "post")
            {
                result.SArray = GetRequestPost(request);
            }
            else
            {
                result.SArray = GetRequestGet(request);
            }

            if (result.SArray.Count != 0)
            {
                result.IsSuccess = _alipayService.RSACheckV1(result.SArray);
            }

            return result;
        }

        #endregion


        #region FTF Pay 私有函数

        /// <summary>
        /// 面对面支付生成支付二维码
        /// </summary>
        /// <param name="input">支付数据</param>
        /// <param name="asyncNotifyUrl">异步通知地址,为空则表示为同步轮询模式</param>
        /// <param name="loopQueryAction">同步轮询回调函数</param>
        /// <param name="fTFConfig">面对面支付其它配置</param>
        /// <returns></returns>
        private async Task<FTFOutput> FTFGenQRCode(AlipayTradePrecreateContentBuilder input, string asyncNotifyUrl, Action<AlipayF2FPrecreateResult> loopQueryAction, FTFConfig fTFConfig)
        {
            // 参数检测
            var isAsyncNotify = !asyncNotifyUrl.IsNullOrWhiteSpace();
            if (!isAsyncNotify && loopQueryAction == null)
            {
                throw new NullReferenceException("轮询模式下 loopQueryAction 不能为空!");
            }
            // 收款账号检测,如果为空则默认填入全局配置的Uid
            if (input.seller_id.IsNullOrWhiteSpace())
            {
                input.seller_id = this._alipayService.Options.Uid;
            }



            Bitmap bitmap = null;
            MemoryStream memoryStream = null;
            var message = string.Empty;

            //推荐使用轮询撤销机制，不推荐使用异步通知,避免单边账问题发生。
            AlipayF2FPrecreateResult precreateResult = null;
            // 异步通知
            if (isAsyncNotify)
            {
                precreateResult = await _alipayF2FService.TradePrecreateAsync(input, asyncNotifyUrl);

            }// 同步轮询
            else
            {
                precreateResult = await _alipayF2FService.TradePrecreateAsync(input);
            }

            switch (precreateResult.Status)
            {
                case F2FResultEnum.SUCCESS:
                    // 将链接用二维码工具生成二维码打印出来，顾客可以用支付宝钱包扫码支付。
                    bitmap = RenderQrCode(precreateResult.response.QrCode);
                    // 同步轮询模式,触发轮询回调函数
                    if (!isAsyncNotify)
                    {
                        loopQueryAction.Invoke(precreateResult);
                    }
                    break;
                case F2FResultEnum.FAILED:
                    message = $"生成二维码失败: {precreateResult.response.Body}";
                    break;

                case F2FResultEnum.UNKNOWN:
                    message = "生成二维码失败：" + (precreateResult.response == null ? "配置或网络异常，请检查后重试" : "系统异常，请更新外部订单后重新发起请求");
                    break;
            }

            // 如果位图为空,则生成错误提示二维码
            if (bitmap == null)
            {
                bitmap = new Bitmap(fTFConfig == null ? this._fTFConfig?.QRCodeGenErrorImageFullPath : fTFConfig.QRCodeGenErrorImageFullPath);
            }

            // 转换成字节数组
            memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, ImageFormat.Png);
            var imgBuffer = memoryStream.GetBuffer();

            // 释放资源
            memoryStream.Dispose();
            bitmap.Dispose();

            return new FTFOutput()
            {
                QRCodeImageBuffer = imgBuffer,
                IsSuccess = precreateResult.Status == F2FResultEnum.SUCCESS,
                Message = message
            };
        }


        /// <summary>
        /// FTF渲染二维码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private Bitmap RenderQrCode(string str, FTFConfig fTFConfig = null)
        {
            var eccLevel = QRCodeGenerator.ECCLevel.L;
            using (var qrGenerator = new QRCodeGenerator())
            {
                using (var qrCodeData = qrGenerator.CreateQrCode(str, eccLevel))
                {
                    using (var qrCode = new QRCode(qrCodeData))
                    {

                        var bp = qrCode.GetGraphic(20, Color.Black, Color.White,
                            new Bitmap(fTFConfig == null ? this._fTFConfig?.QRCodeIconFullPath : fTFConfig.QRCodeIconFullPath),
                            15);
                        return bp;
                    }
                }
            }

        }


        #endregion


        #region 解析请求参数

        private Dictionary<string, string> GetRequestGet(HttpRequest request)
        {
            Dictionary<string, string> sArray = new Dictionary<string, string>();

            ICollection<string> requestItem = request.Query.Keys;
            foreach (var item in requestItem)
            {
                sArray.Add(item, request.Query[item]);

            }
            return sArray;

        }

        private Dictionary<string, string> GetRequestPost(HttpRequest request)
        {
            Dictionary<string, string> sArray = new Dictionary<string, string>();

            ICollection<string> requestItem = request.Form.Keys;
            foreach (var item in requestItem)
            {
                sArray.Add(item, request.Form[item]);

            }
            return sArray;

        }

        #endregion
    }
}
