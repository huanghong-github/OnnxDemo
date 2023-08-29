using Common.Model;
using log4net;

namespace Common.Helper
{
    #region 数据库日志帮助类
    public class SqlLogHelper : log4net.Layout.PatternLayout
    {
        public static ILog iLog = LogManager.GetLogger(log4NetConfigEnum.DefaultLog_Sql.ToString());

        public SqlLogHelper() => new MyLayout();

        public static bool Info(LogModel logModel)
        {
            if (!iLog.IsInfoEnabled || logModel == null)
            {
                return false;
            }

            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(new SqlLogHelper().GetType().TypeHandle);
            iLog.Info(logModel);
            return true;
        }
    }

    #endregion

}

