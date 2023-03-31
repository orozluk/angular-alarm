namespace DomoHome.Api.Services
{
    using Microsoft.AspNetCore.SignalR;

    public class AlarmHub : Hub
    {
        public async Task SetAlarmState(string newState)
        {
            await this.Clients.All.SendAsync("alarmStateChanged", newState);
        }
    }
}