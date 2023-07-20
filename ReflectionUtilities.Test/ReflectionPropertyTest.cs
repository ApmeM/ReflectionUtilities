namespace ReflectionUtilities.Test
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    using ReflectionUtilities;
    using ReflectionUtilities.Test.ExampleObjects;

    [TestFixture]
    public class ReflectionPropertyTest
    {
        [Test]
        public void GetAttributes_NoAttributes_CountZero()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties;

            // Act
            int count = reflection["Property1"].Attributes.Count;

            // Assert
            Assert.AreEqual(0, count);
        }

        [Test]
        public void GetAttributes_AttributesExists_CountZero()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties;

            // Act
            int count = reflection["Property2"].Attributes.Count;

            // Assert
            Assert.AreEqual(4, count);
        }

        [Test]
        public void FullName_PropertyExist_ShouldContainParentNameAndNameSpace()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property1"];

            // Act
            var name = reflection.FullName;

            // Assert
            Assert.AreEqual("ReflectionUtilities.Test.ExampleObjects.ExampleObject.Property1", name);
        }

        [Test]
        public void WithClassName_PropertyExist_ShouldContainParentName()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property1"];

            // Act
            var name = reflection.WithClassName;

            // Assert
            Assert.AreEqual("ExampleObject.Property1", name);
        }

        [Test]
        public void Name_PropertyExist_ShouldNotContainParentname()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property1"];

            // Act
            var name = reflection.Name;

            // Assert
            Assert.AreEqual("Property1", name);
        }

        [Test]
        public void PropertyType_PropertyExist_PropertyType()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property4"];

            // Act
            var propertyType = reflection.PropertyType;

            // Assert
            Assert.AreEqual(typeof(ExampleObject), propertyType.BaseType);
        }

        [Test]
        public void GetValue_WrongObjectType_Exception()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property1"];

            // Act
            // Assert
            Assert.Throws<TargetException>(() => reflection.GetValue("test"));
        }

        [Test]
        public void GetValue_NullObject_NullValue()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property4"];

            // Act
            // Assert
            Assert.Throws<TargetException>(() => reflection.GetValue(null));
        }

        [Test]
        public void GetValue_ValidObject_ValidValue()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property4"];
            ExampleObject obj = new ExampleObject();

            // Act
            var result = reflection.GetValue(obj);

            // Assert
            Assert.AreEqual(obj, result);
        }

        [Test]
        public void GetValue_NoSetter_NoSuchMethodException()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property3"];
            ExampleObject obj = new ExampleObject();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => reflection.GetValue(obj));
        }

        [Test]
        public void SetValue_WrongObjectType_Exception()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property1"];

            // Act
            // Assert
            Assert.Throws<TargetException>(() => reflection.SetValue("test", "test"));
        }

        [Test]
        public void SetValue_NullObject_NullReferenceException()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property1"];

            // Act
            // Assert
            Assert.Throws<TargetException>(() => reflection.SetValue(null, "test"));
        }

        [Test]
        public void SetValue_ValidObject_ValidValue()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property2"];
            ExampleObject obj = new ExampleObject();

            // Act
            reflection.SetValue(obj, "test string");

            // Assert
            Assert.AreEqual("test string", obj.Property2);
        }

        [Test]
        public void SetValue_NoSetter_NoSuchMethodException()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property4"];
            ExampleObject obj = new ExampleObject();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => reflection.SetValue(obj, "test string"));
        }
    }
}