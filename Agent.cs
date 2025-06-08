using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgentsDB
{
    internal class Agent
    {
        private int id {  get; set; }
        private string codeName { get; set; }
        private string realName { get; set; }
        private string location { get; set; }
        private string status { get; set; }
        private int missionsCompleted { get; set; }
    }
}
