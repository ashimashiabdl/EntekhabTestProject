using HR.OvetimePolicies.Services.ConvertorFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HR.OvetimePolicies.Services.Convertor
{
    internal class ConvertFromCommaSeparator : IFactory
    {
        private void SetObjectProperty(string propertyName, string value, object obj)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            // make sure object has the property we are after
            if (propertyInfo != null)
            {

                if (propertyInfo.PropertyType == typeof(string))
                {
                    propertyInfo.SetValue(obj, value, null);
                }
                if (propertyInfo.PropertyType == typeof(int))
                {
                    propertyInfo.SetValue(obj, System.Convert.ToInt32(value), null);
                }
            }
        }
        public CalculatorRequest Convert(string UserInput)
        {
            var ret = new CalculatorRequest();
            var rows = UserInput.Split('\n');
            foreach (var item in rows)
            {
                foreach (var Property in ret.GetType().GetProperties())
                {
                    if (item.Split(',')[0].Trim().ToLower() == Property.Name.ToLower())
                    {
                        SetObjectProperty(Property.Name, item.Split(',')[1].Trim().ToLower(), ret);
                    }
                }
            }
            return ret;
        }
    }
}
