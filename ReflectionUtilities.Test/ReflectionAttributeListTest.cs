namespace ReflectionUtilities.Test
{
    using NUnit.Framework;

    using ReflectionUtilities;
    using ReflectionUtilities.Test.ExampleObjects;

    [TestFixture]
    public class ReflectionAttributeListTest
    {
        [Test]
        public void GetAttributeList_AttributeCount_ExactNumber()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Attributes;
            
            // Act
            int count = reflection.Count;

            // Assert
            Assert.AreEqual(4, count);
        }

        [Test]
        public void FindAttributeByType_AttributeExist_List()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Attributes;

            // Act
            var property = reflection[typeof(CustomAttribute)];

            // Assert
            Assert.AreEqual(3, property.Count);
        }

        [Test]
        public void FindAttributeByType_AttributeNotExist_EmptyList()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Attributes;

            // Act
            var property = reflection[typeof(TestAttribute)];

            // Assert
            Assert.AreEqual(0, property.Count);
        }
    }
}