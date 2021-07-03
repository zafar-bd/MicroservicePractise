using Serilog;

namespace Common.Logging
{
    public static class GlobalLogger
    {
        public static void ConfigureLog()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .Seq("http://localhost:5341")
                .MinimumLevel
                .Information()
                .Enrich
                .FromLogContext()
                .CreateLogger();
        }
    }


}
