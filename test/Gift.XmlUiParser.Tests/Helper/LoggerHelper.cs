using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Xunit;
using Xunit.Abstractions;

namespace Gift.XmlUiParser.Tests.Helper
{
    public static class LoggerHelper
    {
        public static ILogger<T> GetLogger<T>(ITestOutputHelper output)
        {
            var loggerFactory = new LoggerFactory(new[] { new XunitLoggerProvider(output) });
            var logger = loggerFactory.CreateLogger<T>();
            return logger;

        }
    }
}
