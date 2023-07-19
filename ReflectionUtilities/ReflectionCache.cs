namespace ReflectionUtilities
{
    using System;
    using System.Collections.Generic;

    public static class ReflectionCache
    {
        private static readonly Dictionary<Type, ReflectionClass> Cache = new Dictionary<Type, ReflectionClass>();

        public static ReflectionClass GetReflection(Type t)
        {
            if (!Cache.ContainsKey(t))
            {
                Cache[t] = new ReflectionClass(t);
            }

            return Cache[t];
        }
    }
}