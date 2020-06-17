// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RulesEngine.Exceptions
{
    [Serializable]
    public class RuleValidationException : ValidationException
    {
        public RuleValidationException(string message, IEnumerable<ValidationFailure> errors) : base(message, errors)
        {
        }
        public RuleValidationException(string message) : base(message) => throw new NotImplementedException();

        public RuleValidationException() : base("") => throw new NotImplementedException();


        public RuleValidationException(string message, Exception innerException) : base(message, (IEnumerable<ValidationFailure>)innerException)
        {
            throw new NotImplementedException();
        }

        protected RuleValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base("") => throw new NotImplementedException();
       
    }
}
