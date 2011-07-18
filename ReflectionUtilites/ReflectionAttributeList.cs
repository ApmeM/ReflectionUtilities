namespace ReflectionUtilites
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class ReflectionAttributeList : List<Attribute>
    {
        #region Constructors and Destructors

        internal ReflectionAttributeList(List<Attribute> attributes)
        {
            this.AddRange(attributes);
        }

        #endregion

        #region Indexers

        public Attribute this[Type type]
        {
            get
            {
                return (from attr in this where attr.GetType() == type select attr).FirstOrDefault();
            }
        }

        #endregion
    }
}