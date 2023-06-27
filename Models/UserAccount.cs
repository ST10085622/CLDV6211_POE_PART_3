using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RentYouRide.Models
{
    public class UserAccount
    {
        [Key]
        public int ID_User { get; set; }

        [Required(ErrorMessage ="Username is Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

     

    }
}