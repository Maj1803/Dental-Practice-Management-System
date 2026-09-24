using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTKhan_Dentist.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }

        public string Employee_First_Name { get; set; }
        public string Employee_Last_Name { get; set; }
        public string Employee_Role { get; set; }
        public string Employee_Phone_Number { get; set; }
        public string Employee_Email { get; set; }
        public string Employee_Username { get; set; }
        public string Employee_Password { get; set; }
        public string Employee_National_ID { get; set; }
        public int? Employee_Age { get; set; }

        // The new FK column you added in Step 6
        public string AspNetUserId { get; set; }
    }
}