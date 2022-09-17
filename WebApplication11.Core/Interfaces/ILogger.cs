namespace WebApplication11.Core.Interfaces;

public interface ILogger
{
    string GetCurrentDirectory();
    string GetDirectoryByLoggerName(string loggerName);
    string DefaultLogger { get; }
}