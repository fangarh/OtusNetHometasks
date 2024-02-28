using BusinessContracts;
using BusinessObjects;
using Logic;
using Logic.Serialization;

namespace ReflectionsTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, OTUS!");

            HomeTaskTests test = new HomeTaskTests();
            string stringForSerialization = "";
            ClassForTests classForTest = new ClassForTests { SomeText = "!!! Test", SomeDouble = 123.12, SomeField1 = 555};
            IMySerializer serializer = new MySerializer();
            Console.WriteLine("******************************************");
            Console.WriteLine("Рукописная сериализация");
            Console.WriteLine("******************************************");

            var time = TimeMeasureHelper.Measure(() => stringForSerialization = test.MySerializationTest(serializer, classForTest, Constants.TestCount));
            Console.WriteLine($"Сериализованная строка: ");
            Console.WriteLine($"{stringForSerialization}");
            Console.WriteLine(BuildTimespanMessage(time, $"потрачено на {Constants.TestCount} сериализаций"));

            time = TimeMeasureHelper.Measure(() => classForTest = test.MyDeserializationTest<ClassForTests>(serializer, stringForSerialization, Constants.TestCount));

            Console.WriteLine(BuildTimespanMessage(time, $"потрачено на {Constants.TestCount} десериализаций"));

            time = TimeMeasureHelper.Measure(() => Console.WriteLine("Замер вывода в консоль"));

            Console.WriteLine(BuildTimespanMessage(time, "потрачено на вывод строки в консоль"));
            Console.WriteLine("******************************************");
            Console.WriteLine("Сериализация в JSON");
            Console.WriteLine("******************************************");
            serializer = new MyJsonSerializer();
            time = TimeMeasureHelper.Measure(() => stringForSerialization = test.MySerializationTest(serializer, classForTest, Constants.TestCount));
            Console.WriteLine($"Сериализованная строка: {stringForSerialization}");
            Console.WriteLine(BuildTimespanMessage(time, $"потрачено на {Constants.TestCount} сериализаций"));

            time = TimeMeasureHelper.Measure(() => classForTest = test.MyDeserializationTest<ClassForTests>(serializer, stringForSerialization, Constants.TestCount));

            Console.WriteLine(BuildTimespanMessage(time, $"потрачено на {Constants.TestCount} десериализаций"));

            Console.ReadKey();
        }

        private static string BuildTimespanMessage(TimeSpan t, string message)
        {
            return $"{t.Seconds}сек {t.Milliseconds}мс {message}";
        }
    }
}
