using Faker;
using FakerConsole.Serializer;
using FakerConsole.TestClass;
using System;
using TypesGenerators.Custom;

namespace FakerConsole
{
    class FakerConsole
    {
        static void Main(string[] args)
        {
            FakerConfig config = new FakerConfig();
            config.Add<TestClassWithProperties, byte, ByteNotRandomGenerator>(exspression => exspression.CustomGeneratorCheckProperty1);
            config.Add<TestClassWithConstructor, byte, ByteNotRandomGenerator>(exspression => exspression.CustomGeneratorCheckProperty2);
            Faker.Faker faker = new Faker.Faker(config);
            ConsoleJsonSerializer.Serialize(faker.Create<TestClassWithProperties>());
            Console.WriteLine();
            ConsoleJsonSerializer.Serialize(faker.Create<TestClassWithConstructor>());

            Console.ReadKey();
        }
    }
}
