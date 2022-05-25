using SpanUndMemory;
using System.Diagnostics;

namespace SpanUndMemoryTests
{
    public class Tests
    {
        byte[] data;
        SpanSample spanSample = new SpanSample();

        [SetUp]
        public void Setup()
        {
            data = new byte[100000000];
            new Random().NextBytes(data);
        }

        [Test]
        public void ArraySumTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            int result = spanSample.ArraySum(data);

            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms: {result}");
            stopwatch.Reset();

            Assert.Pass();
        }

        [Test]
        public void SpanSumTest()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int result = spanSample.SpanSum(data);

            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms: {result}");
            stopwatch.Reset();

            Assert.Pass();
        }
        [Test]
        public void StringParseTest()
        {
            string numbers = "1, 2, 3, 4, 5, 6, 7";

            Stopwatch stopwatch = Stopwatch.StartNew();

            int r1 = spanSample.StringParseSum(numbers);
            Console.WriteLine($"{r1} in {stopwatch.ElapsedTicks}");

            stopwatch.Restart();

            int r2 = spanSample.StringParseSumWithSpan(numbers);
            Console.WriteLine($"{r2} in {stopwatch.ElapsedTicks}");

            Assert.Pass();
        }
    }
}