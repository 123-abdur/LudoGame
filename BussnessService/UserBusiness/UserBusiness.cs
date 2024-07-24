using DataService.UserData;
using GeneralModels.Common;
using GeneralModels.General;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussnessService.UserBusiness
{
    public class UserBusiness : UserData
    {
        public UserBusiness() : base()
        { }

        public Response SaveUser(User model)
        {
            Response response = base.SaveUserData(model);
            return response;
        }

        public Response DeleteUser(int Id)
        {
            Response response = base.DeleteUser(Id);
            return response;
        }

        public Response UpdateTotalGamePlayed(UserTotalPlayedGame model)
        {
            Response response = base.UpdateTotalGamePlayed(model);
            return response;
        }

        public Response UpdateTotalWinAmount(UserTotalWinAmount model)
        {
            Response response = base.UpdateTotalWinAmount(model);
            return response;
        }

        public Response UpdateTotalWinningCurrencyAmount(UserTotalWinningCurrecyAmount model)
        {
            Response response = base.UpdateTotalWinningCurrencyAmount(model);
            return response;
        }

        public Response UpdateCurrencyAmount(UserCurrency model)
        {
            Response response = base.UpdateCurrencyAmount(model);
            return response;
        }

        public Response Login(Login model)
        {
            Response response = base.Login(model);
            return response;
        }

    }
}
