namespace Net6InProcess
{
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;

    public class TimerFunction
    {
        [FunctionName("TimerFunction")]
        public void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }
}
