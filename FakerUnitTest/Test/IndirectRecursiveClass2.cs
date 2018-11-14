using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerUnitTest.Test
{
    public class IndirectRecursiveClass2
    {
        public IndirectRecursiveClass1 InnerObject { get; set; }

        public IndirectRecursiveClass2(IndirectRecursiveClass1 class1)
        {
            InnerObject = class1;
        }
    }
}
