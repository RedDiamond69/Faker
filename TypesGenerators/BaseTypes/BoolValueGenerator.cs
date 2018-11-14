using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesGenerators.BaseTypes
{
    public class BoolValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public BoolValueGenerator()
        {
            GenerateType = typeof(bool);
            _random = new Random();
        }

        public object Generate()
        {
            return _random.Next(0, 1) == 1 ? true : false;
        }
    }
}
