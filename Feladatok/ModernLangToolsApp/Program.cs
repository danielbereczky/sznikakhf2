using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace ModernLangToolsApp;

public class Program

{
    public static void fillCouncil(Council c)
    {
        c.Add(new Jedi { Name = "Anakin Skywalker", MidiChlorianCount = 999 });
        c.Add(new Jedi { Name = "Obi-Wan Kenobi", MidiChlorianCount = 406 });
        c.Add(new Jedi { Name = "Ashoka Tano", MidiChlorianCount = 659 });
    }

    [Description("Feladat2")]
    static Jedi jediCloner(){
        Jedi jedi = new Jedi() {Name = "Jani",MidiChlorianCount = 100};
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Jedi));
        String fPath = "jedi.txt";
        using (StreamWriter writer = new StreamWriter(fPath)) {
            xmlSerializer.Serialize(writer, jedi);
        }

        //deser
        var serializer = new XmlSerializer(typeof(Jedi));
        var stream = new FileStream("jedi.txt", FileMode.Open);
        var clone = (Jedi)serializer.Deserialize(stream);
        stream.Close();
        return clone;
    }

    static void MesssageReceived(string message) {
        Console.WriteLine(message);
    }

    [Description("Feladat3")]
    private static void delegTest() {
        Council council = new Council();
        council.CouncilChanged += MesssageReceived;
        council.Add(new Jedi {Name = "asd", MidiChlorianCount = 130});
        council.Add(new Jedi {Name = "aaad", MidiChlorianCount = 100});
        council.Remove();
        council.Remove();
    }

    [Description("Feladat4")]
    public static List<Jedi> findLowValueJedis_Delegate(Council c) {
        return c.findLowValJedis_Delegate();
    }

    [Description("Feladat5")]
    public static List<Jedi> findLowValueJedis_Lambda(Council c)
    {
        return c.findUnderThousandMidiChlorian_Lambda();
    }

    [Description("Feladat6")]
    static void test6()
    {
        var employees = new Person[] { new Person("Joe", 20), new Person("Jill", 30) };

        ReportPrinter reportPrinter = new ReportPrinter(
            employees,
            () => Console.WriteLine("Employees"), () => Console.WriteLine("Footer"),Person => $"{Person.Name} (Age: {Person.Age}");

        reportPrinter.PrintReport();
    }
    public static void Main(string[] args)
    {
        Jedi cloneJedi = jediCloner();
        delegTest();

        Council c = new Council();
        fillCouncil(c);
        List<Jedi> lowVals1 = findLowValueJedis_Delegate(c);
        List<Jedi> lowVals2 = findLowValueJedis_Lambda(c);
        test6();
    }
}
