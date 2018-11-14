using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public interface IFakerConfig
    {
        void Add<TType, TPropertyType, TGenerator>(Expression<Func<TType, TPropertyType>> expression)
            where TType : class, TGenerator : IBaseGenerator, new();

        Dictionary<PropertyInfo, IBaseGenerator> _generators;
    }
}
