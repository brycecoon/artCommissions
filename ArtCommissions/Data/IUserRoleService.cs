namespace ArtCommissions.Data;

public interface IUserRoleService
{
    public bool IsAuthenticated { get; }
    public IEnumerable<string> Roles { get; }
    public Task LookUpUser(string email);
    public void ResetUser();
}