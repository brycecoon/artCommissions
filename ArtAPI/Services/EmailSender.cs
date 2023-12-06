using System.Net.Mail;
using System.Net;

namespace ArtAPI.Services;

public class EmailSender : IEmailSender
{

    private readonly IConfiguration _config;
    public EmailSender(IConfiguration config)
    {
        _config = config;
    }
    public Task SendEmailAsync(string email)
    {
        string subject = "Thank you for your Request";
        string message = "Thank you for your request! We will be working on that soon!";
        var emailpassword = _config["mailpassword"];
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("artcommissionmailer@gmail.com", emailpassword)
        };

        return client.SendMailAsync(
            new MailMessage(from: "artcommissionmailer@gmail.com",
                            to: email,
                            subject,
                            message
                            ));
    }
}