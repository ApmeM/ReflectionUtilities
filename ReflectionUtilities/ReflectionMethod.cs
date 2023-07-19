namespace ReflectionUtilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class ReflectionMethod
    {
        private readonly MethodInfo method;

        public string Name { get; }
        public ParameterInfo[] Parameters { get; }
        public ReflectionAttributeList Attributes { get; }
        public Type ReturnType { get; }
        public ReflectionClass Parent { get; }

        public string FullName => this.Parent.FullName + "." + this.Name;
        public string WithClassName => this.Parent.Name + "." + this.Name;

        internal ReflectionMethod(MethodInfo method, ReflectionClass parent)
        {
            this.method = method;
            this.Parent = parent;

            this.ReturnType = this.method.ReturnType;
            this.Attributes =
                new ReflectionAttributeList(this.method.GetCustomAttributes(true).OfType<Attribute>().ToList());
            this.Name = this.method.Name;
            this.Parameters = this.method.GetParameters();
        }

        public object Invoke(object obj, params object[] param)
        {
            return this.method.Invoke(obj, param);
        }
    }
}
