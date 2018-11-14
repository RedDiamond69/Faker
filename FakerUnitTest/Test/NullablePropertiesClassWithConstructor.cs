using System;

namespace FakerUnitTest.Test
{
    public class NullablePropertiesClassWithConstructor : NullablePropertiesClassNoConstructor
    {
        public NullablePropertiesClassWithConstructor(DateTime dateTime)
        {
            DateTimeProperty = dateTime;
        }
    }
}
