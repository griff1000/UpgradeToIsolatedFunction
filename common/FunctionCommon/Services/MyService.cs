namespace FunctionCommon.Services
{
    public class MyService : IMyService
    {
        public string SayHello(string name)
        {
            return $"Hello {name}";
        }
    }
}
