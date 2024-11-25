using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }
        [Required]
        [Range(15, 80)]
        public int Age { get; set; }
        [Required]
        public DateTime DOJ { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public string Password { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; } = DateTime.Now;
    }
}
