using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class FakerConfig : IFakerConfig
    {
        void IFakerConfig.Add<TType, TPropertyType, TGenerator>(Expression<Func<TType, TPropertyType>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
