namespace ReflectionUtilites
{
    using System;
    using System.Linq;
    using System.Reflection;

    using ReflectionUtilites.Exceptions;

    public class ReflectionMethod
    {
        private readonly MethodInfo method;

        private readonly ReflectionClass parent;

        private readonly string name;

        private readonly ParameterInfo[] parameters;

        private readonly ReflectionAttributeList attributes;

        private readonly Type returnType;

        internal ReflectionMethod(MethodInfo method, ReflectionClass parent)
        {
            this.method = method;
            this.parent = parent;

            this.returnType = this.method.ReturnType;
            this.attributes =
                new ReflectionAttributeList(this.method.GetCustomAttributes(true).OfType<Attribute>().ToList());
            this.name = this.method.Name;
            this.parameters = this.method.GetParameters();
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

        public Type ReturnType
        {
            get
            {
                return this.returnType;
            }
        }

        public object Invoke(object obj, params object[] param)
        {
            if (this.method == null)
            {
                throw new NoSuchMethodReflectionException();
            }
            if (obj != null)
            {
                if (obj.GetType() != this.parent.BaseType)
                {
                    throw new WrongObjectReflectionException(this.parent.BaseType, obj.GetType());
                }
            }
            return this.method.Invoke(obj, param);
        }
    }
}
