using ArtCommissions.Data;
using BootstrapBlazor.Components;
using Bunit;
using Bunit.TestDoubles;
using FluentAssertions;
using Moq;

namespace ArtCommissions.Tests;

public class AdminTests
{
    [Fact]
    public async Task FormSuccessfullySubmitted()
    {
        // Arrange
        var mockForm = new Mock<Form>(); // Assuming Form is not sealed and allows mocking

        mockForm.Setup(f => f.SaveFileToDatabase(It.IsAny<CommissionRequest>())).Returns(Task.CompletedTask).Verifiable();

        Form f = mockForm.Object;
        f.Name = "mweep joe";
        f.Email = "example@test.com";
        f.CommissionDetails = "the deets";
        f.SelectedType = "Icon";

        // Act
        await f.CreateNewRequest();

        // Assert
        mockForm.VerifyAll();
    }

    [Fact]
    public async Task FormSumittetFails_When_NameNotInput()
    {
        // Arrange
        var mockForm = new Mock<Form>(); // Assuming Form is not sealed and allows mocking

        mockForm.Setup(f => f.SaveFileToDatabase(It.IsAny<CommissionRequest>())).Returns(Task.CompletedTask).Verifiable();

        Form f = mockForm.Object;
        f.Name = null;
        f.Email = "example@test.com";
        f.CommissionDetails = "the deets";
        f.SelectedType = "Icon";

        // Act
        await f.CreateNewRequest();

        // Assert
        mockForm.Verify(f => f.SaveFileToDatabase(It.IsAny<CommissionRequest>()), Times.Never());
    }

    [Fact]
    public async Task FormSumittetFails_When_EmailNotInput()
    {
        // Arrange
        var mockForm = new Mock<Form>(); // Assuming Form is not sealed and allows mocking

        mockForm.Setup(f => f.SaveFileToDatabase(It.IsAny<CommissionRequest>())).Returns(Task.CompletedTask).Verifiable();

        Form f = mockForm.Object;
        f.Name = "mweep joe";
        f.Email = "";
        f.CommissionDetails = "the deets";
        f.SelectedType = "Icon";

        // Act
        await f.CreateNewRequest();

        // Assert
        mockForm.Verify(f => f.SaveFileToDatabase(It.IsAny<CommissionRequest>()), Times.Never());
    }

    [Fact]
    public async Task FormSumittetFails_When_EmailInputNotValid()
    {
        // Arrange
        var mockForm = new Mock<Form>(); // Assuming Form is not sealed and allows mocking

        mockForm.Setup(f => f.SaveFileToDatabase(It.IsAny<CommissionRequest>())).Returns(Task.CompletedTask).Verifiable();

        Form f = mockForm.Object;
        f.Name = "mweep joe";
        f.Email = "dummy :)";
        f.CommissionDetails = "the deets";
        f.SelectedType = "Icon";

        // Act
        await f.CreateNewRequest();

        // Assert
        mockForm.Verify(f => f.SaveFileToDatabase(It.IsAny<CommissionRequest>()), Times.Never());
    }

    [Fact]
    public async Task FormSumittetFails_When_CommissionTypeNotSelected()
    {
        // Arrange
        var mockForm = new Mock<Form>(); // Assuming Form is not sealed and allows mocking

        mockForm.Setup(f => f.SaveFileToDatabase(It.IsAny<CommissionRequest>())).Returns(Task.CompletedTask).Verifiable();

        Form f = mockForm.Object;
        f.Name = "mweep joe";
        f.Email = "example@test.com";
        f.CommissionDetails = "the deets";
        f.SelectedType = null;

        // Act
        await f.CreateNewRequest();

        // Assert
        mockForm.Verify(f => f.SaveFileToDatabase(It.IsAny<CommissionRequest>()), Times.Never());
    }
}