namespace ReflectionUtilities.Test
{
    using System;

    using NUnit.Framework;

    using ReflectionUtilities;

    [TestFixture]
    public class ReflectionCacheTest
    {
        [Test]
        public void GetReflection_ValidType_ReflectedObject()
        {
            // Arrange

            // Act
            var reflection = ReflectionCache.GetReflection(typeof(object));

            // Assert
            Assert.IsNotNull(reflection);
        }

        [Test]
        public void GetReflection_NullType_Error()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => ReflectionCache.GetReflection(null));
        }
    }
}