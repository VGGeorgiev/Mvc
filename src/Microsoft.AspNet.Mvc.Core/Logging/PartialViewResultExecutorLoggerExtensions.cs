using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNet.Mvc.Logging
{
    public static class PartialViewResultExecutorLoggerExtensions
    {
        private static Action<ILogger, string, Exception> _partialViewFound;
        private static Action<ILogger, string, IEnumerable<string>, Exception> _partialViewNotFound;

        static PartialViewResultExecutorLoggerExtensions()
        {
            _partialViewFound = LoggerMessage.Define<string>(
                LogLevel.Verbose,
                1,
                "The partial view '{PartialViewName}' was found.");
            _partialViewNotFound = LoggerMessage.Define<string, IEnumerable<string>>(
                LogLevel.Error,
                2,
                "The partial view '{PartialViewName}' was not found. Searched locations: {SearchedViewLocations}");
        }

        public static void PartialViewFound(
            this ILogger logger, 
            string partialViewName)
        {
            _partialViewFound(logger, partialViewName, null);
        }

        public static void PartialViewNotFound(
            this ILogger logger, 
            string partialViewName, 
            IEnumerable<string> searchedLocations)
        {
            _partialViewNotFound(logger, partialViewName, searchedLocations, null);
        }
    }
}
