using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Playground.PoC.FormulaOneK8s.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebHooksController : ControllerBase
    {
        private readonly ILogger<WebHooksController> _logger;

        public WebHooksController(ILogger<WebHooksController> logger)
        {
            _logger = logger;
        }

        [HttpPost("f1k8s")]
        public IActionResult F1K8s([FromBody] object payload)
        {
            _logger.LogInformation("Received F1K8s webhook with payload: {Payload}", payload);

            // Process the incoming webhook payload
            // For demonstration, we just return a success response
            return Ok(new { message = "Webhook received successfully", data = payload });
        }
        
        [HttpGet("status")]
        public IActionResult Status()
        {
            _logger.LogInformation("Status check for webhooks");

            // Return a simple status message
            return Ok(new { status = "Webhooks are active" });
        }
    }
}
