using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNet.Mvc.Logging
{
    public static class ModeMatchResultLoggerExtensions
    {
        private static Action<ILogger, string, string, Exception> _skippingProcessing;

        static ModeMatchResultLoggerExtensions()
        {
            _skippingProcessing = LoggerMessage.Define<string, string>(
                LogLevel.Verbose,
                1,
                "Skipping processing for tag helper '{TagHelper}' with id '{TagHelperId}'.");
        }

        public static void TagHelperSkippingProcessing(
            this ILogger logger,
            string tagHelper,
            string uniqueId)
        {
            _skippingProcessing(logger, tagHelper, uniqueId, null);
        }
    }
}
