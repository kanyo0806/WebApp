using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    
    [Table("Detail")]
    public class Details
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        //[Index(nameof(IDNumber), IsUnique = true)]
        public string IDNumber { get; set; }

        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Citizenship { get; set; }
        public int Counter { get; set; }
    }
}