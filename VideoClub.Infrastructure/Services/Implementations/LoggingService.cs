using System;
using Serilog;
using VideoClub.Infrastructure.Services.Interfaces;

namespace VideoClub.Infrastructure.Services.Implementations
{
    public class LoggingService : ILoggingService
    {
        public ILogger Writer => Log.Logger;

        public LoggingService()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    path: AppDomain.CurrentDomain.BaseDirectory + "Log/logs.txt",
                    rollingInterval: RollingInterval.Day,
                    shared: true,
                    retainedFileCountLimit: 100,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();
        }
    }
}