namespace ArtCommissions.Data;

using Microsoft.AspNetCore.Identity;

public class DefaultUserService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public DefaultUserService(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var logger = scope.ServiceProvider.GetRequiredService < ILogger<DefaultUserService>>();

        foreach(var configItem in config.AsEnumerable())
        {
            logger.LogInformation("config key:{key} = {value}", configItem.Key, configItem.Value);
        }

        var username = config[Constants.DefaultAdminUsername];
        var password = config[Constants.DefaultAdminPassword];
        if (username is null || password is null)
        {
            throw new MissingDefaultAdminConfigException();
        }

        var user = await userManager.FindByNameAsync(username);
        if (user is null)
        {
            user = new IdentityUser() { Email = username, UserName = username, EmailConfirmed = true };
            var result = await userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                throw new UnableToCreateDefaultAdminUserException(string.Join("; ", result.Errors.Select(e => e.Description)));

            var adminRole = await roleManager.FindByNameAsync(Constants.AdminRole);
            if (adminRole is null)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = Constants.AdminRole });
            }

            await userManager.AddToRoleAsync(user, Constants.AdminRole);
        }
    }
}
