using ArtCommissions.Data;
using ArtCommissions.Pages.Client;
using Bunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtCommissions.Tests;

public class IntegrationTests : TestContext
{
    [Fact]
    public async Task CanMakeComponent()
    {
        var cut = RenderComponent<CommissionForm>();
    }
}
