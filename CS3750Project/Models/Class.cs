using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CS3750Project.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String ClassDept { get; set; }
        [Required]
        public String ClassName { get; set; }
        [Required]
        public int CreditHours { get; set; }
        [Required]
        public String Location { get; set; }
        [Required]
        public String DaysOfWeek { get; set; }
        [Required]
        public String TimeOfDay {  get; set; }
        
     
        
    }
}
