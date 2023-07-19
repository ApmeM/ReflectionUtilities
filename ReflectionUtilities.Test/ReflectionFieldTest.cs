namespace ReflectionUtilities.Test
{
    using System;
    using System.Reflection;
    using NUnit.Framework;

    using ReflectionUtilities;
    using ReflectionUtilities.Test.ExampleObjects;

    [TestFixture]
    public class ReflectionFieldTest
    {
        [Test]
        public void GetAttributes_NoAttributes_CountZero()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields;

            // Act
            int count = reflection["Field1"].Attributes.Count;

            // Assert
            Assert.AreEqual(0, count);
        }

        [Test]
        public void GetAttributes_AttributesExists_CountZero()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields;

            // Act
            int count = reflection["Field2"].Attributes.Count;

            // Assert
            Assert.AreEqual(2, count);
        }

        [Test]
        public void FullName_FieldExist_ShouldContainParentNameAndNameSpace()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields["Field1"];

            // Act
            var name = reflection.FullName;

            // Assert
            Assert.AreEqual("ReflectionUtilities.Test.ExampleObjects.ExampleObject.Field1", name);
        }

        [Test]
        public void WithClassName_FieldExist_ShouldContainParentName()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields["Field1"];

            // Act
            var name = reflection.WithClassName;

            // Assert
            Assert.AreEqual("ExampleObject.Field1", name);
        }

        [Test]
        public void Name_PropertyExist_ShouldNotContainParentname()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields["Field1"];

            // Act
            var name = reflection.Name;

            // Assert
            Assert.AreEqual("Field1", name);
        }


        [Test]
        public void GetValue_WrongObjectType_Exception()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields["Field1"];

            // Act
            // Assert
            Assert.Throws<ArgumentException>(()=>reflection.GetValue("test"));
        }

        [Test]
        public void SetValue_WrongObjectType_Exception()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields["Field1"];

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => reflection.SetValue("test", "test"));
        }

        [Test]
        public void SetValue_NullObject_NullReferenceException()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields["Field1"];

            // Act
            // Assert
            Assert.Throws<TargetException>(() => reflection.SetValue(null, "test"));
        }
    }
}
