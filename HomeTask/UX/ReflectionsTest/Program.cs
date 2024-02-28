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

            var time = TimeMeasureHelper.Measure(() => stringForSerialization = test.MySerializationTest(serializer, classForTest, 500));
            Console.WriteLine($"Сериализованная строка: {stringForSerialization}");
            Console.WriteLine(BuildTimespanMessage(time, "потрачено на 500 сериализаций"));

            time = TimeMeasureHelper.Measure(() => classForTest = test.MyDeserializationTest<ClassForTests>(serializer, stringForSerialization, 500));

            Console.WriteLine(BuildTimespanMessage(time, "потрачено на 500 десериализаций"));

            time = TimeMeasureHelper.Measure(() => Console.WriteLine("Замер вывода в консоль"));

            Console.WriteLine(BuildTimespanMessage(time, "потрачено на вывод строки в консоль"));
            Console.WriteLine("******************************************");
            Console.WriteLine("Сериализация в JSON");
            Console.WriteLine("******************************************");
            serializer = new MyJsonSerializer();
            time = TimeMeasureHelper.Measure(() => stringForSerialization = test.MySerializationTest(serializer, classForTest, 500));
            Console.WriteLine($"Сериализованная строка: {stringForSerialization}");
            Console.WriteLine(BuildTimespanMessage(time, "потрачено на 500 сериализаций"));

            time = TimeMeasureHelper.Measure(() => classForTest = test.MyDeserializationTest<ClassForTests>(serializer, stringForSerialization, 500));

            Console.WriteLine(BuildTimespanMessage(time, "потрачено на 500 десериализаций"));

            Console.ReadKey();
        }

        private static string BuildTimespanMessage(TimeSpan t, string message)
        {
            return $"{t.ToString()} {message}";
        }
    }
}
