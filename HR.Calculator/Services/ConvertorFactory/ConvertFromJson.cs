using HR.OvetimePolicies.Services.ConvertorFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HR.OvetimePolicies.Services.Convertor
{
    public class ConvertFromJson : IFactory
    {
        public CalculatorRequest Convert(string UserInput)
        {
            return JsonSerializer.Deserialize<CalculatorRequest>(UserInput);
        }
    }
}
