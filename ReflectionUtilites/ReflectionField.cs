using ReflectionUtilites.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionUtilites
{
    public class ReflectionField
    {
        #region Constants and Fields

        private readonly ReflectionAttributeList attributes;

        private readonly string name;

        private readonly ReflectionClass parent;

        private readonly FieldInfo field;

        private readonly Type fieldType;

        #endregion

        #region Constructors and Destructors

        internal ReflectionField(FieldInfo field, ReflectionClass parent)
        {
            this.field = field;
            this.parent = parent;

            this.attributes =
                new ReflectionAttributeList(this.field.GetCustomAttributes(true).OfType<Attribute>().ToList());
            this.name = this.field.Name;
            this.fieldType = this.field.FieldType;

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

        public Type FieldType
        {
            get
            {
                return this.fieldType;
            }
        }

        public string WithClassName
        {
            get
            {
                return this.parent.Name + "." + this.name;
            }
        }
        public FieldInfo Field
        {
            get
            {
                return field;
            }
        }

        #endregion
        #region Public Methods

        public object GetValue(object from)
        {
            if (this.field == null)
            {
                throw new NoSuchMethodReflectionException();
            }
            return this.field.GetValue(from);
        }

        public void SetValue(object to, object what)
        {
            if (this.field == null)
            {
                throw new NoSuchMethodReflectionException();
            }
            this.SetValue(to, new[] { what });
        }
        #endregion
    }
}
