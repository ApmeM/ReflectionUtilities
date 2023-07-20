namespace ReflectionUtilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReflectionAttributeList : List<Attribute>
    {
        internal ReflectionAttributeList(object[] attributes)
        {
            foreach (var attr in attributes)
            {
                this.Add((Attribute)attr);
            }
        }

        public List<Attribute> this[Type type] => this.Where(a => a.GetType() == type).ToList();
    }
}