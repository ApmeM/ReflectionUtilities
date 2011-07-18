using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Utilites.ReflectionUtilites
{
    public class ReflectionPropertyList : List<ReflectionProperty>
    {
        public ReflectionPropertyList(List<PropertyInfo> properties, ReflectionClass parent)
        {
            AddRange((from property in properties select new ReflectionProperty(property, parent)));
        }
    }
}
