using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class BaseUser : ModelBase
    {
        public string Login { set; get; }
        public string Password { set; get; }
    }
}
