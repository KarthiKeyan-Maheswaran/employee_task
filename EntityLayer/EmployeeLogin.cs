
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EmployeeLogin
    {
        [Required]
        public string EmployeeCode { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
