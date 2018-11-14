using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerUnitTest.Test
{
    public class CustomClassWithConstructor : CustomClassWithProperty
    {
        public byte ByteValue2 { get; private set; }

        public CustomClassWithConstructor(byte value1, byte value2)
        {
            ByteValue1 = value1;
            someValue = value1;
            ByteValue2 = value2;
        }
    }
}
