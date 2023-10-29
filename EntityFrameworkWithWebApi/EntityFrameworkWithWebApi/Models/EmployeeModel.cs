namespace EntityFrameworkWithWebApi.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }  // taken as primary key by default

        // [Key]
        public string FullName { get; set; }

        public long Salary { get; set; }

    
    }
}
