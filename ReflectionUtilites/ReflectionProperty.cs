namespace ReflectionUtilites
{
    #region Using Directives

    using System;
    using System.Linq;
    using System.Reflection;

    using ReflectionUtilites.Exceptions;

    #endregion

    public class ReflectionProperty
    {
        #region Constants and Fields

        private readonly ReflectionAttributeList attributes;

        private readonly ReflectionMethod getMethod;

        private readonly string name;

        private readonly ReflectionClass parent;

        private readonly PropertyInfo property;

        private readonly Type propertyType;

        private readonly ReflectionMethod setMethod;

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

            var method = this.property.GetGetMethod() ?? this.property.GetGetMethod(true);
            if (method != null)
            {
                this.getMethod = new ReflectionMethod(method, parent);
            }

            method = this.property.GetSetMethod() ?? this.property.GetSetMethod(true);
            if (method != null)
            {
                this.setMethod = new ReflectionMethod(method, parent);
            }
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
        public PropertyInfo Property
        {
            get
            {
                return property;
            }
        }

        #endregion

        #region Public Methods

        public object GetValue(object from, params object[] par)
        {
            if (this.getMethod == null)
            {
                throw new NoSuchMethodReflectionException();
            }

            return this.getMethod.Invoke(from, par);
        }

        public void SetValue(object to, object what)
        {
            if (this.setMethod == null)
            {
                throw new NoSuchMethodReflectionException();
            }

            this.setMethod.Invoke(to, new[] { what });
        }

        #endregion
    }
}
