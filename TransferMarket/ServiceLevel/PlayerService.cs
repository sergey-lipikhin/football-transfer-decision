using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using DataLevel;
using Model;

namespace ServiceLevel
{
    public class PlayerService : IPlayerService
    {
        static DateTime _start = DateTime.Now;
        static string Now => (_start - DateTime.Now).ToString();

        static DataBaseLoad dataBase = new DataBaseLoad();
        static NeuralNetwork NeuralNetwork = new NeuralNetwork();
        public List<string> ReadClubsNames()
        {
            var ans = dataBase.ReadClubsNames();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Format("{0,-40} | {1,-20}", "Clubs read: " + ans.Count.ToString(), "Time: " + Now));

            return ans;
        }
        public Dictionary<string, string> ReadNationalities()
        {
            var ans = dataBase.ReadNationalities();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Format("{0,-40} | {1,-20}", "Nationalities read: " + ans.Count.ToString(), "Time: " + Now));

            return ans;
        }
        public List<(int, string, int, string, string, string, string, double)> ReadPlayers()
        {
            var ans = dataBase.ReadPlayers();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Format("{0,-40} | {1,-20}", "Players read: " + ans.Count.ToString(), "Time: " + Now));

            return ans;
        }
        public bool UpdatePlayer(int id, string name, int age, string nationality, string club, string position, string status)
        {
            var ans = dataBase.UpdatePlayer(id, name, age, nationality, club, position, status);

            Console.ForegroundColor = ans ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(String.Format("{0,-40} | {1,-20} | {2,-20}", "Update PlayerId = " + id, "Time: " + Now, "Result: " + (ans ? "Correct" : "Error occured")));

            return ans;
        }
        public List<double> ReadRating(int userId, int playerId)
        {
            var ans = dataBase.ReadRating(userId, playerId);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Format("{0,-40} | {1,-20}", "Read rating UserId = " + userId + " PlayerId = " + playerId, "Time: " + Now));

            return ans;
        }
        public bool UpdateInsertRating(int userId, int playerId, List<double> rating)
        {
            var ans = dataBase.UpdateInsertRating(userId, playerId, rating);

            Console.ForegroundColor = ans ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(String.Format("{0,-40} | {1,-20} | {2,-20}", "Update/Insert rating UserId = " + userId + " PlayerId = " + playerId,
                "Time: " + Now, "Result: " + (ans ? "Correct" : "Error occured")));

            return ans;
        }
        public double Predict(List<double> x_predict)
        {
            var ans = NeuralNetwork.Predict(x_predict);

            Console.ForegroundColor = ans != 0.0 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(String.Format("{0,-40} | {1,-20} | {2,-20}", "Predicted Market Value = " + ans,
                "Time: " + Now, "Result: " + (ans != 0.0 ? "Correct" : "Error occured")));

            return ans;
        }
    }
}
