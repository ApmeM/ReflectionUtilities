namespace ReflectionUtilities
{
    using System.Collections.Generic;
    using System.Reflection;

    public class ReflectionPropertyList : Dictionary<string, ReflectionProperty>
    {
        internal ReflectionPropertyList(PropertyInfo[] properties, ReflectionClass parent)
        {
            foreach (var property in properties)
            {
                this.Add(property.Name, new ReflectionProperty(property, parent));
            }
        }
    }
}
