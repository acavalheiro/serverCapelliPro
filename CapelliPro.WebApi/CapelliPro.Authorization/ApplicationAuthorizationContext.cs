// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationAuthorizationContext.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ApplicationAuthorizationContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.Authorization
{
    using CapelliPro.Authorization.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The application authorization context.
    /// </summary>
    public class ApplicationAuthorizationContext : IdentityDbContext<ApplicationUser>  
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationAuthorizationContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        public ApplicationAuthorizationContext(DbContextOptions<ApplicationAuthorizationContext> options) : base(options)  
        {  
        } 
    }
}
