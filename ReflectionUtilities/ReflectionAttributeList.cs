namespace ReflectionUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReflectionAttributeList : List<Attribute>
    {
        internal ReflectionAttributeList(List<Attribute> attributes)
        {
            this.AddRange(attributes);
        }

        public List<Attribute> this[Type type] => this.Where(a => a.GetType() == type).ToList();
    }
}