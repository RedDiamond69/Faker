using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
