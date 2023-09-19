using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS3750Project.Models
{
    public class User
    {
        /// <summary>
        /// The first name of the user
        /// </summary>
        [Required]
        public string? FirstName { get; set; }
        /// <summary>
        /// The last name of the user
        /// </summary>
        [Required]
        public string? LastName { get; set; }
        /// <summary>
        /// The email of the user
        /// </summary>
        [Required]
        [Key]
        public string? Email { get; set; }
        /// <summary>
        /// The password of the user
        /// </summary>
        [Required]
        public string? Password { get; set; }
        /// <summary>
        /// The birthday of the user
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
