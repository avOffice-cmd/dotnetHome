namespace WebAPI_1.MyLogging
{
    public class LogToDb : IMyLogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("LogToDb");
        }
    }
}
