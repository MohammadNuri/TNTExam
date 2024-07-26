using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNTExam.Domain.Entities.Exams;

namespace TNTExam.Domain.Entities.Users
{
    //دانش آموزان
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty; 
        public int? Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;


        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>(); //آزمون ها   

        //Many to one
        public virtual ICollection<UserInRole> UserInRoles { get; set; }
    }
}
