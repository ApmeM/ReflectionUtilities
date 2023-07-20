using System;
using System.Linq;
using System.Reflection;

namespace ReflectionUtilities
{
    public class ReflectionConstructor
    {
        private readonly ConstructorInfo constructor;

        public ReflectionClass Parent { get; }
        public ConstructorInfo Constructor { get; }
        public string Name { get; }
        public ParameterInfo[] Parameters { get; }
        public ReflectionAttributeList Attributes { get; }

        public string FullName => this.Parent.FullName + "." + this.Name;
        public string WithClassName => this.Parent.Name + "." + this.Name;

        internal ReflectionConstructor(ConstructorInfo method, ReflectionClass parent)
        {
            this.constructor = method;
            this.Parent = parent;

            this.Attributes = new ReflectionAttributeList(this.constructor.GetCustomAttributes(true));
            this.Name = this.constructor.Name;
            this.Parameters = this.constructor.GetParameters();
        }

        public object Invoke(params object[] param)
        {
            return this.constructor.Invoke(param);
        }
    }
}
