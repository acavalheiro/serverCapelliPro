// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationContext.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ApplicationContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
//ligaçao à bd



namespace CapelliPro.Domain.Data
{
    using CapelliPro.Authorization;
    using CapelliPro.Domain.Models;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The application context.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        public DbSet<Example> Examples { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Diagnostic> Diagnostics { get; set; }
        public DbSet<ImageCapilar> ImagesCapilares { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
    }
}
