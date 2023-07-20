namespace ReflectionUtilities
{
    using System;
    using System.Reflection;

    public class ReflectionMethod
    {
        private ReflectionClass returnType;
        private ReflectionAttributeList attributes;
        private ParameterInfo[] parameters;
        private string name;

        public MethodInfo BaseMethod { get; }
        public ReflectionClass ParentType { get; }

        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    this.name = this.BaseMethod.Name;
                }
                return this.name;
            }
        }

        public ParameterInfo[] Parameters
        {
            get
            {
                if (this.parameters == null)
                {
                    this.parameters = this.BaseMethod.GetParameters();
                }
                return this.parameters;
            }
        }

        public ReflectionAttributeList Attributes
        {
            get
            {
                if (this.attributes == null)
                {
                    this.attributes = new ReflectionAttributeList(this.BaseMethod.GetCustomAttributes(true));
                }
                return this.attributes;
            }
        }

        public ReflectionClass ReturnType
        {
            get
            {
                if (this.returnType == null)
                {
                    this.returnType = ReflectionCache.GetReflection(this.BaseMethod.ReturnType);
                }
                return this.returnType;
            }
        }


        public string FullName => this.ParentType.FullName + "." + this.Name;
        public string WithClassName => this.ParentType.Name + "." + this.Name;

        internal ReflectionMethod(MethodInfo method, ReflectionClass parent)
        {
            this.BaseMethod = method;
            this.ParentType = parent;
        }

        public object Invoke(object obj, params object[] param)
        {
            return this.BaseMethod.Invoke(obj, param);
        }
    }
}
