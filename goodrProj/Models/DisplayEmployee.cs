using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace goodrProj.Models
{
    public class DisplayEmployee
    {
    
        [Required]
        [StringLength(25, ErrorMessage ="First name is too long")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Last name is too long")]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Department { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [Phone]
        [StringLength(14, ErrorMessage ="enter number in X-XXX-XXX-XXXX format")]
        [MinLength(14, ErrorMessage = "enter number in X-XXX-XXX-XXXX format")]
        public string Number { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}

