namespace WebAPI_1.MyLogging
{
    public class LogToFile : IMyLogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("LogToFile");
        }
    }
}
