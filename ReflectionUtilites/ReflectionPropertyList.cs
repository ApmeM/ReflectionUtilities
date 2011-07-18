namespace ReflectionUtilites
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    #endregion

    public class ReflectionPropertyList : List<ReflectionProperty>
    {
        #region Constructors and Destructors

        internal ReflectionPropertyList(List<PropertyInfo> properties, ReflectionClass parent)
        {
            this.AddRange(from property in properties select new ReflectionProperty(property, parent));
        }

        #endregion
    }
}