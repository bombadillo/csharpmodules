using System;
using Interfaces;

public class EmailValidator : IValidateEmails
{
    public bool Validate(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
