using log4net;

namespace Common.Helper
{
    [Obsolete]
    #region 控制台日志帮助类
    public class ColoredConsoleExceptionLogHelper : ILogHelper<ColoredConsoleExceptionLogHelper>
    {
        static ColoredConsoleExceptionLogHelper()
        {
            iLog = LogManager.GetLogger(log4NetConfigEnum.ColoredConsoleDefault_Ex.ToString());
        }
    }
    #endregion
}

