using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class FakerConfig : IFakerConfig
    {
        private Dictionary<PropertyInfo, IBaseGenerator> _generators;

        public Dictionary<PropertyInfo, IBaseGenerator> Generators { get => new Dictionary<PropertyInfo, IBaseGenerator>(_generators)}

        public FakerConfig()
        {
            _generators = new Dictionary<PropertyInfo, IBaseGenerator>();
        }

        void IFakerConfig.Add<TType, TPropertyType, TGenerator>(Expression<Func<TType, TPropertyType>> expression)
        {
            Expression expressionBody = expression.Body;
            if (expressionBody.NodeType != ExpressionType.MemberAccess) throw new ArgumentException("Unacceptable expression!\n");
            IBaseGenerator generator = (IBaseGenerator)Activator.CreateInstance(typeof(TGenerator));
            if (!generator.GeneratedType.Equals(typeof(TPropertyType))) throw new ArgumentException("Unacceptable generator!\n");
            generators.Add((PropertyInfo)((MemberExpression)expressionBody).Member, generator);
        }
    }
}
