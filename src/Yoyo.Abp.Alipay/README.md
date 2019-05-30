# Yoyo.Abp.Alipay

## 安装
**Package Manager**
```
Install-Package Yoyo.Abp.Alipay
```
**.NET CLI**
```
dotnet add package Yoyo.Abp.Alipay
```
**Paket CLI**
```
paket add Yoyo.Abp.Alipay
```

## 如何配置


**appsetting.json添加 Pay:Alipay 配置项**

*注意,填写你的支付宝配置参数*

``` json
{
    // .... other configurations
	"Pay": {
		"Alipay": {
			"AlipayPublicKey": "公钥",
			"AppId": "AppId",
			"CharSet": "UTF-8",
			"Gatewayurl": "https://openapi.alipay.com/gateway.do",
			"PrivateKey": "私钥",
			"SignType": "RSA2",
			"Uid": "Uid"
		}
	}
    // .... other configurations
}
```
 


**Startup.cs 添加启动配置**

添加以下代码到 `Startup.cs` 的 `ConfigureServices` 函数中

*注意: 必须在  services.AddAbp 调用之前!*

``` cs
services.AddYoYoAlipay(() =>
{
	// 加载 appsetting.json中的配置,配置详情见上方方配置文件说明
    var res = _appConfiguration.GetSection("Pay:Alipay").Get<AlipayOptions>();
    return res;
}, (fTFConfig) =>
{
	// 配置面对面支付
    if (fTFConfig == null)
    {
        fTFConfig = new FTF.FTFConfig();
    }
	// 面对面二维码生成错误显示图片
    fTFConfig.QRCodeGenErrorImageFullPath = System.IO.Path.Combine(_env.WebRootPath, "imgs", "pay", "alipay_error.png");
	// 面对面生成二维码图中间图标
    fTFConfig.QRCodeIconFullPath = System.IO.Path.Combine(_env.WebRootPath, "imgs", "pay", "alipay.png");
});
```

**添加模块依赖**

添加依赖 `typeof(YoyoAbpAlipayModule)` 到使用的 Module

示例:
``` cs

[DependsOn(
    typeof(YoyoAbpAlipayModule)
)]
public class ABPCommunityWebCoreModule : AbpModule
{

}

```
## 开始使用

* 注入 `IAlipayHelper` 实例 `_alipayHelper`

### API说明
*注意:详情请查看api xml提示信息*

* `_alipayHelper.FTFPay `
    面对面支付，支持轮询和异步通知两种方式
* `_alipayHelper.FTFQuery` 
    面对面支付查询支付结果
* `_alipayHelper.WebPay`
    PC Web支付
* `_alipayHelper.WapPay`
    手机 Web支付
* `_alipayHelper.Query`
    订单查询
* `_alipayHelper.Refund` 
    订单退款
* `_alipayHelper.RefundQuery`
    订单退款查询
* `_alipayHelper.OrderClose` 
    关闭订单
* `_alipayHelper.PayRequestCheck` 
    支付结果校验,在支付同步回调中 或 支付异步回调通知校验支付结果信息


## 相关资源
* [支付宝官方文档](https://docs.open.alipay.com/270/105899/)
* [推荐博客](https://www.cnblogs.com/stulzq/category/1088543.html)
