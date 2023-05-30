using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HR.OvetimePolicies.Services.ConvertorFactory
{
    public class ConvertFromCustomFormat : IFactory
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
                    propertyInfo.SetValue(obj,System.Convert.ToInt32(value), null);
                }
            }
        }
        public CalculatorRequest Convert(string UserData)
        {
            var firstLine = UserData.Split('\n');

            var paramlist = firstLine[0].Split('/');
            var valueList = firstLine[1].Split('/');
            CalculatorRequest ret =new CalculatorRequest();

            int i = 0;
            foreach (var item in paramlist)
            {
                foreach (var Property in ret.GetType().GetProperties())
                {
                    if (item.Trim().ToLower() == Property.Name.ToLower())
                    {
                        SetObjectProperty(Property.Name, valueList[i], ret);
                    }
                }
                i++;
            }


            return ret;
        }
    }
}
