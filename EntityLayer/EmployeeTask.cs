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
    public class EmployeeTask
    {
        [Key]
        public int TaskID { get; set; }
        public string EmployeeCode { get; set; }
        [Required]
        [DisplayName("Task Name")]
        public string TaskName { get; set; }
        [Required]
        [DisplayName("Task Status")]
        public string TaskStatus { get; set; }
        [Required]
        [DisplayName("Task Description")]
        public string TaskDescription { get; set; }
     
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; } = DateTime.Now;
    }
}
