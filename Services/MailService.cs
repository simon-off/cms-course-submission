using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace crito.Services;

public class MailService
{
    private string _from;
    private string _smtp;
    private int _port;
    private string _username;
    private string _password;

    public MailService(string from, string smtp, int port, string username, string password)
    {
        _from = from;
        _smtp = smtp;
        _port = port;
        _username = username;
        _password = password;
    }

    public async Task SendAsync(string to, string subject, string body)
    {
        try
        {
            using var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_smtp, _port, SecureSocketOptions.StartTls);
            await smtpClient.AuthenticateAsync(_username, _password);

            var result = await smtpClient.SendAsync(email);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
