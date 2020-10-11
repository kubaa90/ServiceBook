using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceBook.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nazwa Producenta/Dealera")]
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        [Display(Name = "Adres")]
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
