using System;
using System.Linq;
using System.Reflection;

namespace Utilites.ReflectionUtilites
{
    public class ReflectionProperty
    {
        private readonly ReflectionAttributeList _Attributes;
        private readonly PropertyInfo _BaseProperty;
        private readonly ReflectionClass _Parent;
        private readonly string _Name;
        private readonly Type _PropertyType;

        public ReflectionProperty(PropertyInfo property, ReflectionClass parent)
        {
            _Attributes = new ReflectionAttributeList(property.GetCustomAttributes(true).OfType<Attribute>().ToList());
            _BaseProperty = property;
            _Parent = parent;
            _Name = property.Name;
            _PropertyType = property.PropertyType;
        }

        public ReflectionAttributeList Attributes
        {
            get { return _Attributes; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public Type PropertyType
        {
            get { return _PropertyType; }
        }

        public string WithClassName
        {
            get { return _Parent.Name + "." + _Name; }
        }

        public string FullName
        {
            get { return _Parent.FullName + "." + _Name; }
        }

        public void SetValue(Object where, Object what)
        {
            if(where == null)
                return;
            if (where.GetType() != _Parent.BaseType)
                return;
            _BaseProperty.SetValue(where, Convert.ChangeType(what, _PropertyType), null);
        }

        public Object GetValue(Object where)
        {
            if (where == null)
                return null;
            if (where.GetType() != _Parent.BaseType)
                return null;
            return _BaseProperty.GetValue(where, null);
        }
    }
}
