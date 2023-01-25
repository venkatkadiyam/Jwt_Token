using Google.Apis.Admin.Directory.directory_v1.Data;
using ICSharpCode.Decompiler.CSharp.Syntax;
using JwtToken.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerBI.Api;
using System.Security.Claims;

namespace JwtToken.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
         [HttpGet]
         [Route("Admins")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult AdminEndPoint()
        {
            return Ok($"user Name {GetPresentUser().UserName}: Roll is {GetPresentUser().Role}");
        }
        private CredentialTable GetPresentUser()
        {
            return new CredentialTable
               {
                   UserName = (HttpContext.User.Identity as ClaimsIdentity)?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                   Role = (HttpContext.User.Identity as ClaimsIdentity)?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
               };


            
        }
    }
}
