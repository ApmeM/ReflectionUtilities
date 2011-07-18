namespace ReflectionUtilitesTest
{
    #region Using Directives

    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ReflectionUtilites;

    #endregion

    [TestClass]
    public class ReflectionPropertyListTest
    {
        #region Public Methods

        [TestMethod]
        public void GetPropertyList_PropertyCount_ExactNumber()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));
            
            // Act
            int count = rc.Properties.Count;

            // Assert
            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void FindPropertyByName_PropertyExist_NotNull()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var property = rc.Properties["Property1"];

            // Assert
            Assert.IsNotNull(property);
        }

        [TestMethod]
        public void FindPropertyByName_PropertyNotExist_Null()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var property = rc.Properties["Property12"];

            // Assert
            Assert.IsNull(property);
        }

        #endregion
    }
}