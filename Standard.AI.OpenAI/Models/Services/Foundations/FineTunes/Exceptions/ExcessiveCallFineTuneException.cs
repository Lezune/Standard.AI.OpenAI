﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.OpenAI.Models.Services.Foundations.FineTunes.Exceptions
{
    public class ExcessiveCallFineTuneException : Xeption
    {
        public ExcessiveCallFineTuneException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}