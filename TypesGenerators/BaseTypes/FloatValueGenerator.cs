using System;

namespace TypesGenerators.BaseTypes
{
    public class FloatValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public FloatValueGenerator()
        {
            GenerateType = typeof(float);
            _random = new Random();
        }

        public object Generate()
        {
            return (float)_random.NextDouble();
        }
    }
}
