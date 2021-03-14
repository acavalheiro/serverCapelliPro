// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AsyncRepository.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the AsyncRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.Domain.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CapelliPro.Domain.Interfaces;
    using CapelliPro.Domain.Models;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The async repository.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// The _context.
        /// </summary>
        protected readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncRepository{T}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public AsyncRepository(ApplicationContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// The get by id async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// The list all async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await this._context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// The add async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<T> AddAsync(T entity)
        {
            await this._context.Set<T>().AddAsync(entity);
            await this._context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// The update async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task UpdateAsync(T entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }

        /// <summary>
        /// The delete async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task DeleteAsync(T entity)
        {
            this._context.Set<T>().Remove(entity);
            await this._context.SaveChangesAsync();
        }
    }
}
