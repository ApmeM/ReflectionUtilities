using System;
using System.Collections.Generic;

namespace Utilites.ReflectionUtilites
{
    public class ReflectionCache
    {
        private static readonly Dictionary<Type, ReflectionClass> _Cache = new Dictionary<Type, ReflectionClass>();

        public static ReflectionClass GetReflection(Type t)
        {
            if (!_Cache.ContainsKey(t))
                _Cache[t] = new ReflectionClass(t);
            return _Cache[t];
        }
    }
}
