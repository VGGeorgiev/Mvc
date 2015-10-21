// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Mvc.ActionConstraints;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNet.Mvc.Logging
{
    public static class DefaultActionSelectorLoggerExtensions
    {
        private static Action<ILogger, string, Exception> _ambiguousActions;
        private static Action<ILogger, string, string, IActionConstraint, Exception> _constraintMismatch;

        static DefaultActionSelectorLoggerExtensions()
        {
            _ambiguousActions = LoggerMessage.Define<string>(
                LogLevel.Error,
                1,
                "Request matched multiple actions resulting in ambiguity. " +
                    "Matching actions: {AmbiguousActions}");
            _constraintMismatch = LoggerMessage.Define<string, string, IActionConstraint>(
                LogLevel.Verbose,
                2,
                "Action '{ActionDisplayName}' with id '{ActionId}' did not match the " +
                                    "constraint '{ActionConstraint}'");
        }

        public static void AmbiguousActions(this ILogger logger, string actionNames)
        {
            _ambiguousActions(logger, actionNames, null);
        }

        public static void ConstraintMismatch(
            this ILogger logger,
            string actionDisplayName,
            string actionId,
            IActionConstraint actionConstraint)
        {
            _constraintMismatch(logger, actionDisplayName, actionId, actionConstraint, null);
        }
    }
}
