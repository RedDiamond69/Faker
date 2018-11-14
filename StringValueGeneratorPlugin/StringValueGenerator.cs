using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypesGenerators.BaseTypes;

namespace StringValueGeneratorPlugin
{
    public class StringValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public StringValueGenerator()
        {
            GenerateType = typeof(string);
            _random = new Random();
        }

        public object Generate()
        {
            byte[] str = new byte[_random.Next(0, byte.MaxValue)];
            _random.NextBytes(str);
            return Convert.ToBase64String(str);
        }
    }
}
