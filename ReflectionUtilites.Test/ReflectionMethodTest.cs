namespace ReflectionUtilites.Test
{
    #region Using Directives

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ReflectionUtilites;
    using ReflectionUtilites.Exceptions;

    #endregion

    [TestClass]
    public class ReflectionMethodTest
    {
        #region Public Methods

        [TestMethod]
        public void GetAttributes_NoAttributes_CountZero()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["AnotherTestMethod"][0];
            
            // Act
            int count = reflection.Attributes.Count;

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void GetAttributes_AttributesExists_CountZero()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["TestMethod"][0];

            // Act
            int count = reflection.Attributes.Count;

            // Assert
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void FullName_PropertyExist_ShouldContainParentNameAndNameSpace()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["TestMethod"][0];

            // Act
            var name = reflection.FullName;

            // Assert
            Assert.AreEqual("ReflectionUtilites.Test.ExampleObject.TestMethod", name);
        }

        [TestMethod]
        public void WithClassName_PropertyExist_ShouldContainParentName()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["TestMethod"][0];

            // Act
            var name = reflection.WithClassName;

            // Assert
            Assert.AreEqual("ExampleObject.TestMethod", name);
        }

        [TestMethod]
        public void Name_PropertyExist_ShouldNotContainParentname()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["TestMethod"][0];

            // Act
            var name = reflection.Name;

            // Assert
            Assert.AreEqual("TestMethod", name);
        }

        [TestMethod]
        public void ReturnType_PropertyExist_PropertyType()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["TestMethod"][0];

            // Act
            var returnType = reflection.ReturnType;

            // Assert
            Assert.AreEqual(typeof(void), returnType);
        }

        [TestMethod]
        public void Parameters_ParametersExist_ListOfParameters()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["TestMethod"][1];

            // Act
            var parameters = reflection.Parameters;

            // Assert
            Assert.AreEqual(1, parameters.Length);
        }

        [TestMethod]
        public void Parameters_NoParametersExist_ListOfParameters()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["TestMethod"][0];

            // Act
            var parameters = reflection.Parameters;

            // Assert
            Assert.AreEqual(0, parameters.Length);
        }

        [TestMethod]
        public void Invoke_WrongObjectType_Exception()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["TestMethod"][0];

            // Act
            WrongObjectReflectionException e = null;
            try
            {
                reflection.Invoke("test");
            }
            catch (WrongObjectReflectionException ex)
            {
                e = ex;
            }

            // Assert
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Invoke_NullObject_NullReferenceException()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["TestMethod"][0];

            // Act
            NullReferenceReflectionException e = null;
            try
            {
                reflection.Invoke(null, "test");
            }
            catch (NullReferenceReflectionException ex)
            {
                e = ex;
            }

            // Assert
            Assert.IsNotNull(e);
        }

        [TestMethod]
        public void Invoke_ValidObject_ValidValue()
        {
            // Arrange
            var reflection = ReflectionCache.GetReflection(typeof(ExampleObject)).Methods["TestMethod"][1];
            ExampleObject obj = new ExampleObject();

            // Act
            reflection.Invoke(obj, 3);

            // Assert
            Assert.AreEqual(3, obj.Property1);
        }

        #endregion
    }
}