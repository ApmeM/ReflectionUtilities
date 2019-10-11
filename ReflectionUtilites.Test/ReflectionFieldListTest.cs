namespace ReflectionUtilites.Test
{
    #region Using Directives

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ReflectionUtilites;
    using ReflectionUtilites.Test.ExampleObjects;

    #endregion

    [TestClass]
    public class ReflectionFieldListTest
    {
        #region Public Methods

        [TestMethod]
        public void GetFieldList_PropertyCount_ExactNumber()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            int count = rc.Properties.Count;

            // Assert
            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void FindFieldByName_FieldExist_NotNull()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var property = rc.Properties["Field"];

            // Assert
            Assert.IsNotNull(property);
        }

        [TestMethod]
        public void FindFieldByName_FieldNotExist_Null()
        {
            // Arrange
            ReflectionClass rc = ReflectionCache.GetReflection(typeof(ExampleObject));

            // Act
            var property = rc.Properties["Field12"];

            // Assert
            Assert.IsNull(property);
        }

        #endregion
    }
}
