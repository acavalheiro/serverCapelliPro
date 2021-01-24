// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationAuthorizationContextFactory.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ApplicationAuthorizationContextFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.Authorization
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class ApplicationAuthorizationContextFactory : IDesignTimeDbContextFactory<ApplicationAuthorizationContext>
    {
        public ApplicationAuthorizationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationAuthorizationContext>();
            optionsBuilder.UseMySql("server=capellipro-db.cml59qbqutca.eu-west-1.rds.amazonaws.com;uid=admin;pwd=ENDe96z8K5qXlFlYM5yM;database=capellipro",new MySqlServerVersion(new Version(8,0,20)));

            return new ApplicationAuthorizationContext(optionsBuilder.Options);
        }
    }
}
