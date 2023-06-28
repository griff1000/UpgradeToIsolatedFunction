namespace Net7Isolated
{
    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Extensions.Logging;

    public class TimerFunction
    {
        [Function("TimerFunction")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, FunctionContext context)
        {
            var logger = context.GetLogger("TimerFunction");
            logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }
}
