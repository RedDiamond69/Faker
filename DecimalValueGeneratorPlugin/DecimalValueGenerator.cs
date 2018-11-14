using System;
using TypesGenerators.BaseTypes;

namespace DecimalValueGeneratorPlugin
{
    public class DecimalValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public DecimalValueGenerator()
        {
            GenerateType = typeof(decimal);
            _random = new Random();
        }

        public object Generate()
        {
            return (decimal)_random.NextDouble();
        }
    }
}
