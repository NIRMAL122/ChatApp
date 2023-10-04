using ChatAppAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using PusherServer;

namespace ChatAppAPI.Controllers
{
    [Route(template:"api")]
    [ApiController]
    public class ChatController : Controller
    {
        private readonly IConfiguration _configuration;

        public ChatController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost(template:"messages")]
        public async Task<IActionResult> Message(MessageDTO dto)
        {
            var options = new PusherOptions
            {
                Cluster = "ap2",
                Encrypted = true
            };

            //reading values from Secrets.json file
            var pusher = new Pusher(
              _configuration["appId"],
              _configuration["appKey"],
              _configuration["appSecret"],
              options);

            var result = await pusher.TriggerAsync(
              "Chat",
              "message",
              new 
              {
                  username=dto.Username,
                  Message= dto.Message,
              });

            return Ok(new string[] { });
        }
    }
}
