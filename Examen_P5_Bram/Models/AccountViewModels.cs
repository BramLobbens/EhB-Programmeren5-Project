using Examen_P5_Bram.Translations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examen_P5_Bram.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "AccountEmail", ResourceType = typeof(Texts))]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        //[Required]
        //[Display(Name = "Email")]
        //[EmailAddress]
        //public string Email { get; set; }
        
        // Replace above with
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        // Added
        [Required]
        [Display(Name = "AccountUserName", ResourceType = typeof(Texts))]
        [StringLength(15, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "AccountEmail", ResourceType = typeof(Texts))]
        public string Email { get; set; }

        //Added
        [Required]
        [StringLength(50, ErrorMessageResourceName = "AccountUserNameError", ErrorMessageResourceType = typeof(Texts), MinimumLength = 4)]
        [Display(Name = "A_FirstName", ResourceType = typeof(Texts))]
        public string FirstName { get; set; }

        //Added
        [Required]
        [StringLength(50, ErrorMessageResourceName = "AccountUserNameError", ErrorMessageResourceType = typeof(Texts), MinimumLength = 4)]
        [Display(Name = "A_LastName", ResourceType = typeof(Texts))]
        public string LastName { get; set; }

        //Added
        [Required]
        [Display(Name = "A_PhoneNumber", ResourceType = typeof(Texts))]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "AccountPasswordError", ErrorMessageResourceType = typeof(Texts), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "A_AccountPassword", ResourceType = typeof(Texts))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "AccountPasswordConfirmation", ResourceType = typeof(Texts))]
        [Compare("Password", ErrorMessageResourceName = "AccountPasswordConfirmationError", ErrorMessageResourceType = typeof(Texts))]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "AccountUserName", ResourceType = typeof(Texts))]
        public string Email { get; set; }
    }
}
