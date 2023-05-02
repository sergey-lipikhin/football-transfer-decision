using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLevel
{
    public partial class DataBaseLoad : DataBase
    {
        public List<double> ReadRating(int userId, int playerId)
        {
            List<double> rating = new List<double>() { 0.0, 1.0, 1.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
                0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };

            try
            {
                OpenConnection();
                string query = "SELECT * FROM Rating WHERE UserId=" + userId + " AND PlayerId=" + playerId + ";";

                SqlCommand command = new SqlCommand(query, sqlconnection);
                SqlDataReader result = command.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        try
                        {
                            rating.Clear();
                            #region Initialization features

                            rating.Add(Convert.ToDouble(result["Price"]));

                            rating.Add(Convert.ToDouble(result["International reputation"]));
                            rating.Add(Convert.ToDouble(result["Skill moves"]));
                            rating.Add(Convert.ToDouble(result["Weak foot"]));

                            rating.Add(Convert.ToDouble(result["Potential"]));

                            rating.Add(Convert.ToDouble(result["Crossing"]));
                            rating.Add(Convert.ToDouble(result["Finishing"]));
                            rating.Add(Convert.ToDouble(result["Heading Accuracy"]));
                            rating.Add(Convert.ToDouble(result["Short Passing"]));
                            rating.Add(Convert.ToDouble(result["Volleys"]));
                            
                            rating.Add(Convert.ToDouble(result["Dribbling"]));
                            rating.Add(Convert.ToDouble(result["Curve"]));
                            rating.Add(Convert.ToDouble(result["Free Kick Accuracy"]));
                            rating.Add(Convert.ToDouble(result["Long Passing"]));
                            rating.Add(Convert.ToDouble(result["Ball Control"]));

                            rating.Add(Convert.ToDouble(result["Acceleration"]));
                            rating.Add(Convert.ToDouble(result["Sprint Speed"]));
                            rating.Add(Convert.ToDouble(result["Agility"]));
                            rating.Add(Convert.ToDouble(result["Reactions"]));
                            rating.Add(Convert.ToDouble(result["Balance"]));

                            rating.Add(Convert.ToDouble(result["Shot Power"]));
                            rating.Add(Convert.ToDouble(result["Jumping"]));
                            rating.Add(Convert.ToDouble(result["Stamina"]));
                            rating.Add(Convert.ToDouble(result["Strength"]));
                            rating.Add(Convert.ToDouble(result["Long Shots"]));

                            rating.Add(Convert.ToDouble(result["Aggression"]));
                            rating.Add(Convert.ToDouble(result["Interceptions"]));
                            rating.Add(Convert.ToDouble(result["Positioning"]));
                            rating.Add(Convert.ToDouble(result["Vision"]));
                            rating.Add(Convert.ToDouble(result["Penalties"]));
                            rating.Add(Convert.ToDouble(result["Composure"]));

                            rating.Add(Convert.ToDouble(result["Defending"]));

                            #endregion
                        }
                        catch (IndexOutOfRangeException)
                        {
                            result.Close();
                            return rating;
                        }
                    }
                }

                result.Close();
                return rating;
            }
            catch
            {
                return rating;
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool UpdateInsertRating(int userId, int playerId, List<double> rating)
        {
            try
            {
                OpenConnection();

                string condition = "IF EXISTS (SELECT Rating.Id FROM Rating WHERE Rating.UserId = " + userId + " AND Rating.PlayerId = " + playerId + ")";
                string action1 = "\nBEGIN\n" +
                    "UPDATE Rating\n" +
                    "SET[Price] = " + rating[0] + ", [International reputation]= " + rating[1] + ", [Skill moves]= " + rating[2] + ", [Weak foot]= " + rating[3] + "," +
                    " [Potential]= " + rating[4] + ", [Crossing]= " + rating[5] + ", [Finishing]= " + rating[6] + "," +
                    " [Heading Accuracy]=" + rating[7] + ", [Short Passing]=" + rating[8] + ", [Volleys]= " + rating[9] + ", [Dribbling]= " + rating[10] + ", [Curve]= " + rating[11] + "," +
                    " [Free Kick Accuracy]= " + rating[12] + ", [Long Passing]=" + rating[13] + ", [Ball Control]=" + rating[14] + ", [Acceleration]= " + rating[15] + ", [Sprint Speed]= " + rating[16] + "," +
                    " [Agility]= " + rating[17] + ", [Reactions]= " + rating[18] + ", [Balance]= " + rating[19] + ", [Shot Power]= " + rating[20] + "," +
                    " [Jumping]= " + rating[21] + ", [Stamina]= " + rating[22] + ", [Strength]= " + rating[23] + ", [Long Shots]= " + rating[24] + ", [Aggression]= " + rating[25] + ", " +
                    " [Interceptions]= " + rating[26] + ", [Positioning]= " + rating[27] + ", [Vision]= " + rating[28] + ", [Penalties]= " + rating[29] + "," +
                    " [Composure]= " + rating[30] + ", [Defending]= " + rating[31] + "\n" +
                    "WHERE Rating.UserId = " + userId + " AND Rating.PlayerId = " + playerId + ";\n" +
                    "END\n";

                string action2 = "ELSE\n" +
                    "BEGIN\n" +
                    "INSERT INTO Rating (UserId, PlayerId, [Price], [International reputation], [Skill moves], [Weak foot], [Potential], [Crossing], [Finishing]," +
                    " [Heading Accuracy], [Short Passing], [Volleys], [Dribbling], [Curve], [Free Kick Accuracy], [Long Passing], [Ball Control], [Acceleration]," +
                    " [Sprint Speed], [Agility], [Reactions], [Balance], [Shot Power], [Jumping], [Stamina], [Strength], [Long Shots], [Aggression], [Interceptions]," +
                    " [Positioning], [Vision], [Penalties], [Composure], [Defending])\n" +
                    "VALUES(" + userId + ", " + playerId + ", " + rating[0] + ", " + rating[1] + ", " + rating[2] + ", " + rating[3] + ", " + rating[4] + ", " + rating[5] + "," +
                    " " + rating[6] + ", " + rating[7] + ", " + rating[8] + ", " + rating[9] + ", " + rating[10] + ", " + rating[11] + ", " + rating[12] + ", " + rating[13] + "," +
                    " " + rating[14] + ", " + rating[15] + ", " + rating[16] + ", " + rating[17] + ", " + rating[18] + ", " + rating[19] + ", " + rating[20] + ", " + rating[21] + "," +
                    " " + rating[22] + ", " + rating[23] + ", " + rating[24] + ", " + rating[25] + ", " + rating[26] + ", " + rating[27] + ", " + rating[28] + ", " + rating[29] + "," +
                    " " + rating[30] + ", " + rating[31] + ");\n" +
                    "END";

                string query = condition + action1 + action2;

                SqlCommand command = new SqlCommand(query, sqlconnection);

                if (command.ExecuteNonQuery() != 1) return false;

                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
