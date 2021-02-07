// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SurveyController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the SurveyController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using CapelliPro.Authorization.Models;
    using CapelliPro.WebApi.Models.Authorization;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;


    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The survey controller.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ILogger<SurveyController> _logger;
        public SurveyController(ILogger<SurveyController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("survey")]
        public async Task<IActionResult> SurveyResponseQuestions([FromBody] SurveyModel model)
        {
            SurveyResponse surveyResponse = new SurveyResponse()
            {
                Age = model.Age,
                HairType = model.HairType,
                HairColour = model.HairColour,
                HasColouredHair = model.HasColouredHair,
                NumberWashes = model.NumberWashes,
                LivingPlace = model.LivingPlace,
                UseHeatTools = model.UseHeatTools,
                UseThermalProducts = model.UseThermalProducts,
                DesiredHair = model.DesiredHair
            };

            Console.WriteLine(model.ToString());

            return this.Ok();
        }
    }
}
