namespace ReflectionUtilites
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    #endregion

    public class ReflectionCache
    {
        #region Constants and Fields

        private static readonly Dictionary<Type, ReflectionClass> Cache = new Dictionary<Type, ReflectionClass>();

        #endregion

        #region Public Methods

        public static ReflectionClass GetReflection(Type t)
        {
            if (!Cache.ContainsKey(t))
            {
                Cache[t] = new ReflectionClass(t);
            }

            return Cache[t];
        }

        #endregion
    }
}