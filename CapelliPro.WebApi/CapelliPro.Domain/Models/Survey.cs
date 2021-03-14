// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Survey.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Survey type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


//igual ao modelo para a bd
//respostas mais user id

namespace CapelliPro.Domain.Models
{
    /// <summary>
    /// The survey.
    /// </summary>
    public class Survey : BaseEntity
    {
        public string UserId { get; set; } 
        public string Age { get; set; }
        public string HairType { get; set; }
        public string HairColour { get; set; }
        public string HasColouredHair { get; set; }
        public string NumberWashes { get; set; }

        public string LivingPlace { get; set; }
        public string UseHeatTools { get; set; }
        public string UseThermalProducts { get; set; }
        public string DesiredHair { get; set; }
    }
}
