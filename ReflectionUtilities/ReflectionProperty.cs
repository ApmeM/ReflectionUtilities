namespace ReflectionUtilities
{
    using System.Reflection;

    public class ReflectionProperty
    {
        private ReflectionClass propertyType;
        private string name;
        private ReflectionAttributeList attributes;
        private ReflectionMethod setMethod;
        private ReflectionMethod getMethod;

        public PropertyInfo BaseProperty { get; }
        public ReflectionClass ParentType { get; }

        public ReflectionMethod GetMethod
        {
            get
            {
                if (this.getMethod == null)
                {
                    var method = this.BaseProperty.GetGetMethod() ?? this.BaseProperty.GetGetMethod(true);
                    if (method != null)
                    {
                        this.getMethod = new ReflectionMethod(method, this.ParentType);
                    }
                }
                return this.getMethod;
            }
        }

        public ReflectionMethod SetMethod
        {
            get
            {
                if (this.setMethod == null)
                {
                    var method = this.BaseProperty.GetSetMethod() ?? this.BaseProperty.GetSetMethod(true);
                    if (method != null)
                    {
                        this.setMethod = new ReflectionMethod(method, this.ParentType);
                    }
                }
                return this.setMethod;
            }
        }

        public ReflectionAttributeList Attributes
        {
            get
            {
                if (this.attributes == null)
                {
                    this.attributes = new ReflectionAttributeList(this.BaseProperty.GetCustomAttributes(true));
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
                    this.name = this.BaseProperty.Name;
                }
                return this.name;
            }
        }

        public ReflectionClass PropertyType
        {
            get
            {
                if (this.propertyType == null)
                {
                    this.propertyType = ReflectionCache.GetReflection(this.BaseProperty.PropertyType);
                }
                return this.propertyType;
            }
        }

        public string FullName => this.ParentType.FullName + "." + this.Name;
        public string WithClassName => this.ParentType.Name + "." + this.Name;

        internal ReflectionProperty(PropertyInfo property, ReflectionClass parent)
        {
            this.BaseProperty = property;
            this.ParentType = parent;
        }

        public object GetValue(object from)
        {
            return this.BaseProperty.GetValue(from);
        }

        public void SetValue(object to, object what)
        {
            this.BaseProperty.SetValue(to, what);
        }
    }
}
