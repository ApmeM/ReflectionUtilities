namespace ReflectionUtilities.Test
{
    using NUnit.Framework;

    using ReflectionUtilities;
    using ReflectionUtilities.Test.ExampleObjects;

    [TestFixture]
    public class ReflectionClassTest
    {
        [Test]
        public void BaseType_AnyObject_RealObjectType()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var type = reflection.BaseType;

            // Assert
            Assert.AreEqual(typeof(ExampleObject), type);
        }

        [Test]
        public void FullName_ForClass_ShouldContainNameSpace()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var name = reflection.FullName;

            // Assert
            Assert.AreEqual("ReflectionUtilities.Test.ExampleObjects.ExampleObject", name);
        }

        [Test]
        public void Name_ForClass_ShouldNotContainNamespace()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var name = reflection.Name;

            // Assert
            Assert.AreEqual("ExampleObject", name);
        }

        [Test]
        public void IsAssignableFrom_ForAssignableInterface_True()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var result = reflection.IsAssignableFrom(typeof(IExampleInterface));

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAssignableFrom_ForAssignableBaseInterface_True()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var result = reflection.IsAssignableFrom(typeof(IExampleBaseInterface));

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAssignableFrom_ForAssignableSameClass_True()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var result = reflection.IsAssignableFrom(typeof(ExampleObject));

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void IsAssignableFrom_ForAssignableWrongInterface_False()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var result = reflection.IsAssignableFrom(typeof(IExampleWrongInterface));

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}