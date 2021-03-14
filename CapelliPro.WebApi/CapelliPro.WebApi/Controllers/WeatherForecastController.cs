// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherForecastController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the WeatherForecastController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CapelliPro.Domain.Interfaces;
    using CapelliPro.Domain.Models;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Microsoft.Extensions.Identity.Core;


    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        /// <summary>
        /// The example async repository.
        /// </summary>
        private readonly IAsyncRepository<Example> _exampleAsyncRepository;

        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IAsyncRepository<Example> exampleAsyncRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this._exampleAsyncRepository = exampleAsyncRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {

            
            //Aqui vai buscar o ID do User logado
            var currentUser = this.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier);


            //Inserir dados na bd
            var dataToInserOnDatabae = new Example { Data1 = "teste", Data2 = currentUser.Value };

            await this._exampleAsyncRepository.AddAsync(dataToInserOnDatabae);


            //fazer commit dados na bd
            await this._unitOfWork.SaveChangesAsync();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
