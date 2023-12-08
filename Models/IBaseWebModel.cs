using System.Reflection;

namespace UniBase.Models
{
    public class IBaseWebModel<T> : Object
    {
        private PropertyInfo[] GetPropertiesInfo()
        {
            var type = typeof(T);

            PropertyInfo[] properties = type.GetProperties();
            return properties;
        }
        public virtual List<object> toList()
        {
            List<object> result = new List<object>();
            foreach (PropertyInfo field in GetPropertiesInfo())
            {
                result.Add(field.GetValue(this));
            }
            return result;
        }
        public List<string> ModelField()
        {
            List<string> result = new List<string>();
            foreach (PropertyInfo field in GetPropertiesInfo())
            {
                result.Add(field.Name);
            }
            return result;
        }

    }
}
