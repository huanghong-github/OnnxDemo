using log4net;

namespace Common.Helper
{
    [Obsolete]
    #region 控制台日志帮助类

    public class ConsoleExceptionLogHelper : ILogHelper<ConsoleExceptionLogHelper>
    {
        static ConsoleExceptionLogHelper()
        {
            iLog = LogManager.GetLogger(log4NetConfigEnum.ConsoleDefault_Ex.ToString());
        }
    }

    #endregion
}

