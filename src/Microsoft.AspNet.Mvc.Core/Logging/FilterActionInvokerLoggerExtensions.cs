// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNet.Mvc.Logging
{
    public static class FilterActionInvokerLoggerExtensions
    {
        private static Action<ILogger, string, Exception> _authorizationFailure;
        private static Action<ILogger, string, Exception> _resourceFilterShortCircuit;
        private static Action<ILogger, string, Exception> _actionFilterShortCircuit;
        private static Action<ILogger, string, Exception> _exceptionFilterShortCircuit;

        static FilterActionInvokerLoggerExtensions()
        {
            _authorizationFailure = LoggerMessage.Define<string>(
                LogLevel.Warning,
                1,
                "Authorization failed for the request at filter '{AuthorizationFilter}'.");
            _resourceFilterShortCircuit = LoggerMessage.Define<string>(
                LogLevel.Verbose,
                2,
                "Request was short circuited at resource filter '{ResourceFilter}'.");
            _actionFilterShortCircuit = LoggerMessage.Define<string>(
                LogLevel.Verbose,
                3,
                "Request was short circuited at action filter '{ActionFilter}'.");
            _exceptionFilterShortCircuit = LoggerMessage.Define<string>(
                LogLevel.Verbose,
                4,
                "Request was short circuited at exception filter '{ExceptionFilter}'.");
        }

        public static void AuthorizationFailure(this ILogger logger, string filterName)
        {
            _authorizationFailure(logger, filterName, null);
        }

        public static void ResourceFilterShortCircuited(this ILogger logger, string filterName)
        {
            _resourceFilterShortCircuit(logger, filterName, null);
        }

        public static void ExceptionFilterShortCircuited(this ILogger logger, string filterName)
        {
            _exceptionFilterShortCircuit(logger, filterName, null);
        }

        public static void ActionFilterShortCircuited(this ILogger logger, string filterName)
        {
            _actionFilterShortCircuit(logger, filterName, null);
        }
    }
}
