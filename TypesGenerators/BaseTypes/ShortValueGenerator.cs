using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesGenerators.BaseTypes
{
    public class ShortValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public ShortValueGenerator()
        {
            GenerateType = typeof(short);
            _random = new Random();
        }

        public object Generate()
        {
            return (short)_random.Next();
        }
    }
}
