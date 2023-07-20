namespace ReflectionUtilities.Test
{
    using System.Reflection;

    using NUnit.Framework;

    using ReflectionUtilities;
    using ReflectionUtilities.Test.ExampleObjects;

    [TestFixture]
    public class ReflectionMethodTest
    {
        [Test]
        public void GetAttributes_NoAttributes_CountZero()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["AnotherTest"][0];

            // Act
            int count = reflection.Attributes.Count;

            // Assert
            Assert.AreEqual(0, count);
        }

        [Test]
        public void GetAttributes_AttributesExists_CountZero()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["Test"][0];

            // Act
            int count = reflection.Attributes.Count;

            // Assert
            Assert.AreEqual(1, count);
        }

        [Test]
        public void FullName_PropertyExist_ShouldContainParentNameAndNameSpace()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["Test"][0];

            // Act
            var name = reflection.FullName;

            // Assert
            Assert.AreEqual("ReflectionUtilities.Test.ExampleObjects.ExampleObject.Test", name);
        }

        [Test]
        public void WithClassName_PropertyExist_ShouldContainParentName()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["Test"][0];

            // Act
            var name = reflection.WithClassName;

            // Assert
            Assert.AreEqual("ExampleObject.Test", name);
        }

        [Test]
        public void Name_PropertyExist_ShouldNotContainParentname()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["Test"][0];

            // Act
            var name = reflection.Name;

            // Assert
            Assert.AreEqual("Test", name);
        }

        [Test]
        public void ReturnType_PropertyExist_PropertyType()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["Test"][0];

            // Act
            var returnType = reflection.ReturnType;

            // Assert
            Assert.AreEqual(typeof(void), returnType.BaseType);
        }

        [Test]
        public void Parameters_ParametersExist_ListOfParameters()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["Test"][1];

            // Act
            var parameters = reflection.Parameters;

            // Assert
            Assert.AreEqual(1, parameters.Length);
        }

        [Test]
        public void Parameters_NoParametersExist_ListOfParameters()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["Test"][0];

            // Act
            var parameters = reflection.Parameters;

            // Assert
            Assert.AreEqual(0, parameters.Length);
        }

        [Test]
        public void Invoke_WrongObjectType_Exception()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["Test"][0];

            // Act
            // Assert
            Assert.Throws<TargetException>(() => reflection.Invoke("test"));
        }

        [Test]
        public void Invoke_NullObject_NullReferenceException()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["Test"][0];

            // Act
            // Assert
            Assert.Throws<TargetException>(() => reflection.Invoke(null, "test"));
        }

        [Test]
        public void Invoke_ValidObject_ValidValue()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["Test"][1];
            ExampleObject obj = new ExampleObject();

            // Act
            reflection.Invoke(obj, "3");

            // Assert
            Assert.AreEqual("3", obj.Property1);
        }
    }
}