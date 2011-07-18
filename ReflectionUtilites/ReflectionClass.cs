using System;
using System.Linq;

namespace Utilites.ReflectionUtilites
{
    public class ReflectionClass
    {
        private readonly Type _BaseType; 
        private readonly ReflectionAttributeList _Attributes;
        private readonly ReflectionPropertyList _Properties;
        private readonly string _Name;
        private readonly string _FullName;

        public ReflectionClass(Type type)
        {
            _Attributes = new ReflectionAttributeList(type.GetCustomAttributes(true).OfType<Attribute>().ToList());
            _BaseType = type;
            _Properties = new ReflectionPropertyList(type.GetProperties().ToList(), this);
            _Name = type.Name;
            _FullName = type.FullName;
        }

        public Type BaseType
        {
            get { return _BaseType; }
        }

        public String Name
        {
            get { return _Name; }
        }
        public String FullName
        {
            get { return _FullName; }
        }

        public ReflectionPropertyList Properties
        {
            get { return _Properties; }
        }

        public ReflectionAttributeList Attributes
        {
            get { return _Attributes; }
        }
    }
}
