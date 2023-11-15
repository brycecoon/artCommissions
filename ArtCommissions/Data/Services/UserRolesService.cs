namespace ArtCommissions.Data.Services;

public class UserRolesService : IUserRoleService
{
    public bool IsAuthenticated { get; private set; }
    public IEnumerable<string> Roles => _roles;
    private List<string> _roles = new();
    private PostgresContext dbcontext;
    public UserRolesService(PostgresContext context)
    {
        dbcontext = context;
    }

    public Task LookUpUser(string email)
    {
        throw new NotImplementedException();
    }

    public void ResetUser()
    {
        throw new NotImplementedException();
    }
}