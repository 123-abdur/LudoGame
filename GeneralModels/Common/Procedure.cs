

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using GeneralModels.General;
using System.Security.Cryptography;

namespace GeneralModels.Common
{
    public class Procedure
    {
        public DataSet ExecuteStoredProcedure(string storedProcedureName, Dictionary<string, object> parameters)
        {
            DataSet dataSet = new DataSet();

            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=HaseebGame;Integrated Security=True;"))
            {
                using (var command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (var parameter in parameters)
                    {
                        command.Parameters.AddWithValue("@" + parameter.Key, parameter.Value ?? DBNull.Value);
                    }

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Create a new DataTable
                        DataTable dataTable = new DataTable();

                        // Load the result into the DataTable
                        dataTable.Load(reader);

                        // Add the DataTable to the DataSet
                        dataSet.Tables.Add(dataTable);
                    }
                }
            }

            return dataSet;
        }

        public List<T> PopulateObjectsFromDataTable<T>(DataTable dataTable) where T : new()
        {
            List<T> objects = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                T obj = new T();

                // Get all the properties of the object
                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    // Get the column name from the property name
                    string columnName = property.Name;

                    // Check if the column exists in the DataRow
                    if (dataTable.Columns.Contains(columnName))
                    {
                        // Get the value from the DataRow and set it to the property
                        object value = row[columnName];
                        if (value != DBNull.Value)
                        {
                            property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
                        }
                    }
                }

                objects.Add(obj);
            }

            return objects;
        }

        public string GenerateJwtToken(LoginResponseModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("12254888777788544555"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("MyGame",
                                             "MyAudience",
                                             new Claim[] {
                                         new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                                         new Claim(ClaimTypes.Name, user.Name),
                                         new Claim(ClaimTypes.Email, user.Email)
                                             },
                                             expires: DateTime.UtcNow.AddHours(5),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}

