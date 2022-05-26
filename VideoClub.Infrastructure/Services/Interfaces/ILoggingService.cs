using Serilog;

namespace VideoClub.Infrastructure.Services.Interfaces
{
    public interface ILoggingService
    {
        ILogger Writer { get; }
    }
}