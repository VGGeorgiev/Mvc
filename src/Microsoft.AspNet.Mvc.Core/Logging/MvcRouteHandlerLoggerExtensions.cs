// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.Abstractions;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNet.Mvc.Logging
{
    internal static class MvcRouteHandlerLoggerExtensions
    {
        public static IDisposable ActionScope(this ILogger logger, ActionDescriptor action)
        {
            return logger.BeginScopeImpl(new ActionLogScope(action));
        }

        private class ActionLogScope : ILogValues
        {
            private readonly ActionDescriptor _action;

            public ActionLogScope(ActionDescriptor action)
            {
                if (action == null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                _action = action;
            }

            public IEnumerable<KeyValuePair<string, object>> GetValues()
            {
                return new KeyValuePair<string, object>[]
                {
                    new KeyValuePair<string, object>("ActionId", _action.Id),
                    new KeyValuePair<string, object>("ActionName", _action.DisplayName),
                };
            }

            public override string ToString()
            {
                // We don't include the _action.Id here because it's just an opaque guid, and if
                // you have text logging, you can already use the requestId for correlation.
                return _action.DisplayName;
            }
        }

        private static Action<ILogger, string, Exception> _noMatchingActions;
        private static Action<ILogger, string, Exception> _executingAction;

        private static Func<ILogger, string, IDisposable> _actionScope;

        static MvcRouteHandlerLoggerExtensions()
        {
            _noMatchingActions = LoggerMessage.Define<string>(
                LogLevel.Verbose,
                1,
                "No actions matched the current request with path '{Path}'.");
            _executingAction = LoggerMessage.Define<string>(
                LogLevel.Verbose,
                2,
                "Executing action {ActionName}");
            _actionScope = LoggerMessage.DefineScope<string>(
                "ActionId: {ActionId}");
        }

        public static void NoMatchingActions(this ILogger logger, HttpContext context)
        {
            _noMatchingActions(logger, context.Request.Path, null);
        }

        public static void ExecutingAction(this ILogger logger, string actionName)
        {
            _executingAction(logger, actionName, null);
        }
    }
}
