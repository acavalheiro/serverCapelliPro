// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationContextFactory.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ApplicationContextFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.Domain.Data
{
    using System;

    using CapelliPro.Authorization;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// The application context factory.
    /// </summary>
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
     {
         public ApplicationContext CreateDbContext(string[] args)
         {
             var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
             optionsBuilder.UseMySql("server=capellipro-db.cml59qbqutca.eu-west-1.rds.amazonaws.com;uid=admin;pwd=ENDe96z2bgsdfABC8K5qXlFlYM5yM;database=capellipro",new MySqlServerVersion(new Version(8,0,20)));

             return new ApplicationContext(optionsBuilder.Options);
         }
     }
    
    
}
