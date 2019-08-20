namespace TeamTickets.Entity
{
    public class HttpErr
    {
        public int code { get; set; }
        public string msg { get; set; }
        /// <summary>
        /// 查询结果
        /// </summary>
        public TicketReturnInfo retval { get; set; }
    }
    public class TicketReturnInfo
    {
        public string certificateNum { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}
