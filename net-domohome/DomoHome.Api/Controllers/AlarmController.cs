namespace DomoHome.Api.Controllers
{
    using DomoHome.Api.Services;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;

    [ApiController]
    [Route("[controller]")]
    public class AlarmController : ControllerBase
    {
        private readonly IHubContext<AlarmHub> hub;

        private string alarmState;

        public AlarmController(IHubContext<AlarmHub> hubContext)
        {
            this.hub = hubContext;
        }

        [HttpGet]
        public IActionResult GetAlarmStatus()
        {
            return this.Ok(this.alarmState);
        }

        [HttpPost]
        public async Task<IActionResult> SetAlarmStatus(string status)
        {
            this.alarmState = status;
            await this.hub.Clients.All.SendAsync("alarmStateChanged", status);
            return this.Ok();
        }

        [HttpGet]
        [Route("camera")]
        public IActionResult GetCameraImage()
        {
            Camera camera = new Camera();
            byte[] imageBytes = camera.Capture();
            return this.File(imageBytes, "image/jpeg");
        }
    }
}