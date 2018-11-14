using System;

namespace TypesGenerators.CollectionTypes
{
    public interface ICollectionGenerator : ITypesGenerators
    {
        object Generate(Type type);
    }
}
