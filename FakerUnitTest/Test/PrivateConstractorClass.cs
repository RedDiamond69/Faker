using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerUnitTest.Test
{
    public class PrivateConstractorClass
    {
        public DateTime dateTimeField;
        public List<byte> listField;
        public object objectField;

        private PrivateConstractorClass() { }
    }
}
