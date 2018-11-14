using System;
using TypesGenerators.BaseTypes;

namespace TypesGenerators.Custom
{
    public class ByteNotRandomGenerator : IBaseGenerator, INotRandomGenerator
    {
        public static byte DefaultGeneratedValue { get => 255; }
        public Type GenerateType { get; protected set; }
        public byte GenerateValue { get; protected set; }

        public ByteNotRandomGenerator()
            : this(DefaultGeneratedValue)
        { }

        public ByteNotRandomGenerator(byte generatedValue)
        {
            GenerateType = typeof(byte);
            GenerateValue = generatedValue;
        }

        public object Generate()
        {
            return GenerateValue;
        }
    }
}
