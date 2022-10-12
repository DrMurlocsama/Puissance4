using Microsoft.AspNetCore.SignalR;
using Puissance4.BLL.Services;

namespace Puissance4.Hubs
{
    public class GameHub : Hub
    {
        private readonly GameService _gameService;

        public GameHub(GameService gameService)
        {
            _gameService = gameService;
        }

        public async Task JoinGame(string gameName, string userName)
        {
            try
            {
                _gameService.AddPlayerToGame(gameName, userName, Context.ConnectionId);
                await Groups.AddToGroupAsync(Context.ConnectionId, gameName);
                await SendToGroup(userName + " à rejoint la partie", gameName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); 
            }
        }

        public async Task SendToGroup(string message, string groupname)
        {
            await Clients.Group(groupname).SendAsync("to" + groupname, message);
        }

        public async Task NewGame(string gameName, string userName)
        {
            try
            {
                _gameService.CreatGame(gameName, userName,Context.ConnectionId);
                await Clients.All.SendAsync("allFreeGames", _gameService.GetGames());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("allFreeGames", _gameService.GetGames());
        }
    }
}
