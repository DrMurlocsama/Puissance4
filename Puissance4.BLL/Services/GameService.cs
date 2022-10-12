using Puissance4.BLL.DB;
using Puissance4.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4.BLL.Services
{
    public class GameService
    {
        private readonly FakeDB _fakeDB;

        public GameService(FakeDB fakeDB)
        {
            _fakeDB = fakeDB;
        }

        public IEnumerable<Game> GetGames()
        {
            return _fakeDB.GameList.Where(g => g.State == GameStatEnum.WaitingForPlayer);
        }

        public void AddPlayerToGame(string gameName, string userName, string connectionId)
        {
            Game? game = _fakeDB.GameList.SingleOrDefault(g => g.Name == gameName);
            if (game == null)
            {
                throw new Exception("Unvalid Game Name");
            }
            game.State = GameStatEnum.Started;
            game.PlayerTwo = new User
            {
                UserId = connectionId,
                Name = userName,
            };
        }

        public void CreatGame(string gameName, string userName, string connectionId)
        {
            if (_fakeDB.GameList.Any(g => g.Name == gameName))
            {
                throw new Exception("Game name already exists");
            }
            _fakeDB.GameList.Add( new Game
            {
                Name = gameName,
                StartTime = DateTime.Now,
                PlayerOne = new User
                {
                    UserId = connectionId,
                    Name = userName,
                }
            });
        }
    }
}
