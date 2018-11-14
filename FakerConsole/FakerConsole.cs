using Faker;
using FakerConsole.TestClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
