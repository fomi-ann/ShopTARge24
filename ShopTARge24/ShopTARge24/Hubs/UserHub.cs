using Microsoft.AspNetCore.SignalR;

namespace ShopTARge24.Hubs
{
    public class UserHub : Hub
    {
        public static int TotalViews { get; set; } = 0;
        public async Task NewWindowLoaded()
        {
            TotalViews++;
            //Send Update to all clients that total views have been updated
            await Clients.All.SendAsync("updateTotalViews", TotalViews);
        }
    }
}
