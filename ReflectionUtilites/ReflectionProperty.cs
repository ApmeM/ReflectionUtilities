namespace ReflectionUtilites
{
    #region Using Directives

    using System;
    using System.Linq;
    using System.Reflection;

    #endregion

    public class ReflectionProperty
    {
        #region Constants and Fields

        private readonly ReflectionAttributeList attributes;

        private readonly MethodInfo getMethod;

        private readonly string name;

        private readonly ReflectionClass parent;

        private readonly PropertyInfo property;

        private readonly Type propertyType;

        private readonly MethodInfo setMethod;

        #endregion

        #region Constructors and Destructors

        internal ReflectionProperty(PropertyInfo property, ReflectionClass parent)
        {
            this.property = property;
            this.parent = parent;

            this.attributes =
                new ReflectionAttributeList(this.property.GetCustomAttributes(true).OfType<Attribute>().ToList());
            this.name = this.property.Name;
            this.propertyType = this.property.PropertyType;
            this.getMethod = this.property.GetGetMethod() ?? this.property.GetGetMethod(true);
            this.setMethod = this.property.GetSetMethod() ?? this.property.GetSetMethod(true);
        }

        #endregion

        #region Properties

        public ReflectionAttributeList Attributes
        {
            get
            {
                return this.attributes;
            }
        }

        public string FullName
        {
            get
            {
                return this.parent.FullName + "." + this.name;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public Type PropertyType
        {
            get
            {
                return this.propertyType;
            }
        }

        public string WithClassName
        {
            get
            {
                return this.parent.Name + "." + this.name;
            }
        }

        internal MethodInfo GetMethod
        {
            get
            {
                return this.getMethod;
            }
        }

        internal MethodInfo SetMethod
        {
            get
            {
                return this.setMethod;
            }
        }

        #endregion

        #region Public Methods

        public object GetValue(object from)
        {
            if (from == null)
            {
                return null;
            }

            if (from.GetType() != this.parent.BaseType)
            {
                return null;
            }

            return this.getMethod.Invoke(from, null);
        }

        public void SetValue(object to, object what)
        {
            if (to == null)
            {
                return;
            }

            if (to.GetType() != this.parent.BaseType)
            {
                return;
            }

            this.setMethod.Invoke(to, new[] { Convert.ChangeType(what, this.propertyType) });
        }

        #endregion
    }
}