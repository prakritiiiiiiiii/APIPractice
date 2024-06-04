using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Data.Repositories.Interface;
using StudentWebApi.Model;
using System.Security.Policy;

namespace StudentWebApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository; 

        public StudentController(IStudentRepository  studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/student/get-all-student
        [HttpGet("get-all-student")]

        public List<Student> GetAllStudents()
        {
            var students = _studentRepository.List();
            return students;
        }

        // POST: api/student/add-student
        [HttpPost("add-student")]
        public OperationResponse AddStudents(Student student)
        {
            try
            {
                var row = _studentRepository.Insert(student);
                if (row == 0)
                {
                    return new OperationResponse { Status = false, Message = "Unable to insert student", RowsAffected = row };
                }
                else
                {
                    return new OperationResponse { Status = true, Message = "Student is inserted successfully.", RowsAffected = row };
                }
            }
            catch(Exception ex) 
            {
                return new OperationResponse { Status = false, Message = ex.Message, RowsAffected = 0 };
            }
        }

        [HttpPost("update-student")]

        public OperationResponse UpdateStudents(Student student)
        {
            try
            {
                var row = _studentRepository.Update(student);
                if (row == 0)
                {
                    return new OperationResponse { Status = false, Message = "Unable to update student", RowsAffected = row };

                }
                else
                {
                    return new OperationResponse { Status = true, Message = "Student is updated successfully.", RowsAffected = row };
                }
                
            }
            catch(Exception ex)
            { 
                return new OperationResponse { Status= false, Message = ex.Message,RowsAffected = 0};   
            }
        }

        // GET: api/student/get-student-by-id/{id}
        [HttpGet("get-student-by-id/{id}")]
        public Student GetStudentsById(Guid id)
        {
            var student = _studentRepository.Find(id);
            return student;
        }


        // GET: api/student/delete-student-by-id/{id}
        [HttpGet("delete-student-by-id/{id}")]
        public OperationResponse DeleteStudentsById(Guid id)
        {
            var student = _studentRepository.Find(id);
            if(student == null)
            {
                return new OperationResponse { Status = false, Message = $"{id} not found.", RowsAffected = 0 };
            }
            else
            {
                var row = _studentRepository.Delete(student);
                if (row == 0)
                {
                    return new OperationResponse { Status = false, Message = "Unable to delete student", RowsAffected = row };

                }
                else
                {
                    return new OperationResponse { Status = true, Message = "Student is deleted succesfully.", RowsAffected = row };
                }
            }
        }


        [HttpGet("get-student-by-name/{name}")]
        public List<Student> GetStudentsByName(string name)
        {
            var students = _studentRepository.GetQueryable().Where(x => x.Name.Contains(name)).ToList();
            return students;
        }



        [HttpGet("get-student-by-email/{email}")]
        public List<Student> GetStudentsByEmail(string email)
        {
            var  students = _studentRepository.GetQueryable().Where(x => x.Name.Contains(email)).ToList();
            return students;
        }
         

        
       

    }
}
