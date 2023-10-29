namespace WebAPI_1.Models
{
    public class CollegeRepository
    {
        public static IList<Student> Students { get; set; } = new List<Student>
        {
            new Student
            {
                Id = 1,
                StudentName = "Test",
                Email = "test@gmail.com",
                Phone = 643789009
            },
            new Student
            {
                Id = 2, // Changed to a different ID, as it was 1 for both students
                StudentName = "AnotherTest",
                Email = "anothertest@gmail.com",
                Phone = 123456789
            }
        };
    }
}
