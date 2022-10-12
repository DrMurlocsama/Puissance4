using Puissance4.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4.BLL.DB
{
    public class FakeDB
    {
        public List<Game> GameList { get;  set; }

        public FakeDB()
        {
            GameList = new List<Game>
            {
                new Game
                {
                    Name = "First Game",
                    StartTime = DateTime.Now,
                    State = GameStatEnum.WaitingForPlayer,
                }
            };
        }
    }
}
