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
    public class FakerConfig : IFakerConfig
    {
        protected Dictionary<PropertyInfo, IBaseGenerator> _generators;

        public Dictionary<PropertyInfo, IBaseGenerator> Generators { get => new Dictionary<PropertyInfo, IBaseGenerator>(_generators); }

        public FakerConfig()
        {
            _generators = new Dictionary<PropertyInfo, IBaseGenerator>();
        }

        public void Add<TType, TPropertyType, TGenerator>(Expression<Func<TType, TPropertyType>> expression)
            where TType : class
            where TGenerator : IBaseGenerator, new()
        {
            Expression expressionBody = expression.Body;
            if (expressionBody.NodeType != ExpressionType.MemberAccess)
            {
                throw new ArgumentException("Invalid expression!\n");
            }
            IBaseGenerator generator = (IBaseGenerator)Activator.CreateInstance(typeof(TGenerator));
            if (!generator.GenerateType.Equals(typeof(TPropertyType)))
            {
                throw new ArgumentException("Invalid generator!\n");
            }
            _generators.Add((PropertyInfo)((MemberExpression)expressionBody).Member, generator);
        }
    }
}
