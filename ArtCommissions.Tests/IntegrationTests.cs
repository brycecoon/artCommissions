using ArtCommissions.Data;
using ArtCommissions.Pages.Client;
using Bunit;
using Bunit.TestDoubles;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArtCommissions.Tests;

public class IntegrationTests : BlazorIntegrationTestContext
{
    [Fact]
    public async Task CanMakeComponent()
    {
        var cut = RenderComponent<CommissionForm>();
        cut.WaitForState(() => cut.Instance.IsDataLoaded, TimeSpan.FromSeconds(5));
        true.Should().Be(true);
    }

    [Fact]
    public async Task CanUploadForm()
    {
        // Arrange
        var cut = RenderComponent<CommissionForm>();
        cut.WaitForState(() => cut.Instance.IsDataLoaded, TimeSpan.FromSeconds(5));

        var nameInput = cut.Find("#nameInput");
        var emailInput = cut.Find("#emailInput");
        var commissiontypeRadio = cut.Find("#exampleRadio1");
        var submitButton = cut.Find("#submit");

        // Act
        nameInput.Change("Test Context");
        emailInput.Change("test@example.com");
        commissiontypeRadio.Change("Pokemon");
        await cut.InvokeAsync(() => submitButton.Click());

        // Assert
        var dbContext = Services.GetRequiredService<PostgresContext>();
        var submittedData = await dbContext.CommissionRequests
            .Where(r => r.Email == "test@example.com")
            .ToListAsync();

        submittedData.Should().NotBeEmpty();

        var request = submittedData.First();
        request.Firstname.Should().Be("Test");
        request.Lastname.Should().Be("Context");
        request.Email.Should().Be("test@example.com");
        request.CommissionType.Should().Be("Pokemon");
    }

    [Fact]
    public async Task t()
    {

    }

    [Fact]
    public async Task t2()
    {

    }
}
