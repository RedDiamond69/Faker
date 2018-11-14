namespace TypesGenerators.Custom
{
    public interface INotRandomGenerator : ITypesGenerators
    {
        byte GenerateValue { get; }
    }
}
