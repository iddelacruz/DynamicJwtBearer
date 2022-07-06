using Microsoft.Extensions.Logging;
using System;

namespace PoweredSoft.DynamicJwtBearer;

internal static class LoggingExtensions
{
    private readonly static Action<ILogger, Exception> tokenValidationFailed;
    private readonly static Action<ILogger, Exception> tokenValidationSucceeded;
    private readonly static Action<ILogger, Exception> errorProcessingMessage;

#pragma warning disable S3963 // "static" fields should be initialized inline
    static LoggingExtensions()
    {
        tokenValidationFailed = LoggerMessage.Define(eventId: new EventId(1, "TokenValidationFailed"),
                                                      logLevel: LogLevel.Information,
                                                      formatString: "Failed to validate the token.");
        tokenValidationSucceeded = LoggerMessage.Define(eventId: new EventId(2, "TokenValidationSucceeded"),
                                                        logLevel: LogLevel.Information,
                                                        formatString: "Successfully validated the token.");
        errorProcessingMessage = LoggerMessage.Define(eventId: new EventId(3, "ProcessingMessageFailed"),
                                                      logLevel: LogLevel.Error,
                                                      formatString: "Exception occurred while processing message.");
    }
#pragma warning restore S3963 // "static" fields should be initialized inline

    public static void TokenValidationFailed(this ILogger logger, Exception ex)
        => tokenValidationFailed(logger, ex);

    public static void TokenValidationSucceeded(this ILogger logger)
        => tokenValidationSucceeded(logger, null);

    public static void ErrorProcessingMessage(this ILogger logger, Exception ex)
        => errorProcessingMessage(logger, ex);
}
