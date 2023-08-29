using log4net;

namespace Common.Helper
{
    #region 控制台日志帮助类
    public class ConsoleLogHelper : ILogHelper<ConsoleLogHelper>
    {
        static ConsoleLogHelper()
        {
            iLog = LogManager.GetLogger(log4NetConfigEnum.ConsoleDefault.ToString());
        }
    }

    #endregion
}

