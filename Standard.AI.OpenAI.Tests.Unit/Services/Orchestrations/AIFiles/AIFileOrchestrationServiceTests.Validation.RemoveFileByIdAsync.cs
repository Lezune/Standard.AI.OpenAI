﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Standard.AI.OpenAI.Models.Services.Foundations.AIFiles;
using Standard.AI.OpenAI.Models.Services.Orchestrations.AIFiles.Exceptions;
using Xunit;

namespace Standard.AI.OpenAI.Tests.Unit.Services.Orchestrations.AIFiles;

public partial class AIFileOrchestrationServiceTests
{
    [Theory]
    [InlineData(null)]
    private async Task ShouldThrowValidationExceptionOnRemoveFileIfFileIdIsInvalid(string invalidFileId)
    {
        // given
        var invalidAiFileOrchestrationException =
            new InvalidAIFileOrchestrationException(
                message: "AI file is invalid.");

        invalidAiFileOrchestrationException.AddData(
            key: nameof(AIFile.Response.Id),
            values: "Value is required");

        var expectedAIFileOrchestrationValidationException =
            new AIFileOrchestrationValidationException(
                message: "AI file validation error occurred, fix errors and try again.",
                    innerException: invalidAiFileOrchestrationException);

        // when 
        ValueTask<AIFile> removeFileTask =
            this.aiFileOrchestrationService.RemoveFileByIdAsync(
                invalidFileId);

        AIFileOrchestrationValidationException
            actualAIFileOrchestrationValidationException =
                await Assert.ThrowsAsync<AIFileOrchestrationValidationException>(
                    removeFileTask.AsTask);

        // then
        actualAIFileOrchestrationValidationException.Should().BeEquivalentTo(
            expectedAIFileOrchestrationValidationException);

        this.aiFileServiceMock.VerifyNoOtherCalls();
        this.localFileServiceMock.VerifyNoOtherCalls();
    }
}