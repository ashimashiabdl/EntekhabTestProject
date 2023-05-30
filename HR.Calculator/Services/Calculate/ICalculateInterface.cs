using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.OvetimePolicies.Services
{
    public interface ICalculateInterface
    {
        /// <summary>
        /// این متد بر اساس پارامتر های وروی بخشی از حقوق ماهانه را محاسبه می کند
        /// </summary>
        /// <param name="BasicSalary">حقوق پایه</param>
        /// <param name="Allowance">فوق العاده حق جذب</param>
        /// <returns></returns>
        int OverTimeCalculator(int BasicSalary, int Allowance);
    }
}
