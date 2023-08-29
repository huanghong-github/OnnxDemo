using log4net;

namespace Common.Helper
{
    [Obsolete]
    #region 文件日志帮助类

    public class AdminExceptionFileLogHelper : ILogHelper<AdminExceptionFileLogHelper>
    {
        static AdminExceptionFileLogHelper()
        {
            iLog = LogManager.GetLogger(log4NetConfigEnum.Admin_Ex_File.ToString());
        }
    }

    #endregion
}

