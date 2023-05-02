using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.IO;

namespace DataLevel
{
    public abstract class DataBase
    {
        //protected static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\I-IV-Univer\DeepDarkFantasies\work\TransferMarket\DataLevel\TransferMarket.mdf;Integrated Security=True";

        protected SqlConnection sqlconnection;

        private static string ConnectionString
        {
            get
            {
                string initialPath = Environment.CurrentDirectory;
                string targetPath = Path.Combine(
                    Directory.GetParent(
                        Directory.GetParent(
                            Directory.GetParent(initialPath).FullName)
                        .FullName)
                    .FullName,
                    "DataLevel",
                    "TransferMarket.mdf");

                return
                    "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename="
                    + targetPath
                    + ";Integrated Security = True;";

            }
        }

        public DataBase()
        {
            sqlconnection = new SqlConnection(ConnectionString);
        }

        protected bool OpenConnection()
        {
            if (sqlconnection.State != System.Data.ConnectionState.Open)
            {
                sqlconnection.Open();
                return true;
            }
            return false;
        }
        protected bool CloseConnection()
        {
            if (sqlconnection.State == System.Data.ConnectionState.Open)
            {
                sqlconnection.Close();
                return true;
            }
            return false;
        }
    }
}
