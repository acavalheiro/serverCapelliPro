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
    public class ImageCapilar : BaseEntity
    {
        public string UserId { get; set; } 
        public string PathToImage { get; set; }
        public  DateTime Date { get; set; }
    }
}
