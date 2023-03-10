using System;
using System.ComponentModel.DataAnnotations;

namespace PhanTriVi_2011063105_buoi5.Models
{
    public class Course
    {
        public int Id { get; set; }
        public ApplicationUser Lectuer { get; set; }
        [Required]
        public string LectuerId { get; set; }
        [Required]
        [StringLength(255)]
        public string Place { get; set; }
        public DateTime DateTime { get; set; }
        public Category Category { get; set; }
        [Required]
        public byte CategoryID {get; set; }
    }
    
}