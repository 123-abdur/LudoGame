using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussnessService.UserBusiness;
using GeneralModels.Common;
using GeneralModels.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HaseebGame.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }


        [HttpPost("SaveUser")]
        public Response SaveUser([FromBody] User model)
        {
            UserBusiness UserBusiness = new UserBusiness();
            return UserBusiness.SaveUser(model);
        }

        [HttpDelete("DeleteUser")]
        public Response DeleteUser([FromQuery] int Id)
        {
            UserBusiness UserBusiness = new UserBusiness();
            return UserBusiness.DeleteUser(Id);
        }


        [HttpPost("UpdateTotalGamePlayed")]
        public Response UpdateTotalGamePlayed([FromBody] UserTotalPlayedGame model)
        {
            UserBusiness UserBusiness = new UserBusiness();
            return UserBusiness.UpdateTotalGamePlayed(model);
        }

        [HttpPost("UpdateTotalWinAmount")]
        public Response UpdateTotalWinAmount([FromBody] UserTotalWinAmount model)
        {
            UserBusiness UserBusiness = new UserBusiness();
            return UserBusiness.UpdateTotalWinAmount(model);
        }

        [HttpPost("UpdateTotalWinningCurrencyAmount")]
        public Response UpdateTotalWinningCurrencyAmount([FromBody] UserTotalWinningCurrecyAmount model)
        {
            UserBusiness UserBusiness = new UserBusiness();
            return UserBusiness.UpdateTotalWinningCurrencyAmount(model);
        }

        [Authorize]
        [HttpPost("UpdateCurrencyAmount")]
        public Response UpdateCurrencyAmount([FromBody] UserCurrency model)
        {
            UserBusiness UserBusiness = new UserBusiness();
            return UserBusiness.UpdateCurrencyAmount(model);
        }
    }
}