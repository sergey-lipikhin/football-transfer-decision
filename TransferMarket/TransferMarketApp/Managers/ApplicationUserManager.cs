using System.Collections.Generic;
using System.Linq;
using System.Windows;

using PlayerService;
using Model;

namespace TransferMarketApp.Service
{
    public class ApplicationUserManager
    {
        private static ApplicationUserManager instance;

        private static PlayerServiceClient playerClient;

        private ApplicationUserManager()
        {
            nationalityConverter = new Nationality(new Dictionary<string, string>());
            ClubsNames = new List<string>();
            Players = new List<Player>();
        }
        public static ApplicationUserManager getInstance()
        {
            if (instance == null)
                instance = new ApplicationUserManager();
            return instance;
        }

        public bool SetUser(BaseUser user)
        {
            if (User != null)
                return false;

            User = user;

            try
            {
                playerClient = new PlayerServiceClient();
                // read nation
                nationalityConverter = new Nationality(playerClient.ReadNationalitiesAsync().Result);
                // read clubs
                ClubsNames = playerClient.ReadClubsNamesAsync().Result.ToList();
                // read players
                playerClient.ReadPlayersAsync().Result.ToList().ForEach(el => Players.Add(new Player(el)));
                playerClient.Abort();
            }
            catch
            {
                MessageBox.Show("Error server!");
            }

            return true;
        }

        public bool IsAdmin =>
            User.GetType() == typeof(Admin);
        public BaseUser User { private set; get;}

        public Nationality nationalityConverter;
        public List<string> ClubsNames;
        public List<Player> Players;

        public void UpdatePlayers()
        {
            try
            {
                playerClient = new PlayerServiceClient();
                Players.Clear();
                playerClient.ReadPlayersAsync().Result.ToList().ForEach(el => Players.Add(new Player(el)));
                playerClient.Abort();
            }
            catch { }
        }
        public bool UpdatePlayer(int id, string name, int age, string nationality, string club, string position, string status)
        {
            try
            {
                playerClient = new PlayerServiceClient();
                bool ans = playerClient.UpdatePlayerAsync(id, name, age, nationality, club, position, status).Result;
                playerClient.Abort();
                return ans;
            }
            catch
            {
                return false;
            }
        }
        public List<double> ReadRating(int userId, int playerId)
        {
            try
            {
                playerClient = new PlayerServiceClient();
                List<double> ans = playerClient.ReadRatingAsync(userId, playerId).Result.ToList();
                playerClient.Abort();
                return ans;
            }
            catch
            {
                return new List<double>();
            }
        }
        public bool UpdateInsertRating(int userId, int playerId, List<double> rating)
        {
            try
            {
                playerClient = new PlayerServiceClient();
                bool ans = playerClient.UpdateInsertRatingAsync(userId, playerId, rating.ToArray()).Result;
                playerClient.Abort();
                return ans;
            }
            catch
            {
                return false;
            }
        }

        public double Predict(List<double> features)
        {
            try
            {
                playerClient = new PlayerServiceClient();
                double ans = playerClient.PredictAsync(features.ToArray()).Result;
                playerClient.Abort();
                return ans;
            }
            catch
            {
                return 0.0;
            }
        }
    }
}
