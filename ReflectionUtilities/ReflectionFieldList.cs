using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionUtilities
{
    public class ReflectionFieldList : List<ReflectionField>
    {
        internal ReflectionFieldList(FieldInfo[] fields, ReflectionClass parent)
        {
            this.AddRange(fields.Select(a => new ReflectionField(a, parent)));
        }

        public ReflectionField this[string name] => this.Where(a => a.Name == name).SingleOrDefault();
    }
}
