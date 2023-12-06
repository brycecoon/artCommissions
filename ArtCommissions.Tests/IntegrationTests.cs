using ArtCommissions.Data;
using ArtCommissions.Pages.Admin;
using ArtCommissions.Pages.Client;
using Bunit;
using Bunit.TestDoubles;
using FluentAssertions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArtCommissions.Tests;

public class IntegrationTests : BlazorIntegrationTestContext
{
    [Fact]
    public async Task CanMakeComponent()
    {
        var cut = RenderComponent<CommissionForm>();
    }

    [Fact]
    public async void UserCanLogInAndSeePage()
    {
        var authContext = this.AddTestAuthorization();
        var cut = RenderComponent<ClientList>();

        //var errorMessage = cut.WaitForElement("h1");
        //errorMessage.InnerHtml.Should().Be("Log In");

        // Log in
        //authContext.SetRoles(Constants.AdminRole);
        //authContext.SetAuthorized("employee@snow.edu");
        //var button = cut.WaitForElement("button");
        //button.InnerHtml.Should().Be("this works");
    }
}




/*using Bunit;

using Bunit.TestDoubles;

using FactoryWorx.Pages;

using FactoryWorx.Pages.Employee;

using FactoryWorx.Pages.Manager;

using FluentAssertions;

using Microsoft.AspNetCore.Components.Web;
 
namespace BlazorTests;

public class IntegrationTests : BlazorIntegrationTestContext

{

    [Fact]

    public async void UserCanLogInAndSeePage()

    {

        var authContext = this.AddTestAuthorization();

        var cut = RenderComponent<TimeClock>();

        var errorMessage = cut.WaitForElement("p");

        errorMessage.InnerHtml.Should().Be("Access Denied.");

        // Log in

        authContext.SetRoles(Constants.EmployeeRole);

        authContext.SetAuthorized("employee@snow.edu");

        var button = cut.WaitForElement("button");

        button.InnerHtml.Should().Be("Time Clock");

    }

    [Fact]

    public async void EmployeeCanClockInWithButton()

    {

        var authContext = this.AddTestAuthorization();

        authContext.SetRoles(Constants.EmployeeRole);

        authContext.SetAuthorized("employee@snow.edu");

        var cut = RenderComponent<TimeClock>();

        var button = cut.WaitForElement("button");

        await button.ClickAsync(new MouseEventArgs());

        var success = cut.WaitForElement("p");

        success.InnerHtml.Should().Be("Default Employee successfully clocked IN.");

    }

    [Fact]

    public async void ClockedInEmployeeCanClockOutWithButton()

    {

        var authContext = this.AddTestAuthorization();

        authContext.SetRoles(Constants.EmployeeRole);

        authContext.SetAuthorized("employee@snow.edu");

        var cut = RenderComponent<TimeClock>();

        var button = cut.WaitForElement("button");

        await button.ClickAsync(new MouseEventArgs());

        var success = cut.WaitForElement("p");

        success.InnerHtml.Should().Be("Default Employee successfully clocked IN.");

        await button.ClickAsync(new MouseEventArgs());

        success.InnerHtml.Should().Be("Default Employee successfully clocked OUT.");

    }

    [Fact]

    public async void ModifyShiftTemplateCanChangeEmployeeDemand()

    {

        var authContext = this.AddTestAuthorization();

        authContext.SetRoles(Constants.ManagerRole);

        //render the component for the shift template

        var cut = RenderComponent<ModifyShiftTemplate>();

        var button = cut.WaitForElement("tr button");

        button.Click();

        var input = cut.WaitForElement("tr input");

        input.Change("99");

        var saveButton = cut.Find("tr button");

        await saveButton.ClickAsync(new MouseEventArgs());

        var employeeDemandTD = cut.Find("tr .EmployeeDemand");

        employeeDemandTD.InnerHtml.Should().Be("99");

    }

    [Fact]

    public async void ManagerCanCreateShiftBasedOnTemplateAndInput()

    {

        var authContext = this.AddTestAuthorization();

        authContext.SetRoles(Constants.ManagerRole);

        var cut = RenderComponent<CreateShift>();

        var input = cut.WaitForElement("div input");

        var shift = cut.WaitForElement("div select");

        var button = cut.WaitForElement("div button");

        input.Change("2023-10-31");

        shift.Change("1 - Day");

        cut.WaitForState(() => !button.HasAttribute("disabled"));

        button.Click();

        var success = cut.WaitForElement("p");

        success.InnerHtml.Should().Be("Shift Created Successfully");

    }

}*/