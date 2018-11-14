using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesGenerators.BaseTypes
{
    public interface IBaseGenerator : ITypesGenerators
    {
        object Generate();
    }
}
