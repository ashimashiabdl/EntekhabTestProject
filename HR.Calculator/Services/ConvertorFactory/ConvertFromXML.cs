using HR.OvetimePolicies.Services.ConvertorFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HR.OvetimePolicies.Services.Convertor
{
    public class ConvertFromXML : IFactory
    {
        public CalculatorRequest Convert(string UserInput)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(CalculatorRequest));
            //MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(UserInput));
            //CalculatorRequest resultingMessage = (CalculatorRequest)serializer.Deserialize(memStream);
            return null;
        }
    }
}
