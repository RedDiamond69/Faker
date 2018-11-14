using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesGenerators
{
    public interface ITypesGenerators
    {
        Type GenerateType { get; }
    }
}
