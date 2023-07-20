namespace ReflectionUtilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class ReflectionMethod
    {
        public MethodInfo BaseMethod { get; }

        public string Name { get; }
        public ParameterInfo[] Parameters { get; }
        public ReflectionAttributeList Attributes { get; }
        public Type ReturnType { get; }
        public ReflectionClass Parent { get; }

        public string FullName => this.Parent.FullName + "." + this.Name;
        public string WithClassName => this.Parent.Name + "." + this.Name;

        internal ReflectionMethod(MethodInfo method, ReflectionClass parent)
        {
            this.BaseMethod = method;
            this.Parent = parent;

            this.ReturnType = this.BaseMethod.ReturnType;
            this.Attributes = new ReflectionAttributeList(this.BaseMethod.GetCustomAttributes(true));
            this.Name = this.BaseMethod.Name;
            this.Parameters = this.BaseMethod.GetParameters();
        }

        public object Invoke(object obj, params object[] param)
        {
            return this.BaseMethod.Invoke(obj, param);
        }
    }
}
