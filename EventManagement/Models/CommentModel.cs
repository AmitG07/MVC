using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EventManagement.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string CommentAdded { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

    }
}