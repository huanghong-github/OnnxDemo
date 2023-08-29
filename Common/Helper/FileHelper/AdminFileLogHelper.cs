using log4net;

namespace Common.Helper
{
    [Obsolete]
    #region 文件日志帮助类
    public class AdminFileLogHelper : ILogHelper<AdminFileLogHelper>
    {
        static AdminFileLogHelper()
        {
            iLog = LogManager.GetLogger(log4NetConfigEnum.Admin_File.ToString());
        }
    }

    #endregion
}
