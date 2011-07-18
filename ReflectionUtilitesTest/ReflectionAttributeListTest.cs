namespace ReflectionUtilitesTest
{
    #region Using Directives

    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ReflectionUtilites;

    #endregion

    [TestClass]
    public class ReflectionAttributeListTest
    {
        #region Public Methods

        [TestMethod]
        public void GetAttributeList_AttributeCount_ExactNumber()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Attributes;
            
            // Act
            int count = reflection.Count;

            // Assert
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void FindAttributeByType_AttributeExist_List()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Attributes;

            // Act
            var property = reflection[typeof(CustomAttribute)];

            // Assert
            Assert.AreEqual(3, property.Count);
        }

        [TestMethod]
        public void FindAttributeByType_AttributeNotExist_EmptyList()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Attributes;

            // Act
            var property = reflection[typeof(TestMethodAttribute)];

            // Assert
            Assert.AreEqual(0, property.Count);
        }

        #endregion
    }
}