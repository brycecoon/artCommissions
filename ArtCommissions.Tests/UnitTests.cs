using ArtCommissions.Data;
using Bunit;
using Bunit.TestDoubles;
using FluentAssertions;
using Moq;
using static ArtCommissions.Pages.Client.CommissionForm;

namespace ArtCommissions.Tests;

public class AdminTests : BlazorUnitTestContext
{
    [Fact]
    public async Task FormNotSubmitted_When_NameFieldNotFilled()
    {
        var mockContext = new Mock<PostgresContext>();
        //mockContext.Setup(m => m.AddAsync(It.IsAny<CommissionRequest>()));
        

        Form f = new(mockContext.Object);

        f.Name = null;
        f.Email = "example@test.com";
        f.CommissionDetails = "the deets";
        f.SelectedType = "Icon";

        await f.CreateNewRequest();
    }
}