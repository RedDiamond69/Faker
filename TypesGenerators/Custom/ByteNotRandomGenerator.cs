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
        public static int DefaultGeneratedValue { get => 255; }
        public Type GenerateType { get; protected set; }
        public int GenerateValue { get; protected set; }

        public ByteNotRandomGenerator()
            : this(DefaultGeneratedValue)
        { }

        public ByteNotRandomGenerator(int generatedValue)
        {
            GenerateType = typeof(int);
            GenerateValue = generatedValue;
        }

        public object Generate()
        {
            return GenerateValue;
        }
    }
}
