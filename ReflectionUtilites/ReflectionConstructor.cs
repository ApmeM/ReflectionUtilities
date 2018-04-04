using ReflectionUtilites.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReflectionUtilites
{
    public class ReflectionConstructor
    {
        private readonly ConstructorInfo constructor;

        private readonly ReflectionClass parent;

        private readonly string name;

        private readonly ParameterInfo[] parameters;

        private readonly ReflectionAttributeList attributes;

        //  private readonly Type returnType;

        internal ReflectionConstructor(ConstructorInfo method, ReflectionClass parent)
        {
            this.constructor = method;
            this.parent = parent;

            // this.returnType = this.constructor..ReturnType;
            this.attributes =
                new ReflectionAttributeList(this.constructor.GetCustomAttributes(true).OfType<Attribute>().ToList());
            this.name = this.constructor.Name;
            this.parameters = this.constructor.GetParameters();
        }
        public string FullName
        {
            get
            {
                return this.parent.FullName + "." + this.name;
            }
        }

        public ConstructorInfo Constructor
        {
            get
            {
                return constructor;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string WithClassName
        {
            get
            {
                return this.parent.Name + "." + this.name;
            }
        }

        public ParameterInfo[] Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        public ReflectionAttributeList Attributes
        {
            get
            {
                return this.attributes;
            }
        }


        public object Invoke(params object[] param)
        {
            if (this.constructor == null)
            {
                throw new NoSuchMethodReflectionException();
            }
            return this.constructor.Invoke(param);
        }
    }
}
