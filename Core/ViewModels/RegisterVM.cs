﻿using System.ComponentModel.DataAnnotations;

namespace Acacia_Back_End.Core.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Roles { get; set; }


        public string ProfilePicture { get; set; }


        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage ="Password must have 1 Uppercase, 1 Lowercase, 1 Number, 1 non-alphanumeric and at least 6 characters")]
        public string Password { get; set; }
    }
}
