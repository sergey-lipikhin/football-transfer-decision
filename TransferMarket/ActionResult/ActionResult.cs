using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ActionResults
{
    [DataContract]
    public enum DataActionResult
    {
        CORRECT = 1,
        GENERAL_ERROR,
        UNUNIQUE,
        NO_CLUB,
        NO_POSITION
    }
}
