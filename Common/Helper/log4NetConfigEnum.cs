namespace Common.Helper
{
    /// <summary>
    /// 对应log4Net.config文件logger的name属性
    /// </summary>
    public enum log4NetConfigEnum
    {
        //文件日志
        Default_File = 1,             //默认文件日志
        Default_Ex_File,            //默认文件异常日志
        Admin_File,                 //管理员权限文件日志
        Admin_Ex_File,              //管理员权限异常文件日志

        //控制台日志
        ConsoleDefault,                    //默认控制台日志
        ConsoleDefault_Ex,                 //控制台异常日志
        ColoredConsoleDefault,              //有颜色的控制台日志
        ColoredConsoleDefault_Ex,            //有颜色的控制台异常日志

        //Sql日志
        DefaultLog_Sql                  //默认Sql数据库日志

    }


}

