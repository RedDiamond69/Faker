using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesGenerators.BaseTypes
{
    public class LongValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public LongValueGenerator()
        {
            GenerateType = typeof(long);
            _random = new Random();
        }

        public object Generate()
        {
            return (long)_random.NextDouble();
        }
    }
}
