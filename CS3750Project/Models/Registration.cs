using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

namespace CS3750Project.Models
{
 
    public class Registration
    {

        public Registration() { }

        public Registration(string email) 
        {
            this.ClassId = new List<ClassIdentify>();
            this.IsRegistered = new List<Register>();
            StudentId = email;
        }

        [Key]
        public string StudentId { get; set; }

        [Required]
        public List<ClassIdentify> ClassId { get; set; }

        [Required]
        public List<Register> IsRegistered { get; set; }

    }

    
    public class ClassIdentify
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }

        public int ClassId { get; set; }


        public ClassIdentify()
        {

        }
        public ClassIdentify(int id, string email)
        {
            ClassId = id;
            StudentId = email;
        }
    }

    public class Register
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }

        public bool IsRegistered { get; set; }


        public Register()
        {

        }

        public Register(bool isRegistered, string email)
        {
            IsRegistered = isRegistered;
            StudentId= email;
        }
    }

}
