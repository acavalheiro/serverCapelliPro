// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the UnitOfWork type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.Domain.Data.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;

    using CapelliPro.Domain.Interfaces;

    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The _application context.
        /// </summary>
        private readonly ApplicationContext _applicationContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="applicationContext">
        /// The application context.
        /// </param>
        public UnitOfWork(ApplicationContext applicationContext)
        {
            this._applicationContext = applicationContext;
        }

        /// <summary>
        /// The save changes async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task SaveChangesAsync()
        {
            await this._applicationContext.SaveChangesAsync();
        }

        /// <summary>
        /// The save changes async.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task SaveChangesAsync(CancellationToken token)
        {
            await this._applicationContext.SaveChangesAsync(token);
        }
    }
}
