using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLevel
{
    [ServiceContract]
    public interface IPlayerService
    {
        [OperationContract]
        List<string> ReadClubsNames();
        [OperationContract]
        Dictionary<string, string> ReadNationalities();
        [OperationContract]
        List<(int, string, int, string, string, string, string, double)> ReadPlayers();
        [OperationContract]
        bool UpdatePlayer(int id, string name, int age, string nationality, string club, string position, string status);
        [OperationContract]
        List<double> ReadRating(int userId, int playerId);
        [OperationContract]
        bool UpdateInsertRating(int userId, int playerId, List<double> rating);
        [OperationContract]
        double Predict(List<double> x_predict);
    }
}
