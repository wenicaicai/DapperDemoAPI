using Microsoft.AspNetCore.Mvc;
using Sockets_UDP;

namespace DapperDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocketBetaController : ControllerBase
    {
        [HttpGet]
        public void Get()
        {
            SocketsClientBeta clientBeta = new SocketsClientBeta();
            clientBeta.TrySocketClient();
        }

    }
}