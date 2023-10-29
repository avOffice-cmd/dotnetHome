using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPI_1.Models;

namespace WebAPI_1.Controllers
{
    [ApiController]
    [Route("[controller]")]




    public class StudentController : ControllerBase
    {
        [ProducesResponseType(201)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]  // Bad request
        [ProducesResponseType(400)]  // Not Found
        [ProducesResponseType(500)] // internalServerError


        // GET ALL STUDENTS //
        [HttpGet("All", Name = "GetAllStudents")]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {

            #region
            //var students = new List<StudentDTO>();
            //foreach (var item in CollegeRepository.Students)
            //{
            //    StudentDTO obj = new StudentDTO()
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Email = item.Email,
            //        Phone = item.Phone,

            //    };
            //    students.Add(obj);
            //}

            #endregion


            // USING LINQ
            var students = CollegeRepository.Students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                StudentName = s.StudentName,
                Email = s.Email,
                Phone = s.Phone
            });

            // ok - 200 status
            //return CollegeRepository.Students;
            return Ok(students);
        }




        // GET STUDENT BY ID //
        [HttpGet("{id:int}", Name = "GetStudentById")]
        public ActionResult<StudentDTO> GetStudentById(int id)
        {
            #region
            //var student = CollegeRepository.Students.FirstOrDefault(n => n.Id == id);
            //if (student == null)
            //{
            //    return NotFound(); // Return a 404 Not Found if the student is not found.
            //return NotFound("The student with id {id} not found ");

            //}
            //return student;

            // OR //
            #endregion
            // BAD REQUEST 404 - client error
            if (id <= 0)
                return BadRequest();

            var student = CollegeRepository.Students.FirstOrDefault(n => n.Id == id);
            if (student == null)
                return NotFound("The student with id {id} not found ");

            var StudentDTO = new StudentDTO
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Email = student.Email,
                Phone = student.Phone
            };

            // OK - 200 -SUCCESS
            return Ok(StudentDTO);

        }



        // GET STUDENT BY NAME //
        [HttpGet("ByName/{name}", Name = "GetStudentByName")]
        //[HttpGet("ByName/{name:alpha}", Name = "GetStudentByName")]
        public ActionResult<StudentDTO> GetStudentByName(string name)
        {

            if (string.IsNullOrEmpty(name))
                return BadRequest();


            var student = CollegeRepository.Students.FirstOrDefault(n => n.StudentName == name);
            if (student == null)
                return NotFound(); // Return a 404 Not Found if the student is not found.

            var StudentDTO = new StudentDTO
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Email = student.Email,
                Phone = student.Phone
            };

            // OK - 200 -SUCCESS
            return Ok(StudentDTO);

        }






        // POST REQUEST TO CREATE NEW STUDENT  //

        [HttpPost]
        [Route("Create")]
        // here my route will be --==--> api/student/create <--==--     
        public ActionResult<StudentDTO> CreateStudent([FromBody] StudentDTO model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            // VALIADTE DATE //
            //if (model.AdmissionDate < DateTime.Now)
            //{
            //    // 1. Directly Adding Error  Messgae To ModelState
            //    // 2. Using Custom Attribute
            //    ModelState.AddModelError("Admission Error", "Admission Date Must Be Greater Than Or equals To Todays Date");
            //    return BadRequest(ModelState);
            //}



            // Find the maximum existing student ID and increment it by 1 for the new student
            int newId = CollegeRepository.Students.Max(s => s.Id) + 1;
            // int newId = CollegeRepository.Students.LastOrDefault().Id+ 1;


            // Create the new student
            Student student = new Student
            {
                Id = newId,
                StudentName = model.StudentName,
                Email = model.Email,
                Phone = model.Phone
            };

            CollegeRepository.Students.Add(student);

            // Update the model with the newly assigned ID
            model.Id = student.Id;


            //Status -201
            //https://locahhost:2314/api/students/3
            return CreatedAtRoute("GetStudentById", new { id = model }, model);

            // Return the created student
            // return Ok(model);
        }






        // HTTP PUT OR HTTP PATCH THIS TWO WILL USE TO UPDATE THE RECORD //

        [HttpPut]
        [Route("update/{id:int}")]
        public ActionResult UpdateStudent(int id, [FromBody] StudentDTO model)
        {

            if (model == null || model.Id <= 0)
            {
                BadRequest();
            }
            // Find the student with the specified ID
            Student existingStudent = CollegeRepository.Students.FirstOrDefault(s => s.Id == id);

            if (existingStudent == null)
            {
                return NotFound(); // Return a 404 Not Found if the student is not found.
            }

            // Update the existing student with the data from the model
            existingStudent.StudentName = model.StudentName;
            existingStudent.Email = model.Email;
            existingStudent.Phone = model.Phone;

            // You can save changes to a database or data store here if needed.
            // return Ok(existingStudent); if we update the record we don't want to return anything
            return NoContent(); // 204 is the status
        }


        [HttpPatch]
        [Route("updatePartial/{id:int}")]
        //api/ student/id/UpdatePartial
        public ActionResult UpdateStudentPartial(int id, [FromBody] JsonPatchDocument<StudentDTO> PatchDocument)
        {

            if (PatchDocument == null || id <= 0)
            {
                BadRequest();
            }
            // Find the student with the specified ID
            Student existingStudent = CollegeRepository.Students.FirstOrDefault(s => s.Id == id);

            if (existingStudent == null)
            {
                return NotFound(); // Return a 404 Not Found if the student is not found.
            }

            var StudentDTO = new StudentDTO
            {
                Id = existingStudent.Id,
                StudentName = existingStudent.StudentName,
                Email = existingStudent.Email,
                Phone = existingStudent.Phone
            };

            // any error comes then it goes into ModelState
            PatchDocument.ApplyTo(StudentDTO, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Update the existing student with the data from the model
            existingStudent.StudentName = StudentDTO.StudentName;
            existingStudent.Email = StudentDTO.Email;
            existingStudent.Phone = StudentDTO.Phone;

            // You can save changes to a database or data store here if needed.
            // return Ok(existingStudent); if we update the record we don't want to return anything
            return NoContent(); // 204 is the status
        }





        #region

        // DELETE STUDEBT BT ID

        //[HttpDelete("{id:int}", Name = "DeleteStudentById")]

        //[HttpDelete("{id:min(1):max(100)}", Name = "DeleteStudentById")]
        //public ActionResult<Student> DeleteStudent(int id)
        //{
        //    if (id <= 0)
        //    {
        //        BadRequest(); // 400
        //    }
        //    var student = CollegeRepository.Students.FirstOrDefault(n => n.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound(); // Return a 404 Not Found if the student is not found.
        //    }

        //    CollegeRepository.Students.Remove(student);

        //    // Replace the following line with your actual deletion logic
        //    //CollegeRepository.DeleteStudent(id);

        //    return Ok(true);
        //}

        #endregion


         // DELETE //
        [HttpDelete("{id:min(1):max(100)}", Name = "DeleteStudentById")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest(); // Return a 400 Bad Request response when the ID is invalid.
            }

            var student = CollegeRepository.Students.FirstOrDefault(n => n.Id == id);
            //if (student == null)
            //{
            //    return NotFound(); // Return a 404 Not Found if the student is not found.
            //}

            CollegeRepository.Students.Remove(student);

            // Assuming you have deleted the student successfully
            //CollegeRepository.DeleteStudent(id);

            // Return a 200 OK response to indicate successful deletion
            return Ok(true);
        }

    }
}
