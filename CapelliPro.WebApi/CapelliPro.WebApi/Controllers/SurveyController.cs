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

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;



    /// <summary>
    /// The survey controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// The user manager.
        /// </summary>
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// The _configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="SurveyController"/> class.
        /// </summary>
        /// <param name="userManager">
        /// The user manager.
        /// </param>
        /// <param name="configuration">
        /// The configuration.
        /// </param>

        public SurveyController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// The survey.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route("survey")]
        public async Task<IActionResult> Survey([FromBody] SurveyModel model)
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
        }

        return this.Ok();
    }
}

