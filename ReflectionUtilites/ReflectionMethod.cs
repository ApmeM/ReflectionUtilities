namespace ReflectionUtilites
{
    using System;
    using System.Reflection;

    public class ReflectionMethod
    {
        private readonly MethodInfo method;

        private readonly ReflectionClass parent;

        private readonly string name;

        private ParameterInfo[] parameters;

        internal ReflectionMethod(MethodInfo method, ReflectionClass parent)
        {
            this.method = method;
            this.parent = parent;

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

        public object Invoke(object obj, params object[] param)
        {
            return this.method.Invoke(obj, param);
        }
    }
}