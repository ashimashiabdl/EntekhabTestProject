using Hr.WebAPI.Dapper;
using Hr.WebAPI.Model;
using HR.OvetimePolicies;
using HR.OvetimePolicies.data;
using HR.OvetimePolicies.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Hr.WebAPI.Controllers
{
    [Route("{datatype}/api/[controller]")]
    [ApiController]
    public class OverTimeCalculatorController : ControllerBase
    {
        private readonly ICalculatorsService _CalculatorsService;
        private readonly IDapper _dapper;

        public OverTimeCalculatorController(ICalculatorsService CalculatorsService, IDapper dapper)
        {
            _CalculatorsService = CalculatorsService;
            _dapper = dapper;
        }
        [HttpPost, Route("Add")]
        public IActionResult Add([FromBody] AddRequestBody id)
        {
            return Ok(_CalculatorsService.SalaryCalculator(id, HttpContext.Request.RouteValues["datatype"].ToString()));
        }


        [HttpPut, Route("Update")]
        public IActionResult Update([FromBody] AddRequestBody id)
        {
            return Ok(_CalculatorsService.UpdateSelectedMonthSalary(id, HttpContext.Request.RouteValues["datatype"].ToString()));
        }


        [HttpDelete, Route("Delete")]
        public IActionResult Delete([FromBody] AddRequestBody id)
        {
            return Ok(_CalculatorsService.DeleteSelectedMonthSalary(id, HttpContext.Request.RouteValues["datatype"].ToString()));
        }

        [HttpGet, Route("Get/{firstname}/{lastname}/{month}/")]
        public async Task<EmployeeMonthlySalary> Get(string firstname, string lastname, string month)
        {
            var q = $"SELECT * FROM [TestProject].[emp].[Employee_Monthly_Salary] s inner join [emp].[Employee] e on s.EmployeeId = e.id  where FirstName = '{firstname}' and LastName = '{lastname}' and s.[Month] = {month} ";
            var result = await Task.FromResult(_dapper.Get<EmployeeMonthlySalary>(q, null, commandType: CommandType.Text));
            return result;
        }



        [HttpGet, Route("GetRange/{firstname}/{lastname}/{dateStart}/{dateEnd}")]
        public async Task<EmployeeMonthlySalary> GetRange(string firstname, string lastname, DateTime dateStart, DateTime dateEnd)
        {
            var q = $"SELECT * FROM [TestProject].[emp].[Employee_Monthly_Salary] s inner join [emp].[Employee] e on s.EmployeeId = e.id  where FirstName = '{firstname}' and LastName = '{lastname}' and s.[Date] between '{dateStart}' and '{dateEnd}' ";
            var result = await Task.FromResult(_dapper.Get<EmployeeMonthlySalary>(q, null, commandType: CommandType.Text));
            return result;
        }
    }
}
