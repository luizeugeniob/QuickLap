using System.Globalization;
using System.Xml;

namespace QuickLap.ResultCollector;

public class Result
{
    public Result(XmlElement element)
    {
        TestName = element.GetAttribute("testName");
        Duration = TimeSpan.Parse(element.GetAttribute("duration"), CultureInfo.InvariantCulture);
    }

    public string TestName { get; set; }
    public TimeSpan Duration { get; set; }

    public string Group
    {
        get
        {
            var testNameSplitted = TestName.Split(".");

            return testNameSplitted[2] + testNameSplitted[3];
        }
    }
}