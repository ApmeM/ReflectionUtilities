using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionUtilites
{
    public class ReflectionFieldList : List<ReflectionField>
    {
        private readonly Dictionary<string, ReflectionField> cache = new Dictionary<string, ReflectionField>();

        public FieldInfo[] GetFields
        {
            get
            {
                return cache.Values.Select(x => x.Field).ToArray();
            }
        }
        #region Constructors and Destructors

        internal ReflectionFieldList(List<FieldInfo> fields, ReflectionClass parent)
        {
            this.AddRange(fields.Select(a => new ReflectionField(a, parent)));
            this.ForEach(a => this.cache.Add(a.Name, a));
        }

        public ReflectionField this[string name]
        {
            get
            {
                ReflectionField result;
                this.cache.TryGetValue(name, out result);
                return result;
            }
        }
        #endregion
    }
}
