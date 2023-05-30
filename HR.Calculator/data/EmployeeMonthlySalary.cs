using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.OvetimePolicies.data
{
    [Table("Employee_Monthly_Salary", Schema = "emp")]
    public class EmployeeMonthlySalary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public int BasicSalary { get; set; }
        public int Allowance { get; set; }
        public int Transportation { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [StringLength(50)]
        public string UserSendedDate { get; set; }
        public int CalculatedSalary { get; set; }
        public int Month { get; set; }
    }
}
