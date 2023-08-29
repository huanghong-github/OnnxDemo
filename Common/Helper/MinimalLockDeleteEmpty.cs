using log4net.Appender;

namespace Common.Helper
{
    /// <summary>
    /// 避免生成空白文件
    /// </summary>
    public class MinimalLockDeleteEmpty : FileAppender.MinimalLock
    {
        public override void ReleaseLock()
        {
            base.ReleaseLock();

            FileInfo logFile = new(CurrentAppender.File);
            if (logFile.Exists && logFile.Length <= 0)
            {
                logFile.Delete();
            }
        }
    }
}

