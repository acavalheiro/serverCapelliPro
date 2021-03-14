// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageModel .cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ImageModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.WebApi.Models.Authorization
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The image model.
    /// </summary>
    public class ImageModel
    {
         [Required(ErrorMessage = "UserId is required")] 
        public string UserId { get; set; } 

        [Required(ErrorMessage = "Base64 Image is required")]  
        public string base64Image { get; set; } 

        //[Required(ErrorMessage = "Date Image is required")]
       // public  DateTime Date { get; set; }
    }
}
