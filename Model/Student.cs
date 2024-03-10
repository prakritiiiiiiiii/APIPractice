using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Model
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
