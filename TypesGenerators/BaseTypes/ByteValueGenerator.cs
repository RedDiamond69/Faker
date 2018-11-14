using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
