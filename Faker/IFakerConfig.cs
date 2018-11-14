using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TypesGenerators.BaseTypes;

namespace Faker
{
    public interface IFakerConfig
    {
        void Add<TType, TPropertyType, TGenerator>(Expression<Func<TType, TPropertyType>> expression)
            where TType : class
            where TGenerator : IBaseGenerator, new();

        Dictionary<PropertyInfo, IBaseGenerator> Generators { get; }
    }
}
