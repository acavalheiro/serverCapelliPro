// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Diagnostic.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Diagnostic type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.Domain.Models
{
    using System;

    /// <summary>
    /// The diagnostic.
    /// </summary>
    public class Diagnostic : BaseEntity
    {
        public string UserId { get; set; } 
        public string Disease { get; set; }
        public string Solution { get; set; }
        public  DateTime Date { get; set; }
    }
}
