using BenchmarkDotNet.Attributes;
/*
|  Method |      Mean |     Error |    StdDev |   Gen0 | Allocated |
|-------- |----------:|----------:|----------:|-------:|----------:|
|  GetInt |  4.652 ns | 0.1708 ns | 0.1678 ns | 0.0051 |      32 B |
| GetList | 21.689 ns | 0.1964 ns | 0.1741 ns | 0.0115 |      72 B |
*/
namespace EmptyList
{
    [MemoryDiagnoser]
    public class TestListNew
    {

        [Benchmark]
        public int[] GetInt()
        {
            var arra = new int[]
            {
             12, 34
            };
            return arra;
        }

        [Benchmark]
        public List<int> GetList()
        {
            var list = new List<int>
             {
              12,34
             };
            return list;
        }

    }
}
