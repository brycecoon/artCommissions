using System.Data.Entity;

namespace ArtCommissions.Data.Services;

public class UserRolesService : IUserRoleService
{
    public bool IsAuthenticated { get; private set; }
    public IEnumerable<string> Roles => _roles;
    private List<string> _roles = new();
    private PostgresContext _context;
    public UserRolesService(PostgresContext context)
    {
        _context = context;
    }

    public Task LookUpUser(string email)
    {
        if (email is not null)
        {
            var customer = _context.CommissionRequests.FirstOrDefaultAsync(c => c.Email == email);

            if (customer == null) { 
                // Make New Customer
            }
        }

        throw new NotImplementedException();
    }

    public void ResetUser()
    {
        throw new NotImplementedException();
    }
}