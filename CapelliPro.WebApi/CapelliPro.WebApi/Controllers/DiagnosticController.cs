// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagnosticController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the DiagnosticController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.WebApi.Controllers
{
    using CapelliPro.Domain.Interfaces;
    using CapelliPro.Domain.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    /// <summary>
    /// The diagnostic controller.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticController : ControllerBase
    {
        private readonly ILogger<SurveyController> _logger;
        private readonly IAsyncRepository<Diagnostic> _diagnosticAsyncRepository;

        private readonly IUnitOfWork _unitOfWork;

        public DiagnosticController(ILogger<SurveyController> logger,  IAsyncRepository<Diagnostic> diagnosticAsyncRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this._diagnosticAsyncRepository = diagnosticAsyncRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetDiagnostic")]
        public async Task<ActionResult<DiagnosticInfo>> GetDiagnostic()
        {
             var currentUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(currentUser))
                return this.BadRequest("User not found"); 

            var allDiagnostics = await this._diagnosticAsyncRepository.ListAllAsync();

            var diagnosticLine = allDiagnostics.FirstOrDefault(s => s.UserId == currentUser);
            
            return new DiagnosticInfo { Disease = diagnosticLine.Disease, Solution = diagnosticLine.Solution, Date = diagnosticLine.Date };
        }
    }
}
