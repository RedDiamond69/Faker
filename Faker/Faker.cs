using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Faker : IFaker
    {
        private readonly string defPluginsFolder = "Extensions";

        public Faker() : this(defPluginsFolder, null) { }

        public Faker(string pluginsFolder) : this(pluginsFolder, null) { }

        public Faker(IFakerConfig config) : this(defPluginsFolder, config) { }

        public Faker(string pluginsFolder, IFakerConfig config)
        {

        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        private object Create(Type type)
        {
            object generatedType;

            return generatedType;
        }

        private object CreateByProperties(Type type)
        {
            object generatedType;

            return generatedType;
        }

        private object CreateByConstractor(Type type, ConstructorInfo constructorInfo)
        {
            object generatedType;

            return generatedType;
        }

        private bool CreateByCustomGenerator(PropertyInfo propertyInfo, out object generatedType)
        {

        }

        private bool CreateByCustomGenerator(ParameterInfo parameterInfo, Type type, out object generatedType)
        {

        }

        private bool CreateByCustomGenerator(FieldInfo fieldInfo, out object generatedType)
        {

        }
    }
}
