using System.Reflection;

namespace ReflectionUtilities
{
    public class ReflectionConstructor
    {
        private ReflectionAttributeList attributes;
        private ParameterInfo[] parameters;
        private string name;

        public ReflectionClass ParentType { get; }
        public ConstructorInfo BaseConstructor { get; }

        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    this.name = this.BaseConstructor.Name;
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
                    this.parameters = this.BaseConstructor.GetParameters();
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
                    this.attributes = new ReflectionAttributeList(this.BaseConstructor.GetCustomAttributes(true));
                }
                return this.attributes;
            }
        }

        public string FullName => this.ParentType.FullName + "." + this.Name;
        public string WithClassName => this.ParentType.Name + "." + this.Name;

        internal ReflectionConstructor(ConstructorInfo method, ReflectionClass parent)
        {
            this.BaseConstructor = method;
            this.ParentType = parent;
        }

        public object Invoke(params object[] param)
        {
            return this.BaseConstructor.Invoke(param);
        }
    }
}
