namespace Common.Model
{
    public class LogModel
    {
        public long ID { get; set; }
        public int LogKindID { get; set; }
        public int Operator { get; set; }
        public required string LogContent { get; set; }
        public DateTime AddTime { get; set; }
        public Exception? exception { get; set; } = null;
    }

}

