using System;
using BenchmarkDotNet.Running;
using Bogus;

namespace LinqPerformance.Simple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Randomizer.Seed = new Random(420);
            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}