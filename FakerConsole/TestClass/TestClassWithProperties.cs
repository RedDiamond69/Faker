using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.Threading.Tasks;

namespace FakerConsole.TestClass
{
    [DataContract]
    public class TestClassWithProperties
    {
        [DataMember]
        public bool publicBoolField;

        [DataMember]
        protected bool notPublicBoolField;

        [DataMember]
        public byte PublicByteSetter { get; set; }

        [DataMember]
        public byte NotPublicByteSetter { get; protected set; }

        [DataMember]
        private readonly byte notPublicByteField;

        [DataMember]
        public List<byte> publicList;

        [DataMember]
        public TestClassWithProperties nestedObject;

        [DataMember]
        public byte CustomGeneratorCheckProperty1 { get; set; }

        public TestClassWithProperties() { }
    }
}
