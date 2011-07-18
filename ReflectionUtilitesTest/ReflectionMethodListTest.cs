namespace ReflectionUtilitesTest
{
    #region Using Directives

    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ReflectionUtilites;

    #endregion

    [TestClass]
    public class ReflectionMethodListTest
    {
        #region Public Methods

        [TestMethod]
        public void GetMethodList_MethodCount_WithoutPropertiesWithStandart()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));
            
            // Act
            int count = rc.Methods.Count;

            // Assert
            Assert.AreEqual(7, count);
        }

        [TestMethod]
        public void FindMethodsByName_MethodsExist_MethodList()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var methods = rc.Methods["TestMethod"];

            // Assert
            Assert.AreEqual(2, methods.Count);
        }

        [TestMethod]
        public void FindMethodsByName_MethodNotExist_EmptyList()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var methods = rc.Methods["TestMethodNotExist"];

            // Assert
            Assert.AreEqual(0, methods.Count);
        }

        #endregion
    }
}