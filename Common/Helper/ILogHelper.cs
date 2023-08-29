//https://blog.csdn.net/weixin_44900027/article/details/128732197
using Common.Model;
using log4net;
using System.Text;

namespace Common.Helper
{
    public abstract class ILogHelper<T> where T : class
    {
        #region Log4Net
        public static ILog iLog { get; set; } = GetLogConfig<T>();

        public static void Debug(object message)
        {
            if (iLog.IsDebugEnabled)
            {
                iLog.Debug(message);
            }
        }
        public static void Debug(object message, Exception exception)
        {
            if (iLog.IsDebugEnabled)
            {
                iLog.Debug(message, exception);
            }
        }
        public static void Info(object message)
        {
            if (iLog.IsInfoEnabled)
            {
                iLog.Info(message);
            }
        }
        public static void Info(object message, Exception exception)
        {
            if (iLog.IsInfoEnabled)
            {
                iLog.Info(message, exception);
            }
        }

        public static void Error(object message)
        {
            if (iLog.IsErrorEnabled)
            {
                iLog.Error(message);
            }
        }
        public static void Error(object message, Exception exception)
        {
            if (iLog.IsErrorEnabled)
            {
                iLog.Error(message, exception);
            }
        }

        public static void Fatal(object message)
        {
            if (iLog.IsFatalEnabled)
            {
                iLog.Fatal(message);
            }
        }
        public static void Fatal(object message, Exception exception)
        {
            if (iLog.IsFatalEnabled)
            {
                iLog.Fatal(message, exception);
            }
        }
        public static void Warn(object message)
        {
            if (iLog.IsWarnEnabled)
            {
                iLog.Warn(message);
            }
        }
        public static void Warn(object message, Exception exception)
        {
            if (iLog.IsWarnEnabled)
            {
                iLog.Warn(message, exception);
            }
        }
        public static void Debug(LogModel logModel)
        {
            if (!iLog.IsDebugEnabled || logModel == null)
            {
                return;
            }

            Exception? ex = logModel.exception;
            string msg = logModel.LogContent;

            if (ex == null)
            {
                iLog.Debug(msg);
            }
            else
            {
                iLog.Debug(msg, ex);
            }
        }

        public static void Info(LogModel logModel)
        {
            if (!iLog.IsInfoEnabled || logModel == null)
            {
                return;
            }

            Exception? ex = logModel.exception;
            string msg = logModel.LogContent;
            if (ex == null)
            {
                iLog.Info(msg);
            }
            else
            {
                iLog.Info(msg, ex);
            }
        }

        public static void Error(LogModel logModel)
        {
            if (!iLog.IsErrorEnabled || logModel == null)
            {
                return;
            }

            Exception? ex = logModel.exception;
            string msg = logModel.LogContent;
            if (ex == null)
            {
                iLog.Error(msg);
            }
            else
            {
                iLog.Error(msg, ex);
            }
        }

        public static void Fatal(LogModel logModel)
        {
            if (!iLog.IsFatalEnabled || logModel == null)
            {
                return;
            }

            Exception? ex = logModel.exception;
            string msg = logModel.LogContent;
            if (ex == null)
            {
                iLog.Fatal(msg);
            }
            else
            {
                iLog.Fatal(msg, ex);
            }
        }

        public static void Warn(LogModel logModel)
        {
            if (!iLog.IsWarnEnabled || logModel == null)
            {
                return;
            }

            Exception? ex = logModel.exception;
            string msg = logModel.LogContent;
            if (ex == null)
            {
                iLog.Warn(msg);
            }
            else
            {
                iLog.Warn(msg, ex);
            }
        }

        public static ILog GetLogConfig<T>()
        {
            // 由于报No data is available for encoding 936. 所以加上这句
            // GetLogger 创建config中所有对象，根据名字取
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //运行T的构造函数，创建T的实例，即初始化iLog
            Activator.CreateInstance(typeof(T));
            //RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);
            return iLog;
        }
        #endregion
    }
}

