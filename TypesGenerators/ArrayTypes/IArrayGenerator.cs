using TypesGenerators.CollectionTypes;

namespace TypesGenerators.ArrayTypes
{
    public interface IArrayGenerator : ICollectionGenerator
    {
        int ArrayRank { get; }
    }
}
