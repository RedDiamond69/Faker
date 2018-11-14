using System;

namespace TypesGenerators.BaseTypes
{
    public class UShortValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public UShortValueGenerator()
        {
            GenerateType = typeof(ushort);
            _random = new Random();
        }

        public object Generate()
        {
            return (ushort)_random.Next();
        }
    }
}
