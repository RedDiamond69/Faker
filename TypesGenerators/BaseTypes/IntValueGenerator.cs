using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesGenerators.BaseTypes
{
    public class IntValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public IntValueGenerator()
        {
            GenerateType = typeof(int);
            _random = new Random();
        }

        public object Generate()
        {
            return _random.Next();
        }
    }
}
