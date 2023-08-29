using log4net;

namespace Common.Helper
{
    [Obsolete]
    #region 文件日志帮助类

    public class FileExceptionLogHelper : ILogHelper<FileExceptionLogHelper>
    {
        static FileExceptionLogHelper()
        {
            iLog = LogManager.GetLogger(log4NetConfigEnum.Default_Ex_File.ToString());
        }
    }

    #endregion
}

