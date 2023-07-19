namespace ReflectionUtilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class ReflectionProperty
    {
        private readonly ReflectionMethod getMethod;
        private readonly ReflectionMethod setMethod;

        public ReflectionAttributeList Attributes { get; }
        public string Name { get; }
        public Type PropertyType { get; }
        public PropertyInfo Property { get; }
        public ReflectionClass Parent { get; }

        public string FullName => this.Parent.FullName + "." + this.Name;
        public string WithClassName => this.Parent.Name + "." + this.Name;

        internal ReflectionProperty(PropertyInfo property, ReflectionClass parent)
        {
            this.Property = property;
            this.Parent = parent;

            this.Attributes = new ReflectionAttributeList(this.Property.GetCustomAttributes(true).OfType<Attribute>().ToList());
            this.Name = this.Property.Name;
            this.PropertyType = this.Property.PropertyType;

            var method = this.Property.GetGetMethod() ?? this.Property.GetGetMethod(true);
            if (method != null)
            {
                this.getMethod = new ReflectionMethod(method, parent);
            }

            method = this.Property.GetSetMethod() ?? this.Property.GetSetMethod(true);
            if (method != null)
            {
                this.setMethod = new ReflectionMethod(method, parent);
            }
        }

        public object GetValue(object from, params object[] par)
        {
            return this.getMethod.Invoke(from, par);
        }

        public void SetValue(object to, object what)
        {
            this.setMethod.Invoke(to, new[] { what });
        }
    }
}
