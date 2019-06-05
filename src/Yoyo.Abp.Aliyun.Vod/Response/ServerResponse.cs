namespace Yoyo.Abp.Response
{
    public class ServerResponse
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    ///     响应消息类
    /// </summary>
    public class ServerResponse<T> : ServerResponse
        where T : class, new()
    {
        /// <summary>
        ///     业务数据对象
        /// </summary>
        public T Data { get; set; }
    }
}
