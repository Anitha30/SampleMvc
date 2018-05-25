using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleMvcFriend.Models
{
    public class FriendModel
    {
        [Required]
        [Display(Name = "Friend ID")]
        public int FriendID { get; set; }

        [Display(Name = "Friend Name")]
        [Required(ErrorMessage = "Friend Name Empty Not Allowed")]
        public string FriendName { get; set; }

        [Display(Name = "Place")]
        [StringLength(25, ErrorMessage = "Place should not exceed 25 characters")]
        public string Place { get; set; }

    }
}