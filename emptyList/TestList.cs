using BenchmarkDotNet.Attributes;
/**
|  Method |     Mean |     Error |    StdDev |   Gen0 | Allocated |
|-------- |---------:|----------:|----------:|-------:|----------:|
|  GetInt | 3.748 ns | 0.1605 ns | 0.1423 ns | 0.0038 |      24 B |
| GetList | 5.959 ns | 0.0615 ns | 0.0513 ns | 0.0051 |      32 B |
*/
namespace EmptyList
{
    [MemoryDiagnoser]
    public class TestList
    {
        [Benchmark]
        public int[] GetInt()
        {
            var arra = new int[0];
            return arra;
        }

        [Benchmark]
        public List<int> GetList()
        {
            var list = new List<int>();
            return list;
        }
    }
}
