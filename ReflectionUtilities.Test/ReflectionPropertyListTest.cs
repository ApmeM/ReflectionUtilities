namespace ReflectionUtilities.Test
{
    using NUnit.Framework;

    using ReflectionUtilities;
    using ReflectionUtilities.Test.ExampleObjects;

    [TestFixture]
    public class ReflectionPropertyListTest
    {
        [Test]
        public void GetPropertyList_PropertyCount_ExactNumber()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            int count = rc.Properties.Count;

            // Assert
            Assert.AreEqual(4, count);
        }

        [Test]
        public void FindPropertyByName_PropertyExist_NotNull()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var property = rc.Properties["Property1"];

            // Assert
            Assert.IsNotNull(property);
        }

        [Test]
        public void FindPropertyByName_PropertyNotExist_Null()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var propertyExists = rc.Properties.ContainsKey("Property12");

            // Assert
            Assert.IsFalse(propertyExists);
        }
    }
}
