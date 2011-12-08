namespace ReflectionUtilites
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class ReflectionClass
    {
        #region Constants and Fields

        private readonly ReflectionAttributeList attributes;

        private readonly Type baseType;

        private readonly Dictionary<Tuple<Type, Type>, bool> cache = new Dictionary<Tuple<Type, Type>, bool>();

        private readonly string fullName;

        private readonly ReflectionMethodList methods;

        private readonly string name;

        private readonly ReflectionPropertyList properties;

        #endregion

        #region Constructors and Destructors

        internal ReflectionClass(Type type)
        {
            this.attributes = new ReflectionAttributeList(type.GetCustomAttributes(true).OfType<Attribute>().ToList());
            this.baseType = type;
            var propertyInfos = type.GetProperties().ToList();
            var propertyMethods = propertyInfos.SelectMany(a => new[] { a.GetGetMethod(), a.GetSetMethod() });
            this.properties = new ReflectionPropertyList(propertyInfos, this);
            this.methods = new ReflectionMethodList(type.GetMethods().Except(propertyMethods).ToList(), this);
            this.name = type.Name;
            this.fullName = type.FullName;
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

        public Type BaseType
        {
            get
            {
                return this.baseType;
            }
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
        }

        public ReflectionMethodList Methods
        {
            get
            {
                return this.methods;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public ReflectionPropertyList Properties
        {
            get
            {
                return this.properties;
            }
        }

        #endregion

        #region Public Methods

        public bool IsAssignableFrom(Type type)
        {
            var tuple = new Tuple<Type, Type>(type, this.baseType);
            if (this.cache.ContainsKey(tuple))
            {
                return this.cache[tuple];
            }

            var result = type.IsAssignableFrom(this.baseType);
            this.cache[tuple] = result;
            return result;
        }

        #endregion
    }
}