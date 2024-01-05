using System.Xml;

namespace QuickLap.ResultCollector;

internal static class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Please paste here the test results folder path:");

            string? folderPath = Console.ReadLine();
            if (folderPath is null || !Path.Exists(folderPath))
            {
                Console.WriteLine("The path was not provided or doesn't exist.");
                return;
            }

            string[] testFileResults = Directory.GetFiles(folderPath, "*.trx");

            if (testFileResults.Any())
            {
                var results = new List<Result>();
                foreach (var xmlFile in testFileResults)
                {
                    XmlDocument xmlDoc = new();
                    xmlDoc.Load(xmlFile);

                    var nodeList = xmlDoc.GetElementsByTagName("UnitTestResult");
                    foreach (XmlElement element in nodeList)
                        results.Add(new Result(element));
                }

                var groupedResult = results
                    .GroupBy(r => r.Group)
                    .Select(group => new
                    {
                        TestType = group.Key,
                        AverageDuration = group.Average(r => r.Duration.TotalMilliseconds)
                    })
                    .OrderBy(r => r.TestType);

                WriteGroupedResultsInCsv(groupedResult);
            }
            else
            {
                Console.WriteLine("No test file result was found in the specified folder.");
            }

            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void WriteGroupedResultsInCsv<T>(IEnumerable<T> data)
    {
        var path = $"../../../GroupedResult/{DateTime.UtcNow:yyyy-MMM-dd-HH-mm-ss}.csv";

        using var writer = new StreamWriter(path);
        writer.WriteLine("Test Type,Average Duration in Milliseconds");

        foreach (var item in data)
        {
            var row = string.Join(",", typeof(T).GetProperties().Select(p => p.GetValue(item)));
            writer.WriteLine(row);
        }

        Console.WriteLine($"The results were generated at: {Path.GetFullPath(path)}");
    }
}