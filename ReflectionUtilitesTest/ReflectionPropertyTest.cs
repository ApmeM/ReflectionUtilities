namespace ReflectionUtilitesTest
{
    #region Using Directives

    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ReflectionUtilites;
    using ReflectionUtilites.Exceptions;

    #endregion

    [TestClass]
    public class ReflectionPropertyTest
    {
        #region Public Methods

        [TestMethod]
        public void GetAttributes_NoAttributes_CountZero()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties;
            
            // Act
            int count = reflection["Property1"].Attributes.Count;

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void GetAttributes_AttributesExists_CountZero()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties;

            // Act
            int count = reflection["Property2"].Attributes.Count;

            // Assert
            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void FullName_PropertyExist_ShouldContainParentNameAndNameSpace()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property1"];

            // Act
            var name = reflection.FullName;

            // Assert
            Assert.AreEqual("ReflectionUtilitesTest.ExampleObject.Property1", name);
        }

        [TestMethod]
        public void WithClassName_PropertyExist_ShouldContainParentName()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property1"];

            // Act
            var name = reflection.WithClassName;

            // Assert
            Assert.AreEqual("ExampleObject.Property1", name);
        }

        [TestMethod]
        public void Name_PropertyExist_ShouldNotContainParentname()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property1"];

            // Act
            var name = reflection.Name;

            // Assert
            Assert.AreEqual("Property1", name);
        }

        [TestMethod]
        public void PropertyType_PropertyExist_PropertyType()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property4"];

            // Act
            Type propertyType = reflection.PropertyType;

            // Assert
            Assert.AreEqual(typeof(ExampleObject), propertyType);
        }

        [TestMethod]
        public void GetValue_WrongObjectType_Exception()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property1"];

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
        public void GetValue_NullObject_NullValue()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property4"];

            // Act
            NullReferenceReflectionException e = null;
            try
            {
                reflection.GetValue(null);
            }
            catch (NullReferenceReflectionException ex)
            {
                e = ex;
            }

            // Assert
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void GetValue_ValidObject_ValidValue()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property4"];
            ExampleObject obj = new ExampleObject();

            // Act
            var result = reflection.GetValue(obj);
            
            // Assert
            Assert.AreEqual(obj, result);
        }

        [TestMethod]
        public void GetValue_NoSetter_NoSuchMethodException()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property3"];
            ExampleObject obj = new ExampleObject();

            // Act
            NoSuchMethodReflectionException e = null;
            try
            {
                reflection.GetValue(obj);
            }
            catch (NoSuchMethodReflectionException ex)
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
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property1"];

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
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property1"];

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

        [TestMethod]
        public void SetValue_ValidObject_ValidValue()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property2"];
            ExampleObject obj = new ExampleObject();

            // Act
            reflection.SetValue(obj, "test string");

            // Assert
            Assert.AreEqual("test string", obj.Property2);
        }

        [TestMethod]
        public void SetValue_NoSetter_NoSuchMethodException()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Properties["Property4"];
            ExampleObject obj = new ExampleObject();

            // Act
            NoSuchMethodReflectionException e = null;
            try
            {
                reflection.SetValue(obj, "test string");
            }
            catch (NoSuchMethodReflectionException ex)
            {
                e = ex;
            }

            // Assert
            Assert.IsNotNull(e);
        }
        #endregion
    }
}