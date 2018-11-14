using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FakerConsole.TestClass
{
    [DataContract]
    public class TestClassWithConstructor : TestClassWithProperties
    {
        [DataMember]
        public byte CustomGeneratorCheckProperty2 { get; set; }

        public TestClassWithConstructor(byte byteValue, bool boolValue, byte customGeneratorCheckProperty1, byte customGeneratorCheckProperty2)
        {
            PublicByteSetter = byteValue;
            publicBoolField = boolValue;
            CustomGeneratorCheckProperty1 = customGeneratorCheckProperty1;
            CustomGeneratorCheckProperty2 = customGeneratorCheckProperty2;
        }
    }
}
