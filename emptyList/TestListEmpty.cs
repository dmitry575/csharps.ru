using BenchmarkDotNet.Attributes;
/*
|  Method |      Mean |     Error |    StdDev |    Median | Allocated |
|-------- |----------:|----------:|----------:|----------:|----------:|
|  GetInt | 0.0073 ns | 0.0117 ns | 0.0098 ns | 0.0000 ns |         - |
| GetList | 0.0027 ns | 0.0041 ns | 0.0036 ns | 0.0009 ns |         - |
*/
namespace EmptyList
{
    [MemoryDiagnoser]
    public class TestListEmpty
    {
        [Benchmark]
        public int[] GetInt()
        {
            return Array.Empty<int>();
        }

        [Benchmark]
        public List<int> GetList()
        {
            return (List<int>)Enumerable.Empty<int>();
        }
    }
}
