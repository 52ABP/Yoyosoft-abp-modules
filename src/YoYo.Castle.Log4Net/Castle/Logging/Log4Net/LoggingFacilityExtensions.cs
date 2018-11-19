using Castle.Facilities.Logging;

namespace YoYo.Castle.Logging.Log4Net
{
    /// <summary>
    /// 
    /// </summary>
    public static class LoggingFacilityExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggingFacility"></param>
        /// <returns></returns>
        public static LoggingFacility UseYoYoLog4Net(this LoggingFacility loggingFacility)
        {
            return loggingFacility.LogUsing<Log4NetLoggerFactory>();
        }
    }
}