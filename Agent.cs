using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgentsDB
{
    public class Agent
    {
        public int id {  get; set; }
        public string codeName { get; set; }
        public string realName { get; set; }
        public string location { get; set; }
        public string status { get; set; }
        public int missionsCompleted { get; set; }
        public Agent(string codeName, string realName, string location, string status, int missionsCompleted)
        {
 
            this.codeName = codeName;
            this.realName = realName;
            this.location = location;
            this.status = status;
            this.missionsCompleted = missionsCompleted;
        }
    }
}
