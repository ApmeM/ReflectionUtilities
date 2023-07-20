using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionUtilities
{
    public class ReflectionConstructorList : List<ReflectionConstructor>
    {
        internal ReflectionConstructorList(ConstructorInfo[] contructors, ReflectionClass parent)
        {
            this.AddRange(contructors.Select(a => new ReflectionConstructor(a, parent)));
        }

        public ReflectionConstructor this[string name] => this.Where(a => a.Name == name).SingleOrDefault();
    }
}
