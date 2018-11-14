using System;

namespace TypesGenerators.BaseTypes
{
    public class CharValueGenerator : IBaseGenerator
    {
        private readonly Random _random;

        public Type GenerateType { get; protected set; }

        public CharValueGenerator()
        {
            GenerateType = typeof(char);
            _random = new Random();
        }

        public object Generate()
        {
            char[] base64 = new char[4];
            Convert.ToBase64CharArray(inArray: new byte[] { (byte)_random.Next() }, offsetIn: 0, length: 1, outArray: base64, offsetOut: 0);
            return base64[_random.Next(0, 2)];
        }
    }
}
