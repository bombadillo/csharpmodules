using System;
using System.Configuration;
using Interfaces;

public class PhoneNumberValidater : IValidatePhoneNumbers
{
    private readonly ILog Logger;

    public PhoneNumberValidater(ILog logger)
    {
        Logger = logger;
    }

    public bool ValidateNumber(string number)
    {
        if (!IsNumeric(number))
        {
            return false;
        }

        try
        {
            var meetsMinimumLength = number.Length > Convert.ToInt32(ConfigurationManager.AppSettings["MinPhoneNumberLength"]);
            var meetsMaximumLength = number.Length <= Convert.ToInt32(ConfigurationManager.AppSettings["MaxPhoneNumberLength"]);
            return meetsMinimumLength && meetsMaximumLength;
        }
        catch (Exception)
        {
            Logger.Info(string.Format("Number {0} is not valid", number));

            return false;
        }
    }
}
