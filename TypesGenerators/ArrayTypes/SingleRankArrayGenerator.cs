using System;
using System.Collections.Generic;
using TypesGenerators.BaseTypes;

namespace TypesGenerators.ArrayTypes
{
    public class SingleRankArrayGenerator : IArrayGenerator
    {
        protected IDictionary<Type, IBaseGenerator> _baseGenerators;
        protected readonly ByteValueGenerator _byteValueGenerator;

        public Type GenerateType { get; protected set; }
        public int ArrayRank { get; protected set; }

        public SingleRankArrayGenerator(IDictionary<Type, IBaseGenerator> baseGenerators)
        {
            GenerateType = typeof(Array);
            _baseGenerators = baseGenerators;
            _byteValueGenerator = new ByteValueGenerator();
            ArrayRank = 1;
        }

        public object Generate(Type type)
        {
            if (_baseGenerators.TryGetValue(type, out IBaseGenerator baseTypeGenerator))
            {
                Array result = Array.CreateInstance(type, (byte)_byteValueGenerator.Generate());
                for (int i = 0; i < result.Length; i++) result.SetValue(baseTypeGenerator.Generate(), i);
                return result;
            }
            else return Array.CreateInstance(type, 0);
        }
    }
}
