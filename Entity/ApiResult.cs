namespace AutomationTestFramework.Entity
{
    public class ApiResult
    {
        /// <summary>
        /// code=0成功。1失败
        /// </summary>
        public int code { get; set; } = 0;
        /// <summary>
        ///  结果
        /// </summary>
        public object data { get; set; }
        /// <summary>
        ///  消息
        /// </summary>
        public string msg { get; set; }
    }
}
