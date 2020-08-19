using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Szerencsefaktor.ForDatabase
{
    class AbException :Exception
    {
        public AbException(string message, Exception ex): base(message, ex)
        {
            //Log.Bejegyzes(this);
        }
    }
}
