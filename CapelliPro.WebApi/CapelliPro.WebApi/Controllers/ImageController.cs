// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageCapilarController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ImageCapilarController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CapelliPro.WebApi.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.IO;
    using System.Windows;

    using CapelliPro.WebApi.Models.Authorization;

    using Microsoft.AspNetCore.Mvc;
   
    using Microsoft.Extensions.Logging;
    using CapelliPro.Domain.Interfaces;
    using CapelliPro.Domain.Models;

    /// <summary>
    /// The ImageCapilar controller.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class ImageCapilarController : ControllerBase
    {
        private readonly ILogger<ImageCapilarController> _logger;
        private readonly IAsyncRepository<ImageCapilar> _ImageCapilarAsyncRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ImageCapilarController(ILogger<ImageCapilarController> logger, IAsyncRepository<ImageCapilar> ImageCapilarAsyncRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this._ImageCapilarAsyncRepository = ImageCapilarAsyncRepository;
            this._unitOfWork = unitOfWork;
        }


        [HttpPost]
        [Route("imageCapilar")]
        public async Task<IActionResult> saveImageCapilars([FromBody] ImageModel model)
        {

            var currentUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(currentUser))
                return this.BadRequest("User not found");

            var dataToInsertOnDatabase = new ImageCapilar
            {
                UserId = currentUser,
                PathToImage = model.base64Image
                //falta data
            };

            await this._ImageCapilarAsyncRepository.AddAsync(dataToInsertOnDatabase);

            await this._unitOfWork.SaveChangesAsync();

            return this.Ok();
        }


        /* public Image LoadImage(string imageBase64)
        {
            //data:image/gif;base64,
            //this image is a single pixel (black)
            byte[] bytes = Convert.FromBase64String(imageBase64);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }
 */

    }

}
