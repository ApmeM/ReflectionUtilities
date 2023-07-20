using System.Reflection;

namespace ReflectionUtilities
{
    public class ReflectionField
    {
        public FieldInfo BaseField { get; }
        public ReflectionClass ParentType { get; }

        private ReflectionClass fieldType;
        private string name;
        private ReflectionAttributeList attributes;

        public ReflectionAttributeList Attributes
        {
            get
            {
                if (this.attributes == null)
                {
                    this.attributes = new ReflectionAttributeList(this.BaseField.GetCustomAttributes(true));
                }
                return this.attributes;
            }
        }

        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    this.name = this.BaseField.Name;
                }
                return this.name;
            }
        }

        public ReflectionClass FieldType
        {
            get
            {
                if (this.fieldType == null)
                {
                    this.fieldType = ReflectionCache.GetReflection(this.BaseField.FieldType);
                }
                return this.fieldType;
            }
        }

        public string WithClassName => this.ParentType.Name + "." + this.Name;
        public string FullName => this.ParentType.FullName + "." + this.Name;

        internal ReflectionField(FieldInfo field, ReflectionClass parent)
        {
            this.BaseField = field;
            this.ParentType = parent;
        }

        public object GetValue(object from)
        {
            return this.BaseField.GetValue(from);
        }

        public void SetValue(object to, object what)
        {
            this.BaseField.SetValue(to, new[] { what });
        }
    }
}
