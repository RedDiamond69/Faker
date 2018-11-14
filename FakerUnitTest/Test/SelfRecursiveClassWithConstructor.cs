namespace FakerUnitTest.Test
{
    public class SelfRecursiveClassWithConstructor
    {
        public SelfRecursiveClassWithConstructor innerObject;

        public SelfRecursiveClassWithConstructor(SelfRecursiveClassWithConstructor inner)
        {
            innerObject = inner;
        }
    }
}
