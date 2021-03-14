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
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CapelliPro.WebApi.Models.Authorization;

    using Microsoft.AspNetCore.Mvc;
  
    using Microsoft.Extensions.Logging;
    using CapelliPro.Domain.Interfaces;
    using CapelliPro.Domain.Models;

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


        [HttpGet]
        [Route("HasValidSurvey")]
        public async Task<IActionResult> HasValidSurvey()
        {
            var currentUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var allSurveys = await this._surveyAsyncRepository.ListAllAsync();
            var exists = allSurveys.Any(s => s.UserId == currentUser);

            if (exists)
                return this.Ok();

            return NotFound();
        }

        [HttpPost]
        [Route("survey")]
        public async Task<IActionResult> SurveyResponseQuestions([FromBody] SurveyModel model)
        {

            var currentUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(currentUser))
                return this.BadRequest("User not found");

            var dataToInsertOnDatabase = new Survey {
                UserId = currentUser,
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
