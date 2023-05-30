using HR.OvetimePolicies;

namespace Hr.WebAPI.Model
{
    public class AddRequestBody
    {
        public string data { get; set; }
        public string overTimeCalculator { get; set; }
        public CalculatorRequest XMLData { get; set; }
    }
}
