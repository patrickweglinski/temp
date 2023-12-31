﻿using System.ComponentModel;
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
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of the user
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// The email of the user
        /// </summary>
        [Required]
        [Key]
        public string Email { get; set; }
        /// <summary>
        /// The password of the user
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// The birthday of the user
        /// </summary>
        [Required]
        [MinimumAge(16)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Address One")]
        public string? AddressLineOne { get; set; }

        [Display(Name = "Address Two")]
        public string? AddressLineTwo { get; set; }
        public string? City { get; set; }
        public string? State {  get; set; }

        [Display(Name = "Zip Code")]
        public string? ZipCode { get; set;}

        [Required]
        public bool IsStudent { get; set; }

        [Display(Name = "Website 1")]
        public string? Link1 { get; set; }
        [Display(Name = "Website 2")]
        public string? Link2 { get; set; }
        [Display(Name = "Website 3")]
        public string? Link3 { get; set; }
        public string? ImageFileName { get; set; }
    }
}
