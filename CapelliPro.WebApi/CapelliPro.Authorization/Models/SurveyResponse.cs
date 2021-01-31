// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SurveyResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The survey response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.Authorization.Models
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// The survey response.
    /// </summary>
    public class SurveyResponse : IdentityUser
    {
        public string Age { get; set; }  

        public string HairType { get; set; }  

        public string HairColour { get; set; }  

        public bool HasColouredHair { get; set; }  

        public string NumberWashes { get; set; } 

        public string LivingPlace { get; set; } 

        public string UseHeatTools { get; set; } 

        public bool UseThermalProducts { get; set; }  

        public string DesiredHair { get; set; } 
    }
}
