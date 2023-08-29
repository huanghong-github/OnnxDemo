using log4net;

namespace Common.Helper
{
    #region 文件日志帮助类
    public class DefaultFileLogHelper : ILogHelper<DefaultFileLogHelper>
    {
        static DefaultFileLogHelper()
        {
            iLog = LogManager.GetLogger(log4NetConfigEnum.Default_File.ToString());
        }
    }

    #endregion
}

