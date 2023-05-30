using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.OvetimePolicies
{
    public class CalculatorRequest
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        /// <summary>
        /// حقوق پایه
        /// </summary>
        public int basicsalary { get; set; }
        /// <summary>
        /// حق جذب
        /// </summary>
        public int allowance { get; set; }
        /// <summary>
        /// ایاب و ذهاب
        /// </summary>
        public int transportation { get; set; }
        public int calculatedsalary { get; set; }
        public string date { get; set; }
    }
}
