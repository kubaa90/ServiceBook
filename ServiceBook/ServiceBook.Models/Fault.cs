using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServiceBook.Models
{
    public class Fault
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Opis usterki")]
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Display(Name = "Numer Pojazdu")]
        [Required]
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
        public DateTime? AddDate { get; set; }=DateTime.Now;
    }
}
