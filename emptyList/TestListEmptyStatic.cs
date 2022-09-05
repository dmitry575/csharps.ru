

using BenchmarkDotNet.Attributes;

/**
|  Method |      Mean |     Error |    StdDev |    Median | Allocated |
|-------- |----------:|----------:|----------:|----------:|----------:|
|  GetInt | 0.0073 ns | 0.0117 ns | 0.0098 ns | 0.0000 ns |         - |
| GetList | 0.0027 ns | 0.0041 ns | 0.0036 ns | 0.0009 ns |         - |
*/
namespace EmptyList
{
    public class EmptyResults
    {
        public static int[] EmptyArray = new int[0];
        public static List<int> EmptyList = new List<int>();
    }
    [MemoryDiagnoser]
    public class TestListEmptyStatic
    {

        [Benchmark]
        public int[] GetInt()
        {
            return EmptyResults.EmptyArray;
        }

        [Benchmark]
        public List<int> GetList()
        {
            return EmptyResults.EmptyList;
        }

    }
}
