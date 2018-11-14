using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TypesGenerators.ArrayTypes;
using TypesGenerators.BaseTypes;
using TypesGenerators.CollectionTypes;

namespace TypesGenerators
{
    public static class TypesGeneratorsInitialize
    {
        private static void AddGeneratorToDictionary(IBaseGenerator generator, Dictionary<Type, IBaseGenerator> dictionary)
        {
            dictionary.Add(generator.GenerateType, generator);
        }

        public static Dictionary<Type, IBaseGenerator> InitBaseGeneratorsDictionary()
        {
            Dictionary<Type, IBaseGenerator> dictionary = new Dictionary<Type, IBaseGenerator>();
            Parallel.Invoke(() => AddGeneratorToDictionary(new BoolValueGenerator(), dictionary),
                () => AddGeneratorToDictionary(new ByteValueGenerator(), dictionary),
                () => AddGeneratorToDictionary(new DateTimeValueGenerator(), dictionary),
                () => AddGeneratorToDictionary(new CharValueGenerator(), dictionary),
                () => AddGeneratorToDictionary(new DoubleValueGenerator(), dictionary),
                () => AddGeneratorToDictionary(new FloatValueGenerator(), dictionary),
                () => AddGeneratorToDictionary(new IntValueGenerator(), dictionary),
                () => AddGeneratorToDictionary(new LongValueGenerator(), dictionary),
                () => AddGeneratorToDictionary(new SByteValueGenerator(), dictionary),
                () => AddGeneratorToDictionary(new ShortValueGenerator(), dictionary),
                () => AddGeneratorToDictionary(new UIntValueGenerator(), dictionary),
                () => AddGeneratorToDictionary(new ULongValueGenerator(), dictionary),
                () => AddGeneratorToDictionary(new UShortValueGenerator(), dictionary));
            return dictionary;
        }

        public static Dictionary<Type, ICollectionGenerator> InitCollectionGeneratorsDictionary(Dictionary<Type, IBaseGenerator> baseGenerators)
        {
            Dictionary<Type, ICollectionGenerator> dictionary = new Dictionary<Type, ICollectionGenerator>();
            ICollectionGenerator generator = new ListGenerator(baseGenerators);
            dictionary.Add(generator.GenerateType, generator);
            return dictionary;
        }

        public static Dictionary<int, IArrayGenerator> InitArrayGeneratorsDictionary(Dictionary<Type, IBaseGenerator> baseGenerators)
        {
            Dictionary<int, IArrayGenerator> dictionary = new Dictionary<int, IArrayGenerator>();
            IArrayGenerator generator = new SingleRankArrayGenerator(baseGenerators);
            dictionary.Add(generator.ArrayRank, generator);
            return dictionary;
        }
    }
}
