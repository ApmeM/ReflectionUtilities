namespace ReflectionUtilities.Test
{
    using NUnit.Framework;

    using ReflectionUtilities;
    using ReflectionUtilities.Test.ExampleObjects;

    [TestFixture]
    public class ReflectionFieldListTest
    {
        [Test]
        public void GetFieldList_PropertyCount_ExactNumber()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            int count = rc.Properties.Count;

            // Assert
            Assert.AreEqual(4, count);
        }

        [Test]
        public void FindFieldByName_FieldExist_NotNull()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var property = rc.Fields["Field1"];

            // Assert
            Assert.IsNotNull(property);
        }

        [Test]
        public void FindFieldByName_FieldNotExist_Null()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var property = rc.Fields["Field12"];

            // Assert
            Assert.IsNull(property);
        }
    }
}
