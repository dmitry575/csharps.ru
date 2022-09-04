using BenchmarkDotNet.Attributes;

namespace EmptyList
{
    public class TestListEmpty
    {
        [MemoryDiagnoser]
        public class TestList
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
}
