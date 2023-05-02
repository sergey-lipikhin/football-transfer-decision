using System;
using System.Collections.Generic;
using Model;
using System.Data.SqlClient;
using ActionResults;
using System.Linq;

namespace DataLevel
{
    public partial class DataBaseLoad : DataBase
    {
        public List<(int, string, int, string, string, string, string, double)> ReadPlayers()
        {
            List<(int, string, int, string, string, string, string, double)> players = new List<(int, string, int, string, string, string, string, double)>();

            try
            {
                OpenConnection();
                string query = "SELECT Players.Id AS Id, Players.Name AS Name, Players.Age AS Age, Nationalities.Name AS Nationality, Clubs.Name AS Club, Positions.Name AS Position, PlayerStatus.Status AS Status, Players.Price AS Price " +
                    "FROM PlayerStatus INNER JOIN(Positions INNER JOIN (Clubs INNER JOIN (Players LEFT JOIN Nationalities ON Players.Nationality = Nationalities.Id) ON Clubs.Id = Players.Club) " +
                    "ON Positions.Id = Players.Position) ON PlayerStatus.Id = Players.Status";

                SqlCommand command = new SqlCommand(query, sqlconnection);
                SqlDataReader result = command.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        try
                        {
                            players.Add((
                                Convert.ToInt32(result["Id"]),
                                Convert.ToString(result["Name"]),
                                Convert.ToInt32(result["Age"]),
                                Convert.ToString(result["Nationality"]),
                                Convert.ToString(result["Club"]),
                                Convert.ToString(result["Position"]),
                                Convert.ToString(result["Status"]),
                                Convert.ToDouble(result["Price"])
                                ));
                        }
                        catch (IndexOutOfRangeException)
                        {
                            result.Close();
                            return players;
                        }
                    }
                }

                result.Close();
                return players.OrderByDescending(player => player.Item8).Take(100).ToList();
            }
            catch
            {
                return players;
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool UpdatePlayer(int id, string name, int age, string nationality, string club, string position, string status)
        {
            int? nationalityId = GetId("Nationalities", "Name", nationality);
            if (nationalityId == null) return false;

            int? clubId = GetId("Clubs", "Name", club);
            if (clubId == null) return false;

            int? positionId = GetId("Positions", "Name", position);
            if (positionId == null) return false;

            int? statusId = GetId("PlayerStatus", "Status", status);
            if (statusId == null) return false;

            try
            {
                OpenConnection();

                string query = "UPDATE Players SET Name='" + name + "', Age='" + age + "', Nationality='"
                    + nationalityId + "', Club='" + clubId + "', Position='" + positionId + "', Status='" + statusId + "' WHERE Id LIKE '" + id + "' ;";

                SqlCommand command = new SqlCommand(query, sqlconnection);

                if (command.ExecuteNonQuery() != 1) return false;

                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataActionResult InsertPlayer(string name, string club, string position, double price = 0.0)
        {
            int? clubId = GetId("Clubs", "Name", club);
            if (clubId == null) return DataActionResult.NO_CLUB;

            int? positionId = GetId("Positions", "Name", position);
            if (positionId == null) return DataActionResult.NO_POSITION;

            try
            {
                OpenConnection();

                string query = "INSERT INTO Players (Name, Club, Position, Price) output INSERTED.Id VALUES (@name,@club,@position,@price)";
                SqlCommand command = new SqlCommand(query, sqlconnection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@club", clubId);
                command.Parameters.AddWithValue("@position", positionId);
                command.Parameters.AddWithValue("@price", price);

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

        public int? GetId(string tableName, string columnName, string conditionName)
        {
            try
            {
                int? id = null;
                OpenConnection();

                if (conditionName.Contains('\'')) conditionName = conditionName.Insert(conditionName.IndexOf('\''), "\'");

                string query = "SELECT Id FROM " + tableName + " WHERE " + columnName + " LIKE '" + conditionName + "'";

                SqlCommand command = new SqlCommand(query, sqlconnection);
                SqlDataReader result = command.ExecuteReader();

                if (result.HasRows)
                {
                    if (result.Read())
                    {
                        try
                        {
                            id = Convert.ToInt32(result["Id"]);
                        }
                        catch
                        {
                            result.Close();
                        }
                    }
                }
                result.Close();

                return id;
            }
            catch
            {
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
