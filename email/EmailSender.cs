using System;
using System.IO;
using System.Net.Mail;
using interfaces;

public class EmailSender : IEmailSender
{
    public int ClientPort { get; set; }
    public string ClientHost { get; set; }
    public bool IsBodyHtml { get; set; }

    public bool SendEmail(string from, string to, string subject, string body, string attachmentLocation = "")
    {
        var mail = new MailMessage(from, to);
        mail.IsBodyHtml = IsBodyHtml;

        var client = new SmtpClient
        {
            Port = ClientPort,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Host = ClientHost
        };

        mail.Subject = subject;
        mail.Body = body;

        if (attachmentLocation != "")
        {
            AddAttachment(mail, attachmentLocation);
        }

        try
        {
            client.Send(mail);
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    public void AddAttachment(MailMessage mail, string attachmentLocation)
    {
        using (var inputFile = new FileStream(
                 attachmentLocation,
                 FileMode.Open,
                 FileAccess.Read,
                 FileShare.ReadWrite))
        {
            var fileName = Path.GetFileName(attachmentLocation);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            File.Copy(attachmentLocation, fileName);

            var attachment = new Attachment(fileName);

            mail.Attachments.Add(attachment);
        }
    }
}
