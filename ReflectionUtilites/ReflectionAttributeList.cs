using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilites.ReflectionUtilites
{
    public class ReflectionAttributeList: List<Attribute>
    {
        public ReflectionAttributeList(List<Attribute> attributes)
        {
            AddRange(attributes);
        }

        public Attribute this[Type index]
        {
            get
            {
                return (from attr in this
                        where attr.GetType() == index
                        select attr).FirstOrDefault();
            }
        }
    }
}
