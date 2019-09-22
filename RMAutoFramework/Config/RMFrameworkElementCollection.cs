using System.Configuration;

namespace RMAutoFramework.Config
{
    [ConfigurationCollection(typeof(RMFrameworkElement), AddItemName = "testSetting", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class RMFrameworkElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RMFrameworkElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as RMFrameworkElement).Name;
        }

        public new RMFrameworkElement this[string type]
        {
            get
            {
                return (RMFrameworkElement)base.BaseGet(type);
            }
        }
    }
}
