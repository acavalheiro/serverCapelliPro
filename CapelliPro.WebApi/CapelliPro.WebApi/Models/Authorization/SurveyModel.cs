// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SurveyModel .cs" company="">
//   
// </copyright>
// <summary>
//   Defines the SurveyModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.WebApi.Models.Authorization
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The survey model.
    /// </summary>
    public class SurveyModel
    {
        // [Required(ErrorMessage = "UserId is required")]  
        // public string UserId { get; set; }    

        [Required(ErrorMessage = "Age is required")]  
        public string Age { get; set; }  

        [Required(ErrorMessage = "Hair Type is required")]  
        public string HairType { get; set; }  
  
        [Required(ErrorMessage = "Hair Colour is required")]  
        public string HairColour { get; set; }  
  
        [Required(ErrorMessage = "HasColouredHair is required")]  
        public string HasColouredHair { get; set; }  

        [Required(ErrorMessage = "Number of Washes is required")]  
        public string NumberWashes { get; set; }  

        [Required(ErrorMessage = "Living place is required")]  
        public string LivingPlace { get; set; } 

        [Required(ErrorMessage = "UseHeatTools is required")]  
        public string UseHeatTools { get; set; } 

        [Required(ErrorMessage = "UseThermalProducts is required")]  
        public string UseThermalProducts { get; set; }  

        [Required(ErrorMessage = "Desired Hair is required")]  
        public string DesiredHair { get; set; }          
    }
}
