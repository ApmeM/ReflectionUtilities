namespace ReflectionUtilites
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    #endregion

    public class ReflectionPropertyList : List<ReflectionProperty>
    {
        private readonly Dictionary<string, ReflectionProperty> cache = new Dictionary<string, ReflectionProperty>();

        public PropertyInfo[] GetProperties
        {
            get
            {
                return cache.Values.Select(x => x.Property).ToArray();
            }
        }


        #region Constructors and Destructors

        internal ReflectionPropertyList(List<PropertyInfo> properties, ReflectionClass parent)
        {
            this.AddRange(properties.Select(a => new ReflectionProperty(a, parent)));
            this.ForEach(a => this.cache.Add(a.Name, a));
        }

        public ReflectionProperty this[string name]
        {
            get
            {
                ReflectionProperty result;
                this.cache.TryGetValue(name, out result);
                return result;
            }
        }

        #endregion
    }
}
