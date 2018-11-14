using System;
using Faker;
using FakerUnitTest.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypesGenerators.Custom;

namespace FakerUnitTest
{
    [TestClass]
    public class FakerUnitTest
    {
        private Faker.Faker faker;

        [TestInitialize]
        public void Setup()
        {
            faker = new Faker.Faker();
        }

        [TestMethod]
        public void NullableFieldsTest()
        {
            NullableFieldsClassNoConstructor noConstructorObject = faker.Create<NullableFieldsClassNoConstructor>();
            Assert.AreNotEqual(null, noConstructorObject.dateTimeField);
            Assert.AreNotEqual(null, noConstructorObject.listField);
            Assert.AreNotEqual(null, noConstructorObject.objectField);

            NullableFieldsClassWithConstructor constructorObject = faker.Create<NullableFieldsClassWithConstructor>();
            Assert.AreNotEqual(null, constructorObject.listField);
            Assert.AreEqual(default(DateTime), constructorObject.dateTimeField);
            Assert.AreEqual(default(object), constructorObject.objectField);
        }

        [TestMethod]
        public void NullablePropertiesTest()
        {
            NullablePropertiesClassNoConstructor noConstructorObject = faker.Create<NullablePropertiesClassNoConstructor>();
            Assert.AreNotEqual(null, noConstructorObject.ObjectProperty);
            Assert.AreNotEqual(null, noConstructorObject.listField);
            Assert.AreNotEqual(null, noConstructorObject.DateTimeProperty);

            NullablePropertiesClassWithConstructor constructorObject = faker.Create<NullablePropertiesClassWithConstructor>();
            Assert.AreNotEqual(null, constructorObject.DateTimeProperty);
            Assert.AreEqual(default(string), constructorObject.listField);
            Assert.AreEqual(default(object), constructorObject.ObjectProperty);
        }

        [TestMethod]
        public void SelfRecursionTest()
        {
            SelfRecursiveClassNoConstructor noConstructor = faker.Create<SelfRecursiveClassNoConstructor>();
            Assert.AreEqual(null, noConstructor.innerObject);
            SelfRecursiveClassWithConstructor selfRecursive = faker.Create<SelfRecursiveClassWithConstructor>();
            Assert.AreEqual(null, selfRecursive.innerObject);
        }

        [TestMethod]
        public void IndirectRecursiongTest()
        {
            IndirectRecursiveClass1 indirectRecursiveObject = faker.Create<IndirectRecursiveClass1>();
            Assert.AreEqual(null, indirectRecursiveObject.InnerObject.InnerObject);
        }

        [TestMethod]
        public void ListTest()
        {
            ListClass listClass = faker.Create<ListClass>();
            Assert.AreNotEqual(null, listClass.intList);
            Assert.AreNotEqual(null, listClass.objectList);
            Assert.AreEqual(0, listClass.objectList.Count);
        }

        [TestMethod]
        public void ArrayTest()
        {
            ArrayClass arrayClass = faker.Create<ArrayClass>();
            Assert.AreNotEqual(null, arrayClass.intSingleRateArray);
            Assert.AreNotEqual(null, arrayClass.objectSingleRateArray);
            Assert.AreEqual(0, arrayClass.objectSingleRateArray.Length);
            Assert.AreNotEqual(null, arrayClass.intJaggedArray);
            Assert.AreEqual(0, arrayClass.intJaggedArray.Length);
            Assert.AreEqual(null, arrayClass.intDoubleRateArray);
        }

        [TestMethod]
        public void CustomGenerationTest()
        {
            IFakerConfig config = new FakerConfig();
            config.Add<CustomClassWithProperty, byte, ByteNotRandomGenerator>(cl => cl.ByteValue1);
            config.Add<CustomClassWithConstructor, byte, ByteNotRandomGenerator>(cl => cl.ByteValue2);
            Assert.ThrowsException<ArgumentException>(() => config.Add<CustomClassWithProperty, string, ByteNotRandomGenerator>(err => err.SomeString));

            faker = new Faker.Faker(config);

            CustomClassWithProperty propertyClass = faker.Create<CustomClassWithProperty>();
            Assert.AreEqual(ByteNotRandomGenerator.DefaultGeneratedValue, propertyClass.ByteValue1);
            Assert.AreNotEqual(ByteNotRandomGenerator.DefaultGeneratedValue, propertyClass._byteValue);

            CustomClassWithConstructor constructorClass = faker.Create<CustomClassWithConstructor>();
            Assert.AreNotEqual(ByteNotRandomGenerator.DefaultGeneratedValue, constructorClass.ByteValue2);
            Assert.AreNotEqual(ByteNotRandomGenerator.DefaultGeneratedValue, constructorClass.ByteValue1);
            Assert.AreNotEqual(ByteNotRandomGenerator.DefaultGeneratedValue, constructorClass._byteValue);
        }
    }
}
