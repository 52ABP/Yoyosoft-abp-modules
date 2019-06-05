namespace Yoyo.Abp.Response
{
    public class ResponseProvider
    {
        /// <summary>
        ///     响应消息封装类
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse Success(string msg = null)
        {
            var result = new ServerResponse { Status = true, Message = msg };
            return result;
        }

        /// <summary>
        ///     响应消息封装类
        /// </summary>
        /// <param name="status">状态:0 -成功 其它 失败</param>
        /// <param name="errMsg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse Error(string errMsg, bool status = false)
        {
            var result = new ServerResponse { Status = status, Message = errMsg };
            return result;
        }

        /// <summary>
        ///     响应消息封装类
        /// </summary>
        /// <param name="data">业务数据</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse<T> Success<T>(T data, string msg = null) where T : class, new()
        {
            var result = new ServerResponse<T> { Data = data, Status = true, Message = msg };

            return result;
        }

        /// <summary>
        ///     Http 响应消息封装类
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse<T> Error<T>(string msg = null, T Data = null) where T : class, new()
        {
            var result = new ServerResponse<T> { Data = Data, Status = false, Message = msg };

            return result;
        }
    }
}
