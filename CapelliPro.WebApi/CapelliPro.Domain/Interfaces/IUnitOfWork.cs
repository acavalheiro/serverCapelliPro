// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IUnitOfWork type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.Domain.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The UnitOfWork interface.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// The save changes async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SaveChangesAsync();

        /// <summary>
        /// The save changes async.
        /// </summary>
        /// <param name="cancellationToken">
        /// The cancellation Token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
