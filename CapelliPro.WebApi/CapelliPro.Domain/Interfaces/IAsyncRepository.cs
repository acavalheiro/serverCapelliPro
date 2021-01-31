// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="">
//   
// </copyright>
// <summary>
//   The Repository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace CapelliPro.Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CapelliPro.Domain.Models;

    /// <summary>
    /// The AsyncRepository interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// The get by id async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// The list all async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// The add async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// The update async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// The delete async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task DeleteAsync(T entity);

    }
}
