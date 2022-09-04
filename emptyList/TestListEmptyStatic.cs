

using BenchmarkDotNet.Attributes;

namespace EmptyList
{
    public class EmptyResults
    {
        public static int[] EmptyArray = new int[0];
        public static List<int> EmptyList = new List<int>();
    }
    public class TestListEmptyStatic
    {
        [MemoryDiagnoser]
        public class TestList
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
}
