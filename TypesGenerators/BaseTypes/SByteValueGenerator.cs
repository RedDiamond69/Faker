using System;

namespace TypesGenerators.BaseTypes
{
    public class SByteValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public SByteValueGenerator()
        {
            GenerateType = typeof(sbyte);
            _random = new Random();
        }

        public object Generate()
        {
            return (sbyte)_random.Next();
        }
    }
}
