using System.Collections.Generic;

namespace FakerUnitTest.Test
{
    public class NullableFieldsClassWithConstructor : NullableFieldsClassNoConstructor
    {
        public NullableFieldsClassWithConstructor(List<byte> list)
        {
            listField = list;
        }
    }
}
