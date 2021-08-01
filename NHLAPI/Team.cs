using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLAPI
{
    public class Team
    {
        public Guid TeamId {get;set;}
        public List<Player> Players { get; set; }
    }
}
