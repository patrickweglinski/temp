using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CS3750Project.Models
{
    public class Assignment
    {
        public enum SubmissionType
        {
            Paper,
            PDF,
            JPG
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Class Relationship
        public int ClassId { get; set; }
        public Class? Class { get; set; }

        public string? Name { get; set; }

        public int? Points { get; set; }

        [Required]
        public SubmissionType? Submission { get; set; }
        [Required]
        public DateTime? Day { get; set; }

        public DateTime? Time { get; set; }


    }
}



