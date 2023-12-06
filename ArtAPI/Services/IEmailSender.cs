namespace ArtAPI.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email);
    }
}
