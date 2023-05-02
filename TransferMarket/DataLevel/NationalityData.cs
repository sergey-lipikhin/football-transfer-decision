using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ActionResults;
using Model;

namespace DataLevel
{
    public partial class DataBaseLoad : DataBase
    {
        public DataBaseLoad() : base() { }

        public Dictionary<string, string> ReadNationalities()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            try
            {
                OpenConnection();

                string query = "SELECT * FROM Nationalities;";

                SqlCommand command = new SqlCommand(query, sqlconnection);
                SqlDataReader result = command.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        try
                        {
                            data.Add(Convert.ToString(result["Name"]), Convert.ToString(result["Image"]));
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            result.Close();
                            return data;
                        }
                    }
                }

                result.Close();
                return data;
            }
            catch
            {
                return data;
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataActionResult InsertNation(string name, string image)
        {
            try
            {
                OpenConnection();

                string query = "INSERT INTO Nationalities (Name, Image) output INSERTED.Id VALUES (@name,@image)";
                SqlCommand command = new SqlCommand(query, sqlconnection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@image", image);

                command.ExecuteScalar();

                return DataActionResult.CORRECT;
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                return DataActionResult.UNUNIQUE;
            }
            catch
            {
                return DataActionResult.GENERAL_ERROR;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
