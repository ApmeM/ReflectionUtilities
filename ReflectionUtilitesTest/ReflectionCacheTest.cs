namespace ReflectionUtilitesTest
{
    #region Using Directives

    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ReflectionUtilites;
    using ReflectionUtilites.Exceptions;

    #endregion

    [TestClass]
    public class ReflectionCacheTest
    {
        #region Public Methods

        [TestMethod]
        public void GetReflection_ValidType_ReflectedObject()
        {
            // Arrange

            // Act
            var reflection = ReflectionCache.GetReflection(typeof(object));
            
            // Assert
            Assert.IsNotNull(reflection);
        }

        [TestMethod]
        public void GetReflection_NullType_Error()
        {
            // Arrange
            

            // Act
            NullReferenceReflectionException e = null;
            try
            {
                ReflectionCache.GetReflection(null);
            }
            catch (NullReferenceReflectionException ex)
            {
                e = ex;
            }

            // Assert
            Assert.IsNotNull(e);
        }

        #endregion
    }
}