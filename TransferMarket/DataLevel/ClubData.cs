using System;
using System.Collections.Generic;
using System.Text;
using Model;
using ActionResults;
using System.Data.SqlClient;

namespace DataLevel
{
    public partial class DataBaseLoad : DataBase
    {
        public List<string> ReadClubsNames()
        {
            List<string> clubs = new List<string>();

            try
            {
                OpenConnection();

                string query = "SELECT Clubs.Id AS Id, Clubs.Name AS Name FROM Clubs";

                SqlCommand command = new SqlCommand(query, sqlconnection);
                SqlDataReader result = command.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        try
                        {
                            clubs.Add(Convert.ToString(result["Name"]));
                        }
                        catch (IndexOutOfRangeException)
                        {
                            result.Close();
                            return clubs;
                        }
                    }
                }

                result.Close();
                return clubs;
            }
            catch
            {
                return clubs;
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataActionResult InsertClub(string name)
        {
            try
            {
                OpenConnection();

                string query = "INSERT INTO Clubs (Name) output INSERTED.Id VALUES (@name)";
                SqlCommand command = new SqlCommand(query, sqlconnection);

                command.Parameters.AddWithValue("@name", name);

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
