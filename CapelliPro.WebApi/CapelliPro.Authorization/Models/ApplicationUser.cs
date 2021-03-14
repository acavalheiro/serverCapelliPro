// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationUser.cs" company="">
//   
// </copyright>
// <summary>
//   The application user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.Authorization.Models
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// The application user.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string Name {get; set;}
    }
}
