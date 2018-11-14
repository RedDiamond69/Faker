using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesGenerators.BaseTypes
{
    public class DoubleValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public DoubleValueGenerator()
        {
            GenerateType = typeof(double);
            _random = new Random();
        }

        public object Generate()
        {
            return _random.NextDouble();
        }
    }
}
