using System.Collections.Generic;
using System.IO;
using Interfaces;

public class CsvReader : IReadCsv
{
    public CsvReader()
    {
        CsvList = new List<string[]>();
    }

    public bool ReadFile(string fileName)
    {
        var reader = new StreamReader(File.OpenRead(fileName));
        var csvList = new List<string[]>();

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(Delimiter);

            csvList.Add(values);
        }

        AddToCsvList(csvList);

        return csvList.Count > 0;
    }

    private void AddToCsvList(List<string[]> csvList)
    {
        CsvList.AddRange(csvList);
    }

    public List<string[]> CsvList { get; set; }
    public char Delimiter { get; set; }
}
