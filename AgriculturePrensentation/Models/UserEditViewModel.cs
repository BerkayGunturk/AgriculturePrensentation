﻿using System.ComponentModel.DataAnnotations;

namespace AgriculturePrensentation.Models
{
    public class UserEditViewModel
    {

        public string Mail { get; set; }

     
        public string Phone { get; set; }

 
        public string Password { get; set; }


        public string ConfirmPassword { get; set; }
        
    }
}
