using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypesGenerators.BaseTypes;

namespace TypesGenerators.CollectionTypes
{
    public class ListGenerator : ICollectionGenerator
    {
        private readonly ByteValueGenerator _byteValueGenerator;
        private IDictionary<Type, IBaseGenerator> _baseGenerators;

        public Type GenerateType { get; protected set; }

        public ListGenerator(IDictionary<Type, IBaseGenerator> baseGenerators)
        {
            GenerateType = typeof(List<>);
            _baseGenerators = baseGenerators;
            _byteValueGenerator = new ByteValueGenerator();
        }

        public object Generate(Type type)
        {
            IList result = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            if (_baseGenerators.TryGetValue(type, out IBaseGenerator baseGenerator))
            {
                byte listSize = (byte)_byteValueGenerator.Generate();
                for (int i = 0; i < listSize; i++) result.Add(baseGenerator.Generate());
            }
            return result;
        }
    }
}
