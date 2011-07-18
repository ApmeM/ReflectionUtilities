namespace ReflectionUtilitesTest
{
    #region Using Directives

    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ReflectionUtilites;
    using ReflectionUtilites.Exceptions;

    #endregion

    [TestClass]
    public class ReflectionClassTest
    {
        #region Public Methods

        [TestMethod]
        public void Attributes_AttributesExist_Count()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));
            
            // Act
            int count = reflection.Attributes.Count;

            // Assert
            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void Properties_PropertiesExist_Count()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            int count = reflection.Properties.Count;

            // Assert
            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void Methods_MethodsExist_CountWithStandart()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            int count = reflection.Methods.Count;

            // Assert
            Assert.AreEqual(7, count);
        }

        [TestMethod]
        public void BaseType_AnyObject_RealObjectType()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var type = reflection.BaseType;

            // Assert
            Assert.AreEqual(typeof(ExampleObject), type);
        }

        [TestMethod]
        public void FullName_ForClass_ShouldContainNameSpace()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var name = reflection.FullName;

            // Assert
            Assert.AreEqual("ReflectionUtilitesTest.ExampleObject", name);
        }

        [TestMethod]
        public void Name_ForClass_ShouldNotContainNamespace()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var name = reflection.Name;

            // Assert
            Assert.AreEqual("ExampleObject", name);
        }

        #endregion
    }
}