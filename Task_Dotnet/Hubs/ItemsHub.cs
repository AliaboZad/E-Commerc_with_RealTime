using Microsoft.AspNetCore.SignalR;
using Task_Dotnet.DataContext;
using Task_Dotnet.DTO;
using Task_Dotnet.IRepo;
using Task_Dotnet.Models;

namespace Task_Dotnet.Hubs
{
    public class ItemsHub : Hub
    {
          
        public async Task Broadcoastitems(Items items)
        {
            
            // Hub Method to send Data in realtime 
            await Clients.All.SendAsync("ReceiveItems" , items);
        }

        public async Task SendItemUpdatedNotification(Items items)
        {

            // Hub Method to send Data in realtime 
            await Clients.All.SendAsync("ItemUpdated", items);
        }

        public async Task SendItemDeletedNotification(Items items)
        {

            // Hub Method to send Data in realtime 
            await Clients.All.SendAsync("ItemDeleted", items);
        }


    }
}
