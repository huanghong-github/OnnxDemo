namespace Common.Helper
{
    #region 数据库日志帮助类
    public class MyLayout : log4net.Layout.PatternLayout
    {
        public MyLayout()
        {
            AddConverter("property", typeof(PropertyPatternConverter));
        }
    }

    #endregion

}

