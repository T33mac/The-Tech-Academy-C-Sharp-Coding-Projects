using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Interfaces
{
    interface IWalkAway        //interfaces are automatically "public" so that property can be left out
    {                          //Must always start with capital I to identify as "I" Interface
        void WalkAway(Player player);  //parameter is player object from Player class
    }
}
