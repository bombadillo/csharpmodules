using System.Collections.Generic;

public interface IReadCsv
{
    List<string[]> CsvList { get; }
    char Delimiter { get; set; }

    bool ReadFile(string fileName);
    bool ReadFiles(string directory);
}
