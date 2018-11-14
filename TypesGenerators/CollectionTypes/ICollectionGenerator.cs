﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypesGenerators.CollectionTypes
{
    public interface ICollectionGenerator : ITypesGenerators
    {
        object Generate(Type type);
    }
}
