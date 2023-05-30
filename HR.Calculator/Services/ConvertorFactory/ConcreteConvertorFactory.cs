using HR.OvetimePolicies.Services.Convertor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.OvetimePolicies.Services.ConvertorFactory
{
    public abstract class ConvertorFactory
    {
        public abstract IFactory GetConvertor(string Convertor);

    }
    public class ConcreteConvertorFactory : ConvertorFactory
    {
        public override IFactory GetConvertor(string Convertor)
        {
            switch (Convertor)
            {
                case "json":
                    return new ConvertFromJson();
                case "xml":
                    return new ConvertFromXML();
                case "CommaSeparator":
                    return new ConvertFromCommaSeparator();
                case "CustomFormat":
                    return new ConvertFromCustomFormat();
                default:
                    throw new ApplicationException(string.Format("Convertor '{0}' cannot be created", Convertor));
            }
        }

    }


    public interface IFactory
    {
        CalculatorRequest Convert(string UserData);
    }
}
