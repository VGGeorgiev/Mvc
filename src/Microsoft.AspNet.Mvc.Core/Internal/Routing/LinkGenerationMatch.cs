// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc.Routing;

namespace Microsoft.AspNet.Mvc.Internal.Routing
{
    public struct LinkGenerationMatch
    {
        private readonly bool _isFallbackMatch;
        private readonly AttributeRouteLinkGenerationEntry _entry;
        private readonly IDictionary<string, object> _routeValues;

        public LinkGenerationMatch(
            AttributeRouteLinkGenerationEntry entry,
            bool isFallbackMatch,
            IDictionary<string, object> routeValues)
        {
            _entry = entry;
            _isFallbackMatch = isFallbackMatch;
            _routeValues = routeValues;
        }

        public AttributeRouteLinkGenerationEntry Entry { get { return _entry; } }

        public bool IsFallbackMatch { get { return _isFallbackMatch; } }

        public IDictionary<string, object> RouteValues { get { return _routeValues; } }

        public int ParameterCount { get {
                var routeValues = _routeValues;
                return Entry.Template.Parameters.Count(p => routeValues.ContainsKey(p.Name));
            } }

        public int DefaultParameters { get
            {
                var routeValues = _routeValues;
                return Entry.Defaults.Count(p => routeValues.ContainsKey(p.Key));
            } }
    }
}