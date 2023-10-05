using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS3750Project.Models
{
    [PrimaryKey(nameof(InstructorId), nameof(StudentId))]
public class ClassRegistration
    {

        [Key, Column(Order = 0)]
        public string InstructorId { get; set; }

        [Key, Column(Order = 1)]
        public string StudentId { get; set; } 
    }
}
