﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.OpenAI.Models.Services.Orchestrations.AIFiles.Exceptions
{
    public class InvalidAIFileOrchestrationException : Xeption
    {       
        public InvalidAIFileOrchestrationException(string message)
            : base(message)
        { }

        public InvalidAIFileOrchestrationException(
            string message, Xeption innerException)
                : base(message, innerException)
        { }
    }
}
