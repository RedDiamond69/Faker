using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
