using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CS3750Project.Models
{
    public class Class
    {
        public enum ClassDepartment
        {
            MATH,
            CS,
            ENGR,
            WEB,
            NET,
            // Add more departments as needed
        }
      
        [Key]
        public int Id { get; set; }

        public string? InstructorId { get; set; }
        //public User Instructor { get; set; }
        [Required]
        public ClassDepartment ClassDept { get; set; }
        [Required]
        public String ClassName { get; set; }
        [Required]
        [Range(900, 7000, ErrorMessage = "Class number must be between 900 and 7000")]
        public int ClassNumber {  get; set; }
        [Required]
        [Range(1, 6, ErrorMessage = "Credit hours must be between 1 and 6")]
        public int CreditHours { get; set; }
        [Required]
        public String Location { get; set; }
        [Required]
      
        public Boolean Sunday { get; set; }
        public Boolean Monday { get; set; }
        public Boolean Tuesday { get; set; }
        public Boolean Wednesday { get; set; }
        public Boolean Thursday { get; set; }
        public Boolean Friday { get; set; }
        public Boolean Saturday { get; set; }

        [Required]
        [DisplayName("Start Time:"),
        DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan StartTime { get; set; }
        [Required]
        [DisplayName("End Time:"),
        DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        [StartTimeBeforeEndTime]
        public TimeSpan EndTime { get; set; }


    }
}
