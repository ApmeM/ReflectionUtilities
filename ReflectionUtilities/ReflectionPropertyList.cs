namespace ReflectionUtilities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ReflectionPropertyList : List<ReflectionProperty>
    {
        internal ReflectionPropertyList(List<PropertyInfo> properties, ReflectionClass parent)
        {
            this.AddRange(properties.Select(a => new ReflectionProperty(a, parent)));
        }

        public ReflectionProperty this[string name] => this.Where(a => a.Name == name).SingleOrDefault();
    }
}
