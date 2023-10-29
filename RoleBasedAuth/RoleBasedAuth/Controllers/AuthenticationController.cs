using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RoleBasedAuth.Authentication;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RoleBasedAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationUser> roleManager;
        private readonly IConfiguration _configuration;

        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;




        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationUser> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
          //  _userManager = userManager;
           //  _roleManager = roleManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
            
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already Exist" });
            
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Creation failed" });
            }

            //if (!await _roleManager.RoleExistsAsync(UserRoles.Admin.ToString()))
            //{
            //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin.ToString()));
            //}

            //if (!await _roleManager.RoleExistsAsync(UserRoles.User.ToString()))
            //{
            //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User.ToString()));
            //}


            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))

                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));


            if (!await roleManager.RoleExistsAsync(UserRoles.User))

                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return Ok(new Response { Status = "Success", Message = "User created Successfully" });

        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Admin already Exist" });
            }
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Admin Creation failed" });
            }
            //            //if (!await _roleManager.RoleExistsAsync(UserRoles.Admin.ToString()))
            //            //{
            //            //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin.ToString()));
            //            //}

            //            //if (!await _roleManager.RoleExistsAsync(UserRoles.User.ToString()))
            //            //{
            //            //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User.ToString()));
            //            //}


            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))

                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));


            if (!await roleManager.RoleExistsAsync(UserRoles.User))

                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            return Ok(new Response { Status = "Success", Message = "Admin created Successfully" });

        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secert"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    User = user.UserName

                });
            }
            return Unauthorized();

        }
    }
}

