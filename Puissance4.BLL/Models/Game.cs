using Puissance4.BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4.BLL.Models
{
    public class Game
    {
        public string Name { get; set; } = string.Empty;
        public User? PlayerOne { get; set; }
        public User? PlayerTwo { get; set; }
        public DateTime StartTime { get; set; }
        public GameStatEnum State { get; set; }
    }
}
