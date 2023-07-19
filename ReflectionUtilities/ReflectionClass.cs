namespace ReflectionUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReflectionClass
    {
        private readonly Dictionary<(Type, Type), bool> isAssignableFromCache = new Dictionary<(Type, Type), bool>();

        public ReflectionAttributeList Attributes { get; }
        public Type BaseType { get; }
        public string FullName { get; }
        public ReflectionMethodList Methods { get; }
        public string Name { get; }
        public ReflectionPropertyList Properties { get; }
        public ReflectionFieldList Fields { get; }
        public ReflectionConstructorList Constructors { get; }

        internal ReflectionClass(Type type)
        {
            this.Attributes = new ReflectionAttributeList(type.GetCustomAttributes(true).OfType<Attribute>().ToList());
            this.BaseType = type;
            var propertyInfos = type.GetProperties().ToList();
            var propertyMethods = propertyInfos.SelectMany(a => new[] { a.GetGetMethod(), a.GetSetMethod() });
            this.Properties = new ReflectionPropertyList(propertyInfos, this);
            this.Methods = new ReflectionMethodList(type.GetMethods().Except(propertyMethods).ToList(), this);
            this.Fields = new ReflectionFieldList(type.GetFields().ToList(), this);
            this.Constructors = new ReflectionConstructorList(type.GetConstructors().ToList(), this);
            this.Name = type.Name;
            this.FullName = type.FullName;
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
