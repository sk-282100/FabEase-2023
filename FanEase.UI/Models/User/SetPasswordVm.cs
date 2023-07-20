﻿using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.User
{
    public class SetPasswordVm
    {
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Password not matched")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
