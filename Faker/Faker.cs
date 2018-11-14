using System;
using System.Collections.Generic;
using System.Reflection;
using TypesGenerators.ArrayTypes;
using TypesGenerators.BaseTypes;
using TypesGenerators.CollectionTypes;
using TypesGenerators;
using System.IO;

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
            IBaseGenerator pluginGenerator;
            List<Assembly> assemblies = new List<Assembly>();
            _generatedTypesStack = new Stack<Type>();
            _baseGenerators = TypesGeneratorsInitialize.InitBaseGeneratorsDictionary();
            _collectionGenerators = TypesGeneratorsInitialize.InitCollectionGeneratorsDictionary(_baseGenerators);
            _arrayGenerators = TypesGeneratorsInitialize.InitArrayGeneratorsDictionary(_baseGenerators);
            if (config == null) _customGenerators = new Dictionary<PropertyInfo, IBaseGenerator>();
            else _customGenerators = config.Generators;
            try
            {
                foreach (string file in Directory.GetFiles(pluginsFolder, "*.dll"))
                {
                    try
                    {
                        assemblies.Add(Assembly.LoadFile(new FileInfo(file).FullName));
                    }
                    catch (BadImageFormatException) { }
                    catch (FileLoadException) { }
                }
            }
            catch (DirectoryNotFoundException) { }
            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    foreach (Type typeInterface in type.GetInterfaces())
                    {
                        if (typeInterface.Equals(typeof(IBaseGenerator)))
                        {
                            pluginGenerator = (IBaseGenerator)Activator.CreateInstance(type);
                            _baseGenerators.Add(pluginGenerator.GenerateType, pluginGenerator);
                        }
                    }
                }
            }
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
            if (_customGenerators.TryGetValue(propertyInfo, out IBaseGenerator generator))
            {
                generatedType = generator.Generate();
                return true;
            }
            else
            {
                generatedType = default(object);
                return false;
            }
        }

        private bool CreateByCustomGenerator(ParameterInfo parameterInfo, Type type, out object generatedType)
        {
            foreach (KeyValuePair<PropertyInfo, IBaseGenerator> keyValue in _customGenerators)
            {
                if ((keyValue.Key.Name.ToLower() == parameterInfo.Name.ToLower()) && 
                    keyValue.Value.GenerateType.Equals(parameterInfo.ParameterType) && 
                    keyValue.Key.ReflectedType.Equals(type))
                {
                    generatedType = keyValue.Value.Generate();
                    return true;
                }
            }
            generatedType = default(object);
            return false;
        }

        private bool CreateByCustomGenerator(FieldInfo fieldInfo, out object generatedType)
        {
            foreach (KeyValuePair<PropertyInfo, IBaseGenerator> keyValue in _customGenerators)
            {
                if ((keyValue.Key.Name.ToLower() == fieldInfo.Name.ToLower()) && 
                    keyValue.Value.GenerateType.Equals(fieldInfo.FieldType) && 
                    keyValue.Key.ReflectedType.Equals(fieldInfo.ReflectedType))
                {
                    generatedType = keyValue.Value.Generate();
                    return true;
                }
            }
            generatedType = default(object);
            return false;
        }
    }
}
