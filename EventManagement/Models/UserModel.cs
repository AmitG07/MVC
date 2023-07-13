using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EventManagement.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string password { get; set; }
    }
}