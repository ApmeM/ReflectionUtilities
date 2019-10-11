namespace ReflectionUtilites.Test
{
    #region Using Directives

    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ReflectionUtilites;
    using ReflectionUtilites.Exceptions;
    using ReflectionUtilites.Test.ExampleObjects;

    #endregion

    [TestClass]
    public class ReflectionFieldTest
    {
        #region Public Methods

        [TestMethod]
        public void GetAttributes_NoAttributes_CountZero()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields;

            // Act
            int count = reflection["Field1"].Attributes.Count;

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void GetAttributes_AttributesExists_CountZero()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields;

            // Act
            int count = reflection["Property2"].Attributes.Count;

            // Assert
            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void FullName_FieldExist_ShouldContainParentNameAndNameSpace()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields["Field1"];

            // Act
            var name = reflection.FullName;

            // Assert
            Assert.AreEqual("ReflectionUtilites.Test.ExampleObjects.ExampleObject.Field1", name);
        }

        [TestMethod]
        public void WithClassName_FieldExist_ShouldContainParentName()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields["Field1"];

            // Act
            var name = reflection.WithClassName;

            // Assert
            Assert.AreEqual("ExampleObject.Field1", name);
        }

        [TestMethod]
        public void Name_PropertyExist_ShouldNotContainParentname()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields["Field1"];

            // Act
            var name = reflection.Name;

            // Assert
            Assert.AreEqual("Field1", name);
        }


        [TestMethod]
        public void GetValue_WrongObjectType_Exception()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields["Field1"];

            // Act
            WrongObjectReflectionException e = null;
            try
            {
                reflection.GetValue("test");
            }
            catch (WrongObjectReflectionException ex)
            {
                e = ex;
            }

            // Assert
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void SetValue_WrongObjectType_Exception()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields["Field1"];

            // Act
            WrongObjectReflectionException e = null;
            try
            {
                reflection.SetValue("test", "test");
            }
            catch (WrongObjectReflectionException ex)
            {
                e = ex;
            }

            // Assert
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void SetValue_NullObject_NullReferenceException()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Fields["Field1"];

            // Act
            NullReferenceReflectionException e = null;
            try
            {
                reflection.SetValue(null, "test");
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
