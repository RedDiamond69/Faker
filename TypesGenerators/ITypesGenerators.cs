using System;

namespace TypesGenerators
{
    public interface ITypesGenerators
    {
        Type GenerateType { get; }
    }
}
