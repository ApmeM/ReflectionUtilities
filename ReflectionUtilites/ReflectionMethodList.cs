namespace ReflectionUtilites
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ReflectionMethodList : List<ReflectionMethod>
    {
        internal ReflectionMethodList(List<MethodInfo> methods, ReflectionClass parent)
        {
            this.AddRange(from method in methods select new ReflectionMethod(method, parent));
        }

        public List<ReflectionMethod> this[string name]
        {
            get
            {
                return this.Where(a => a.Name == name).ToList();
            }
        }
    }
}