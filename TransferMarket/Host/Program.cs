using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServiceLevel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(PlayerService)))
            {
                host.Open();
                Console.WriteLine(host.State);
                Console.WriteLine(host.BaseAddresses[0].ToString());
                Console.WriteLine("Host started!");
                Console.ReadKey();
            }
        }
    }
}
