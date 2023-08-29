using System.Reflection;

namespace Common.Helper
{
    #region 数据库日志帮助类
    public class PropertyPatternConverter : log4net.Layout.Pattern.PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
        {
            if (Option != null)
            {
                // Write the value for the specified key
                WriteObject(writer, loggingEvent.Repository, LookupProperty(Option, loggingEvent));
            }
            else
            {
                // Write all the key value pairs
                WriteDictionary(writer, loggingEvent.Repository, loggingEvent.GetProperties());
            }

        }

        /// <summary>
        /// 通过反射获取传入的日志对象的某个属性的值
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private object LookupProperty(string property, log4net.Core.LoggingEvent loggingEvent)
        {
            object propertyValue = string.Empty;

            PropertyInfo propertyInfo = loggingEvent.MessageObject.GetType().GetProperty(property);

            if (propertyInfo != null)
            {
                propertyValue = propertyInfo.GetValue(loggingEvent.MessageObject, null);
            }

            return propertyValue;

        }

    }

    #endregion
}

