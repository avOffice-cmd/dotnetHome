using System.ComponentModel.DataAnnotations;

namespace practice.Model
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_Name { get; set; }

        public DateTime createdAt { get; set; }
    }
}
