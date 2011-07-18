namespace ReflectionUtilites
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ReflectionMethodList : List<ReflectionMethod>
    {
        public ReflectionMethodList(List<MethodInfo> methods, ReflectionClass parent)
        {
            this.AddRange(from method in methods select new ReflectionMethod(method, parent));
        }

        public ReflectionMethod this[string name]
        {
            get
            {
                return (from method in this where method.Name == name select method).FirstOrDefault();
            }
        }
    }
}