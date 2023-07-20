namespace ReflectionUtilities
{
    using System;
    using System.Collections.Generic;

    public class ReflectionClass
    {
        private Dictionary<(Type, Type), bool> isAssignableFromCache = new Dictionary<(Type, Type), bool>();
        private ReflectionAttributeList attributes;
        private string fullName;
        private string name;
        private ReflectionFieldList fields;
        private ReflectionConstructorList constructors;
        private ReflectionPropertyList properties;
        private ReflectionMethodList methods;

        public Type BaseType { get; }
        public string FullName
        {
            get
            {
                if (this.fullName == null)
                {
                    this.fullName = BaseType.FullName;
                }
                return this.fullName;
            }
        }

        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    this.name = BaseType.Name;
                }
                return this.name;
            }
        }

        public ReflectionAttributeList Attributes
        {
            get
            {
                if (this.attributes == null)
                {
                    this.attributes = new ReflectionAttributeList(BaseType.GetCustomAttributes(true));
                }
                return this.attributes;
            }
        }

        // It includes also property get and set methods.
        public ReflectionMethodList Methods
        {
            get
            {
                if (this.methods == null)
                {
                    this.methods = new ReflectionMethodList(this.BaseType.GetMethods(), this);
                }
                return this.methods;
            }
        }

        public ReflectionPropertyList Properties
        {
            get
            {
                if (this.properties == null)
                {
                    this.properties = new ReflectionPropertyList(this.BaseType.GetProperties(), this);
                }
                return this.properties;
            }
        }

        public ReflectionFieldList Fields
        {
            get
            {
                if (this.fields == null)
                {
                    this.fields = new ReflectionFieldList(this.BaseType.GetFields(), this);
                }
                return this.fields;
            }
        }

        public ReflectionConstructorList Constructors
        {
            get
            {
                if (this.constructors == null)
                {
                    this.constructors = new ReflectionConstructorList(this.BaseType.GetConstructors(), this);
                }
                return this.constructors;
            }
        }

        internal ReflectionClass(Type type)
        {
            this.BaseType = type;
        }

        public bool IsAssignableFrom(Type type)
        {
            var tuple = (type, this.BaseType);
            if (this.isAssignableFromCache.ContainsKey(tuple))
            {
                return this.isAssignableFromCache[tuple];
            }

            var result = type.IsAssignableFrom(this.BaseType);
            this.isAssignableFromCache[tuple] = result;
            return result;
        }
    }
}
