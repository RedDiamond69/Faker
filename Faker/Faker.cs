using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TypesGenerators.ArrayTypes;
using TypesGenerators.BaseTypes;
using TypesGenerators.CollectionTypes;

namespace Faker
{
    public class Faker : IFaker
    {
        private Dictionary<Type, IBaseGenerator> _baseGenerators;
        private Dictionary<Type, ICollectionGenerator> _collectionGenerators;
        private Dictionary<int, IArrayGenerator> _arrayGenerators;
        private Dictionary<PropertyInfo, IBaseGenerator> _customGenerators;
        private Stack<Type> _generatedTypesStack;
        private static readonly string _defPluginsFolder = "Extensions";

        public Faker() : this(_defPluginsFolder, null) { }

        public Faker(string pluginsFolder) : this(pluginsFolder, null) { }

        public Faker(IFakerConfig config) : this(_defPluginsFolder, config) { }

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
            if (_baseGenerators.TryGetValue(type, out IBaseGenerator baseGenerator)) generatedType = baseGenerator.Generate();
            else 
            if (type.IsGenericType && 
                _collectionGenerators.TryGetValue(type.GetGenericTypeDefinition(), 
                out ICollectionGenerator collectionGenerator)) generatedType = collectionGenerator.Generate(type.GenericTypeArguments[0]);
            else 
            if (type.IsArray && 
                _arrayGenerators.TryGetValue(type.GetArrayRank(), 
                out IArrayGenerator arrayGenerator)) generatedType = arrayGenerator.Generate(type.GetElementType());
            else 
            if (type.IsClass && 
                !type.IsGenericType && 
                !type.IsArray && 
                !type.IsPointer && 
                !type.IsAbstract && 
                !_generatedTypesStack.Contains(type))
            {
                int maxConstructorFieldsCount = 0, curConstructorFieldsCount;
                ConstructorInfo constructorToUse = null;
                foreach (ConstructorInfo constructor in type.GetConstructors())
                {
                    curConstructorFieldsCount = constructor.GetParameters().Length;
                    if (curConstructorFieldsCount > maxConstructorFieldsCount)
                    {
                        maxConstructorFieldsCount = curConstructorFieldsCount;
                        constructorToUse = constructor;
                    }
                }
                _generatedTypesStack.Push(type);
                if (constructorToUse == null) generatedType = CreateByProperties(type);
                else generatedType = CreateByConstractor(type, constructorToUse);
                _generatedTypesStack.Pop();
            }
            else if (type.IsValueType) generatedType = Activator.CreateInstance(type);
            else generatedType = null;
            return generatedType;
        }

        private object CreateByProperties(Type type)
        {
            object generatedType = Activator.CreateInstance(type);
            foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | 
                BindingFlags.Static | BindingFlags.Public))
            {
                if (!CreateByCustomGenerator(fieldInfo, out object value)) value = Create(fieldInfo.FieldType);
                fieldInfo.SetValue(generatedType, value);
            }
            foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Instance | 
                BindingFlags.Static | BindingFlags.Public))
            {
                if (propertyInfo.CanWrite)
                {
                    if (!CreateByCustomGenerator(propertyInfo, out object value)) value = Create(propertyInfo.PropertyType);
                    propertyInfo.SetValue(generatedType, value);
                }
            }
            return generatedType;
        }

        private object CreateByConstractor(Type type, ConstructorInfo constructorInfo)
        {
            List<object> parametersValues = new List<object>();
            foreach (ParameterInfo parameterInfo in constructorInfo.GetParameters())
            {
                if (!CreateByCustomGenerator(parameterInfo, type, out object value)) value = Create(parameterInfo.ParameterType);
                parametersValues.Add(value);
            }
            try
            {
                return constructorInfo.Invoke(parametersValues.ToArray());
            }
            catch (TargetInvocationException)
            {
                return null;
            }
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
