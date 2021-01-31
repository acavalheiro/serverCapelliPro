// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseEntity.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the BaseEntity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace CapelliPro.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The base entity.
    /// </summary>
    public class BaseEntity 
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public virtual int Id { get; protected set; }
    }
}
