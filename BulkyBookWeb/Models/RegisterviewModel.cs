using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class RegisterViewModel
    
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }



            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        [Required]  
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="password and confirmation password do not match")]
          public String ConfirmPassword { get; set; }




    }
 }
