using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.OvetimePolicies.Services
{
    public class CalcurlatorA : ICalculateInterface
    {
      
        public int OverTimeCalculator(int BasicSalary, int Allowance)
        {
            return BasicSalary * Allowance + 25000000;
        }
    }
}
