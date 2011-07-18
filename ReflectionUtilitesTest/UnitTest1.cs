namespace ReflectionUtilitesTest
{
    #region Using Directives

    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ReflectionUtilites;

    #endregion

    [TestClass]
    public class UnitTest1
    {
        #region Public Methods

        public int Property { get; set; }

        public void AAA()
        {
            return;
        }

        [TestMethod]
        public void GetMethodSpeedTest()
        {
            ReflectionClass rc = ReflectionCache.GetReflection(this.GetType());
            Object result = rc.Methods["AAA"].Invoke(this, null);
            Assert.AreEqual(result, null);
        }

        #endregion
    }
}