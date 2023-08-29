using log4net;

namespace Common.Helper
{
    [Obsolete]
    #region 控制台日志帮助类
    public class ColoredConsoleLogHelper : ILogHelper<ColoredConsoleLogHelper>
    {
        static ColoredConsoleLogHelper()
        {
            iLog = LogManager.GetLogger(log4NetConfigEnum.ColoredConsoleDefault.ToString());
        }
    }

    #endregion
}

