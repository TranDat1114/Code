using System.ComponentModel.DataAnnotations;

namespace Lab_5_3_Net_4.Models
{
    public class Employee
    {
        [Display(Name = "Serial No")]
        public Guid EmployeeId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
