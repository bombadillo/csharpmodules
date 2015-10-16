using System.Net.Mail;

public interface IEmailSender
{
    int ClientPort { get; set; }
    string ClientHost { get; set; }
    bool IsBodyHtml { get; set; }

    bool SendEmail(string from, string to, string subject, string body, string attachmentLocation = "");
    void AddAttachment(MailMessage mail, string attachmentLocation);
}
