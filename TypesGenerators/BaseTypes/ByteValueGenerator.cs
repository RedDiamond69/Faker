using System;

namespace TypesGenerators.BaseTypes
{
    public class ByteValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public ByteValueGenerator()
        {
            GenerateType = typeof(byte);
            _random = new Random();
        }

        public object Generate()
        {
            return (byte)_random.Next();
        }
    }
}
