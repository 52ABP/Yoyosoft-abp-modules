using System;
using System.Collections.Generic;
using System.Text;

namespace Yoyo.Abp.Other
{
    public class PayRequestCheckOutput
    {
        /// <summary>
        /// 请求中携带的数据
        /// </summary>
        public Dictionary<string, string> SArray { get; set; }

        /// <summary>
        /// 校验结果,true表示成功，false表示失败
        /// </summary>
        public bool IsSuccess { get; set; }

    }
}
