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
    using CapelliPro.Domain.Interfaces;
    using CapelliPro.Domain.Models;

    using Microsoft.AspNetCore.Authorization; 

    using Microsoft.Extensions.Identity.Core;

    /// <summary>
    /// The survey controller.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ILogger<SurveyController> _logger;
        private readonly IAsyncRepository<Survey> _surveyAsyncRepository;

        private readonly IUnitOfWork _unitOfWork;

        public SurveyController(ILogger<SurveyController> logger,  IAsyncRepository<Survey> surveyAsyncRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this._surveyAsyncRepository = surveyAsyncRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("survey")]
        public async Task<IActionResult> SurveyResponseQuestions([FromBody] SurveyModel model)
        {

            var currentUser = this.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier);

            var dataToInsertOnDatabase = new Survey {UserId="563",
                Age = model.Age,
                HairType = model.HairType,
                HairColour = model.HairColour,
                HasColouredHair = model.HasColouredHair,
                NumberWashes = model.NumberWashes,
                LivingPlace = model.LivingPlace,
                UseHeatTools = model.UseHeatTools,
                UseThermalProducts = model.UseThermalProducts,
                DesiredHair = model.DesiredHair };

            await this._surveyAsyncRepository.AddAsync(dataToInsertOnDatabase);

            await this._unitOfWork.SaveChangesAsync();

            return this.Ok();
        }
    }
}
