using ArtCommissions.Data;
using ArtCommissions.Pages.Client;
using Bunit;
using Bunit.TestDoubles;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArtCommissions.Tests;

public class IntegrationTests : BlazorIntegrationTestContext
{
    [Fact]
    public async Task CanMakeComponent()
    {
        var cut = RenderComponent<CommissionForm>();
    }

    [Fact]
    public async Task CanUploadForm()
    {
        var cut = RenderComponent<CommissionForm>();

        cut.Find("#nameInput").Change("Test Context");
        cut.Find("#emailInput").Change("test@example.com");
        cut.Find("#exampleRadio1").Change("Pokemon");
        await cut.Find("#submit").ClickAsync(new MouseEventArgs());

        var dbContext = Services.GetRequiredService<PostgresContext>();
        var submittedData = await dbContext.CommissionRequests
            .Where(r => r.Email == "test@example.com")
            .ToListAsync();

        submittedData.Should().NotBeEmpty();
        submittedData.First().Firstname.Should().Be("Test");
        submittedData.First().Lastname.Should().Be("Context");
        submittedData.First().Email.Should().Be("test@example.com");
        submittedData.First().Firstname.Should().Be("Test");
        submittedData.First().CommissionType.Should().Be("Pokemon");
    }
}
