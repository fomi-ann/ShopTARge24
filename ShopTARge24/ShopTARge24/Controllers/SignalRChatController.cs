using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ShopTARge24.Hubs;

namespace ShopTARge24.Controllers
{
    public class SignalRChatController : Controller
    {
        private readonly IHubContext<DeathlyHallowsHub> _deathlyHub;

        public SignalRChatController
            (
                IHubContext<DeathlyHallowsHub> deathlyHub
            )
        {
            _deathlyHub = deathlyHub;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DeathlyHallows(string type)
        {
            if (SD.DeathlyHallowRace.ContainsKey(type))
            {
                SD.DeathlyHallowRace[type]++;
            }
            await _deathlyHub.Clients.All.SendAsync("updateDeathlyHallowCount",
                SD.DeathlyHallowRace[SD.Cloak],
                SD.DeathlyHallowRace[SD.Stone],
                SD.DeathlyHallowRace[SD.Wand]);

            return Accepted();
        }
    }
}

