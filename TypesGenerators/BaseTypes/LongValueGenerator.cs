using System;

namespace TypesGenerators.BaseTypes
{
    public class LongValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public LongValueGenerator()
        {
            GenerateType = typeof(long);
            _random = new Random();
        }

        public object Generate()
        {
            return (long)_random.NextDouble();
        }
    }
}
