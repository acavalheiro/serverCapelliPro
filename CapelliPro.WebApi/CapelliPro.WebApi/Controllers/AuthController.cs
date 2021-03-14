// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the AuthController type.
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

    

    /// <summary>
    /// The auth controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// The user manager.
        /// </summary>
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// The _configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="userManager">
        /// The user manager.
        /// </param>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this._configuration = configuration;
        }

        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);
            if (user != null && await this.userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await this.userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                                     {
                                         new Claim(ClaimTypes.Name, user.UserName),
                                         new Claim(ClaimTypes.NameIdentifier, user.Id),
                                         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                     };
                authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

                var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this._configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: this._configuration["JWT:ValidIssuer"],
                    audience: this._configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(10),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                return this.Ok(new
                                   {
                                       token = new JwtSecurityTokenHandler().WriteToken(token),
                                       expiration = token.ValidTo
                                   });
            }
            return this.Unauthorized();
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]  
        [Route("register")]  
        public async Task<IActionResult> Register([FromBody] RegisterModel model)  
        {  
            var userExists = await this.userManager.FindByNameAsync(model.Email);  
            if (userExists != null)  
                return this.StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });  
  
            ApplicationUser user = new ApplicationUser()  
                                       {  
                                           Name = model.Name,
                                           Email = model.Email,  
                                           SecurityStamp = Guid.NewGuid().ToString(),  
                                           UserName = model.Email  
                                       };  
            var result = await this.userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return this.StatusCode(StatusCodes.Status500InternalServerError, new { Error = result.Errors.ToString() });

            return this.Ok();  
        }


        [HttpGet]
        [Route("GetUserName")]
        public async Task<ActionResult<UserInfo>> GetUserName()
        {
            var currentUser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await this.userManager.GetUserAsync(this.User); 
           
            return new UserInfo { Name = user.Name, Email = user.Email};
        }
    }
}
