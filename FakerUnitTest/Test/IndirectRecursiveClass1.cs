using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerUnitTest.Test
{
    public class IndirectRecursiveClass1
    {
        public IndirectRecursiveClass2 InnerObject { get; set; }

        public IndirectRecursiveClass1(IndirectRecursiveClass2 class2)
        {
            InnerObject = class2;
        }
    }
}
