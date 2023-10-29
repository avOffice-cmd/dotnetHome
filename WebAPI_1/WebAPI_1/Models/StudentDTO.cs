using System.ComponentModel.DataAnnotations;
using WebAPI_1.Validators;

namespace WebAPI_1.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        [StringLength(50)]
        // if u do not want to validate any field then u can use [ValidateNever]

        public string StudentName { get; set; }

        [EmailAddress (ErrorMessage = "Plz enter valid Email")]

        public string Email { get; set; }

        [Required]
        public int Phone { get; set; }



        // custom validation
        //[DateCheck]
      //  public DateTime AdmissionDate { get; set; }

        //[Range(10, 20)]
        //public int Age {  get; set; }


        //public String Password { get; set; }

        //[Compare(nameof(Password))]
        //public string ConfirmPassword { get; set; }
    }
      
}
