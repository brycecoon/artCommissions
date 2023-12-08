using ArtCommissions.Data;
using ArtCommissions.Pages.Admin;
using ArtCommissions.Pages.Client;
using Bunit;
using Bunit.TestDoubles;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
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
        var commissiontypeRadio = cut.Find("input[id='exampleRadio1']");
        var submitButton = cut.Find("#submit");


        // Act
        nameInput.Change("Test Context");
        emailInput.Change("test@example.com");
        commissiontypeRadio.Click();
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
        request.CommissionType.Should().Be("~3 hours");
    }

    [Fact]
    public async Task CanChangeCommissionTypeForExampleImage()
    {
        // Arrange
        var cut = RenderComponent<EditArtAndTags>();
        cut.WaitForState(() => cut.Instance.IsDataLoaded, TimeSpan.FromSeconds(5));

        var select = cut.Find("select[class='form-select mb-2']");
        var saveButton = cut.Find("#saveButton");

        // Act
        select.Change("~3 hours");
        await cut.InvokeAsync(() => saveButton.Click());

        // Assert
        var dbContext = Services.GetRequiredService<PostgresContext>();
        var submittedData = await dbContext.ExampleImages
            .Where(c => c.CommissionExample.ArtistId == 1)
            .FirstOrDefaultAsync();

        var selectedClass = await dbContext.CommissionExamples
            .Where(c => c.CommissionType == "~3 hours")
            .FirstOrDefaultAsync();

        submittedData.CommissionExampleId.Should().Be(selectedClass.Id);
    }

    [Fact]
    public async Task CanChangeIsInCarouselForExampleImage()
    {
        // Arrange
        var cut = RenderComponent<EditArtAndTags>();
        cut.WaitForState(() => cut.Instance.IsDataLoaded, TimeSpan.FromSeconds(5));

        var select = cut.Find("input[class='form-check-input carouselSelector']");
        var saveButton = cut.Find("#saveButton");

        // Act
        select.Change("No");
        await cut.InvokeAsync(() => saveButton.Click());

        // Assert
        var dbContext = Services.GetRequiredService<PostgresContext>();
        var submittedData = await dbContext.ExampleImages
            .Where(c => c.CommissionExample.ArtistId == 1)
            .FirstOrDefaultAsync();

        submittedData.IsInCarousel.Should().Be(false);
    }
}
