using System.Threading;
using System.Globalization;
using Interfaces;

public class StringCapatalizer : ICapatalizeStrings
{
    public string CapatatlizeFirstLetterOfEachWord(string sentence)
    {
        sentence = sentence.ToLower();

        CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        TextInfo textInfo = cultureInfo.TextInfo;

        return textInfo.ToTitleCase(sentence);
    }
}
