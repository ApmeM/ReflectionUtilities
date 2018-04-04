using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReflectionUtilites
{
    public class ReflectionConstructorList : List<ReflectionConstructor>
    {

        private readonly Dictionary<string, ReflectionConstructor> cache = new Dictionary<string, ReflectionConstructor>();

        public System.Reflection.ConstructorInfo[] GetFields
        {
            get
            {
                return cache.Values.Select(x => x.Constructor).ToArray();
            }
        }
        #region Constructors and Destructors

        internal ReflectionConstructorList(List<ConstructorInfo> contructors, ReflectionClass parent)
        {
            this.AddRange(contructors.Select(a => new ReflectionConstructor(a, parent)));
            this.ForEach(a => this.cache.Add(a.Name, a));
        }

        public ReflectionConstructor this[string name]
        {
            get
            {
                ReflectionConstructor result;
                this.cache.TryGetValue(name, out result);
                return result;
            }
        }
        #endregion

    }
}
