namespace Net7Isolated
{
    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Extensions.Logging;

    public class TimerFunction
    {
        [Function("TimerFunction")]
        public void Run([TimerTrigger("0 */5 * * * *")] MyInfo myTimer, FunctionContext context)
        {
            var logger = context.GetLogger("TimerFunction");
            logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

    #region new helper classes
    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }

    #endregion
}
