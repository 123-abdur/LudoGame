using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralModels.Common;
using GeneralModels.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BussnessService.UserBusiness;
using System.Web.Http;

using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace HaseebGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        [HttpPost("Login")]
        public Response Login([FromBody] Login model)
        {
            UserBusiness UserBusiness = new UserBusiness();
            return UserBusiness.Login(model);
        }
    }
}