using Hr.WebAPI.Model;

namespace HR.OvetimePolicies.Services
{
    public interface ICalculatorsService
    {
        /// <summary>
        /// این متد بر اساس پارامتر های ارسالی کاربر مقدار حقوق را محاسبه و در پایگاه داده ذخیره می کند
        /// </summary>
        /// <param name="Body"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        OperationResult SalaryCalculator(AddRequestBody Body, string datatype);
        /// <summary>
        /// این متد بر اساس پارامتر هار ورودی اطلاعات ماه مورد نظر را ویرایش می کند
        /// </summary>
        /// <param name="Body"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        OperationResult UpdateSelectedMonthSalary(AddRequestBody Body, string datatype);
        /// <summary>
        /// این متد ردیف ماه مورد نظر که کاربر ارسال کرده را حذف می کند
        /// </summary>
        /// <param name="Body"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        OperationResult DeleteSelectedMonthSalary(AddRequestBody Body, string datatype);
    }
}
