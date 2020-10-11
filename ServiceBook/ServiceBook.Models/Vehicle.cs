using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceBook.Models
{
    public class Vehicle
    {
        [Key] 
        public int Id { get; set; }
        [Display(Name = "Numer Pojazdu")]
        [Required]
        [MaxLength(30)]
        public string Number { get; set; }
        [Display(Name = "Numer VIN")]
        [Required]
        [MaxLength(50)]
        public string VIN { get; set; }
        [Required]
        [MaxLength(10)]
        public string PlateNumber { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}
