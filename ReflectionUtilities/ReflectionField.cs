using System;
using System.Linq;
using System.Reflection;

namespace ReflectionUtilities
{
    public class ReflectionField
    {
        private readonly FieldInfo field;

        public ReflectionClass Parent { get; }
        public ReflectionAttributeList Attributes { get; }
        public string Name { get; }
        public Type FieldType { get; }

        public string WithClassName => this.Parent.Name + "." + this.Name;
        public string FullName => this.Parent.FullName + "." + this.Name;

        internal ReflectionField(FieldInfo field, ReflectionClass parent)
        {
            this.field = field;
            this.Parent = parent;

            this.Attributes =
                new ReflectionAttributeList(this.field.GetCustomAttributes(true).OfType<Attribute>().ToList());
            this.Name = this.field.Name;
            this.FieldType = this.field.FieldType;

        }


        public object GetValue(object from)
        {
            return this.field.GetValue(from);
        }

        public void SetValue(object to, object what)
        {
            this.field.SetValue(to, new[] { what });
        }
    }
}
