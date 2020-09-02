using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace RobotPipetting.Data
{
    public class Well
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsFull { get; set; }
    }

    public class Command
    {
        public CommandType Name { get; set; }
        public string Arguments { get; set; }
    }

    public enum CommandType
    {
        PLACE,
        DETECT,
        DROP,
        MOVE,
        REPORT
    }
    
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public enum Movement
    {
        N,
        S,
        E,
        W
    }

}
