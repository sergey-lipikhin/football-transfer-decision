using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Club : ModelBase
    {
        public string Name { set; get; }
        public void ConsoleOutput()
        {
            Console.WriteLine(String.Format("{0,-30}", Name));
        }
    }
}
