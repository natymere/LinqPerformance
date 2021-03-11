using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace LinqPerformance.Simple
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        private static readonly Samples Samples = new();

        [Benchmark]
        public int AlcoholicDrinksCountLinqWhere() => Samples.AlcoholicDrinksCountLinqWhere();
        
        [Benchmark]
        public int AlcoholicDrinksCountLinqCount() => Samples.AlcoholicDrinksCountLinqCount();
        
        [Benchmark]
        public int AlcoholicDrinksCountForLoop() => Samples.AlcoholicDrinksCountForLoop();
        
        [Benchmark]
        public int AlcoholicDrinksCountForEach() => Samples.AlcoholicDrinksCountForEach();

        [Benchmark]
        public List<string> NonAlcoholicDrinkNamesForLoop() => Samples.NonAlcoholicDrinkNamesForLoop();
        
        [Benchmark]
        public List<string> NonAlcoholicDrinkNamesLinq() => Samples.NonAlcoholicDrinkNamesLinq();
    }
}