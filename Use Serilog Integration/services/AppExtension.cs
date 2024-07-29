using Serilog;
using Serilog.Formatting.Json;

namespace Use_Serilog_Integration.services
{
    public  static class AppExtension
    {
        public static void SerilogConfiguration(this  IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context,loggerConfig) =>
            {
               // loggerConfig.WriteTo.Console();
              //  loggerConfig.WriteTo.File("app_logs.txt");
               // loggerConfig.WriteTo.File(new JsonFormatter(),"app_logs2.txt");
                //loggerConfig.WriteTo.File(new JsonFormatter(),"Logs/app_logs-.txt",rollingInterval:RollingInterval.Day);//create file log every day

                loggerConfig.ReadFrom.Configuration(context.Configuration);



            });
        }

    }
}
