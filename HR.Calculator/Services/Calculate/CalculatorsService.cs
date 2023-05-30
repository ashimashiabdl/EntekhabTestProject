using Azure.Core;
using Hr.WebAPI.Model;
using HR.OvetimePolicies.data;
using HR.OvetimePolicies.Services.ConvertorFactory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HR.OvetimePolicies.Services
{
    public class CalculatorsService : ICalculatorsService
    {
        EmployeeContext _EmployeeContext;
        private ICalculateInterface Calculator;
        private const int TaxValue = 1500;
        public CalculatorsService(EmployeeContext EmployeeContext)
        {
            _EmployeeContext = EmployeeContext;
        }
        /// <summary>
        /// این متد برای تمام سرویس ها بر اساس پارامتر ورودی کار بر یک اینستنس میسازد و ارسال می کند
        /// </summary>
        /// <param name="Body"></param>
        /// <param name="datatype"></param>
        /// <returns></returns>
        private CalculatorRequest GetInstanceFromInput(AddRequestBody Body, string datatype)
        {
            ConcreteConvertorFactory factory = new ConcreteConvertorFactory();
            var Convertor = factory.GetConvertor(datatype);
            if (datatype == "xml")
            {
                return Body.XMLData;
            }
            else
            {
                return Convertor.Convert(Body.data);
            }
        }
        public OperationResult SalaryCalculator(AddRequestBody Body, string datatype)
        {
            CalculatorRequest Request = GetInstanceFromInput(Body, datatype);
            var CurrentEmployee = _EmployeeContext.Employees.Where(i => i.FirstName == Request.firstname && i.LastName == Request.lastname);
            if (CurrentEmployee != null)
            {
                if (CurrentEmployee.Any())
                {
                    var SingleEmployee = CurrentEmployee.SingleOrDefault();
                    EmployeeMonthlySalary NewSalary = new EmployeeMonthlySalary();
                    NewSalary.EmployeeId = SingleEmployee.Id;
                    switch (Body.overTimeCalculator.ToLower())
                    {
                        case "calcurlatora":
                            Calculator = new CalcurlatorA();
                            break;
                        case "calcurlatorb":
                            Calculator = new CalcurlatorB();
                            break;
                        case "calcurlatorc":
                            Calculator = new CalcurlatorC();
                            break;
                    }
                    NewSalary.CalculatedSalary = (Request.basicsalary + Request.allowance + Calculator.OverTimeCalculator(Request.basicsalary, Request.allowance)) - TaxValue;
                    NewSalary.Date = ConvertShamsiToMiladi(Request.date);
                    NewSalary.Month = Convert.ToInt32(Request.date.Substring(4, 2));
                    NewSalary.UserSendedDate = Request.date;
                    NewSalary.BasicSalary = Request.basicsalary;
                    NewSalary.Allowance = Request.allowance;
                    NewSalary.Transportation = Request.transportation;
                    var CurrentMonth = _EmployeeContext.EmployeeMonthlySalarys.Where(i => i.EmployeeId == SingleEmployee.Id && i.Month == NewSalary.Month);

                    if (CurrentMonth.Any())
                    {
                       return OperationResult.Existed();
                    }

                    _EmployeeContext.EmployeeMonthlySalarys.Add(NewSalary);
                    _EmployeeContext.SaveChanges();
                    return OperationResult.Succeeded();
                }
                else
                {
                    return OperationResult.NotFound("پرسنل مورد نظر یافت نشد");
                }
            }
            return OperationResult.Failed();
        }
        public DateTime ConvertShamsiToMiladi(string date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.ToDateTime(Convert.ToInt32(date.Substring(0, 4)), Convert.ToInt32(date.Substring(4, 2)), Convert.ToInt32(date.Substring(6, 2)), 0, 0, 0, 0);
        }

        public OperationResult UpdateSelectedMonthSalary(AddRequestBody Body, string datatype)
        {
            CalculatorRequest Request = GetInstanceFromInput(Body, datatype);
            var CurrentEmployee = _EmployeeContext.Employees.Where(i => i.FirstName == Request.firstname && i.LastName == Request.lastname  );
            if (CurrentEmployee != null)
            {
                if (CurrentEmployee.Any())
                {
                    var SingleEmployee = CurrentEmployee.SingleOrDefault();
                    int Month = Convert.ToInt32(Request.date.Substring(4, 2));
                    var SelectedMonthRecord = _EmployeeContext.EmployeeMonthlySalarys.Where(i => i.EmployeeId == SingleEmployee.Id && i.Month == Month);

                    if (SelectedMonthRecord != null)
                    {
                        if (SelectedMonthRecord.Any())
                        {
                            var singleRecord = SelectedMonthRecord.SingleOrDefault();
                            singleRecord.CalculatedSalary = Request.calculatedsalary;
                            singleRecord.Date = ConvertShamsiToMiladi(Request.date);
                            singleRecord.Month = Convert.ToInt32(Request.date.Substring(4, 2));
                            singleRecord.UserSendedDate = Request.date;
                            singleRecord.BasicSalary = Request.basicsalary  ;
                            singleRecord.Allowance = Request.allowance;
                            singleRecord.Transportation = Request.transportation;

                            _EmployeeContext.EmployeeMonthlySalarys.Update(singleRecord);
                            if (_EmployeeContext.SaveChanges() > 0)
                            {
                                return OperationResult.Succeeded();
                            }

                        }
                        else
                        {
                            return OperationResult.NotFound();
                        }
                    }
                    else
                    {
                        return OperationResult.NotFound();
                    }
                }
            }

            return OperationResult.Failed();
        }

        public OperationResult DeleteSelectedMonthSalary(AddRequestBody Body, string datatype)
        {
            CalculatorRequest Request = GetInstanceFromInput(Body, datatype);
            var CurrentEmployee = _EmployeeContext.Employees.Where(i => i.FirstName == Request.firstname && i.LastName == Request.lastname);
            if (CurrentEmployee != null)
            {
                if (CurrentEmployee.Any())
                {
                    var SingleEmployee = CurrentEmployee.SingleOrDefault();
                    int Month = Convert.ToInt32(Request.date.Substring(4, 2));
                    var SelectedMonthRecord = _EmployeeContext.EmployeeMonthlySalarys.Where(i => i.EmployeeId == SingleEmployee.Id && i.Month == Month);

                    if (SelectedMonthRecord != null)
                    {
                        if (SelectedMonthRecord.Any())
                        {
                            var singleRecord = SelectedMonthRecord.SingleOrDefault();
                            _EmployeeContext.EmployeeMonthlySalarys.Remove(singleRecord);
                            if (_EmployeeContext.SaveChanges() > 0)
                            {
                                return OperationResult.Succeeded();
                            }
                        }
                        else
                        {
                            return OperationResult.NotFound();
                        }
                    }
                    else
                    {
                        return OperationResult.NotFound();
                    }
                }
            }
            return OperationResult.Failed();
        }
    }
}
