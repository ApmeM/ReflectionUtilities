namespace ReflectionUtilities.Test
{
    using NUnit.Framework;

    using ReflectionUtilities;
    using ReflectionUtilities.Test.ExampleObjects;

    [TestFixture]
    public class ReflectionMethodListTest
    {
        [Test]
        public void GetMethodList_MethodCount_WithoutPropertiesWithStandart()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));
            
            // Act
            int count = rc.Methods.Count;

            // Assert
            Assert.AreEqual(8 + 3*2, count);
        }

        [Test]
        public void GetMethodList_MethodCountByName_DifferentParameters()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));
            
            // Act
            int count = rc.Methods["AnotherTest"].Count;

            // Assert
            Assert.AreEqual(2, count);
        }

        [Test]
        public void FindMethodsByName_MethodsExist_MethodList()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var methods = rc.Methods["Test"];

            // Assert
            Assert.AreEqual(2, methods.Count);
        }

        [Test]
        public void FindMethodsByName_MethodNotExist_EmptyList()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var methods = rc.Methods["TestNotExist"];

            // Assert
            Assert.AreEqual(0, methods.Count);
        }
    }
}