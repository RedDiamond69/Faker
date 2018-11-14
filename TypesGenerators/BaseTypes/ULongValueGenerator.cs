using System;

namespace TypesGenerators.BaseTypes
{
    public class ULongValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public ULongValueGenerator()
        {
            GenerateType = typeof(ulong);
            _random = new Random();
        }

        public object Generate()
        {
            return (ulong)_random.NextDouble();
        }
    }
}
