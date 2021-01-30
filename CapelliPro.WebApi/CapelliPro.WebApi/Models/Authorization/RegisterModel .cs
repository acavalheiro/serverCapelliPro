// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterModel .cs" company="">
//   
// </copyright>
// <summary>
//   Defines the RegisterModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.WebApi.Models.Authorization
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The register model.
    /// </summary>
    public class RegisterModel
    {
        [EmailAddress]  
        [Required(ErrorMessage = "Email is required")]  
        public string Email { get; set; }  
  
        [Required(ErrorMessage = "Password is required")]  
        public string Password { get; set; }  
    }
}
