// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using RulesEngine.HelperFunctions;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core.CustomTypeProviders;

namespace RulesEngine
{
    public class CustomTypeProvider : DefaultDynamicLinqCustomTypeProvider
    {
        private readonly HashSet<Type> _types;
        public CustomTypeProvider(Type[] types) : base()
        {
            HashSet<Type> hashSets = new HashSet<Type>(types ?? Array.Empty<Type>())
            {
                typeof(ExpressionUtils)
            };
            _types = hashSets;
        }

        public override HashSet<Type> GetCustomTypes()
        {
            return _types;
        }
    }
}
