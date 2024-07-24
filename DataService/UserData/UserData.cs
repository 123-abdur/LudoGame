using GeneralModels.Common;
using GeneralModels.General;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataService.UserData
{
    public class UserData
    {
        Procedure procedure = new Procedure();

        public UserData()
        {
        }

        public Response Login(Login model)
        {
            Response response = null;

            var parameters = new Dictionary<string, object>();
            parameters.Add("Email", model.Email);
            parameters.Add("Password", model.Password);
            DataSet dataSet = procedure.ExecuteStoredProcedure("User_Login", parameters);

            if (dataSet != null)
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    DataTable dataTable = dataSet.Tables[0];
                    List<LoginResponseModel> users = procedure.PopulateObjectsFromDataTable<LoginResponseModel>(dataTable);
                    var token = procedure.GenerateJwtToken(users[0]);
                    users[0].token = token;
                    response = new Response(true, "Operation Successfully", users[0]);
                }
                else
                {
                    response = new Response(false, "InValid Email/Password", null);
                }
            }
            else
            {
                response = new Response(false, "Api Error", null);
            }

            return response;
        }

        public Response SaveUserData(User model)
        {
            Response response = null;
            string operationMode = "CREATE";
            if (model.Id > 0)
            {
                operationMode = "UPDATE";
            }
            var parameters = new Dictionary<string, object>();
            parameters.Add("OperationMode", operationMode);
            parameters.Add("Id", model.Id);
            parameters.Add("Name", model.Name);
            parameters.Add("Email", model.Email);
            parameters.Add("Password", model.Password);
            parameters.Add("Status", model.Password);
            DataSet dataSet = procedure.ExecuteStoredProcedure("_User_CRUD", parameters);

            if (dataSet != null)
            {
                if (dataSet.Tables[0].Rows[0]["Result"].ToString() == "1")
                {
                    response = new Response(false, "Email Already Exist", null);
                }
                else
                {
                    response = new Response(true, "Operation Successfully", null);
                }
            }
            else
            {
                response = new Response(false, "Api Error", null);
            }

            return response;
        }

        public Response DeleteUser(int Id)
        {
            Response response = null;
            var parameters = new Dictionary<string, object>();
            parameters.Add("OperationMode", "Delete");
            parameters.Add("Id", Id);
            DataSet dataSet = procedure.ExecuteStoredProcedure("_User_CRUD", parameters);

            if (dataSet != null)
            {
                response = new Response(true, "Operation Successfully", null);
            }
            else
            {
                response = new Response(false, "Api Error", null);
            }

            return response;
        }


        public Response UpdateTotalGamePlayed(UserTotalPlayedGame model)
        {
            Response response = null;
            var parameters = new Dictionary<string, object>();
            parameters.Add("Id", model.Id);
            parameters.Add("TotalGamePlayed", model.TotalGamePlayed);
            DataSet dataSet = procedure.ExecuteStoredProcedure("_User_Update_TotalPlayedGame", parameters);

            if (dataSet != null)
            {
                if (dataSet.Tables[0].Rows[0]["Result"].ToString() == "1")
                {
                    response = new Response(true, "Operation Successfully", null);
                }
                else
                {
                    response = new Response(true, "Operation Failed", null);
                }
            }
            else
            {
                response = new Response(false, "Api Error", null);
            }

            return response;
        }

        public Response UpdateTotalWinAmount(UserTotalWinAmount model)
        {
            Response response = null;
            var parameters = new Dictionary<string, object>();
            parameters.Add("Id", model.Id);
            parameters.Add("TotalWinAmount", model.TotalWinAmount);
            DataSet dataSet = procedure.ExecuteStoredProcedure("_User_Update_TotalWinAmount", parameters);

            if (dataSet != null)
            {
                if (dataSet.Tables[0].Rows[0]["Result"].ToString() == "1")
                {
                    response = new Response(true, "Operation Successfully", null);
                }
                else
                {
                    response = new Response(true, "Operation Failed", null);
                }
            }
            else
            {
                response = new Response(false, "Api Error", null);
            }

            return response;
        }


        public Response UpdateTotalWinningCurrencyAmount(UserTotalWinningCurrecyAmount model)
        {
            Response response = null;
            var parameters = new Dictionary<string, object>();
            parameters.Add("Id", model.Id);
            parameters.Add("TotalWinningCurrencyAmount", model.TotalWinningCurrencyAmount);
            DataSet dataSet = procedure.ExecuteStoredProcedure("_User_Update_TotalWinCurrencyAmount", parameters);

            if (dataSet != null)
            {
                if (dataSet.Tables[0].Rows[0]["Result"].ToString() == "1")
                {
                    response = new Response(true, "Operation Successfully", null);
                }
                else
                {
                    response = new Response(true, "Operation Failed", null);
                }
            }
            else
            {
                response = new Response(false, "Api Error", null);
            }

            return response;
        }

        public Response UpdateCurrencyAmount(UserCurrency model)
        {
            Response response = null;
            var parameters = new Dictionary<string, object>();
            parameters.Add("UserId", model.Id);
            parameters.Add("CurrentCurrencyAmount", model.CurrentCurrencyAmount);
            DataSet dataSet = procedure.ExecuteStoredProcedure("_User_Currency", parameters);

            if (dataSet != null)
            {
                if (dataSet.Tables[0].Rows[0]["Result"].ToString() == "1")
                {
                    response = new Response(true, "Operation Successfully", null);
                }
                else
                {
                    response = new Response(true, "Operation Failed", null);
                }
            }
            else
            {
                response = new Response(false, "Api Error", null);
            }

            return response;
        }


    }

}

