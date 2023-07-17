using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FanEase.ExceptionHandling.Aspect_Oriented_Programming
{
    public class SampleModel : PageModel
    {
        private readonly ILogger<SampleModel> _logger;
        public SampleModel(ILogger<SampleModel> logger)
        {
            _logger = logger;
            _logger.LogDebug("Hey, this is a DEBUG message.");
            _logger.LogInformation("Hey, this is an INFO message.");
            _logger.LogWarning("Hey, this is a WARNING message.");
            _logger.LogError("Hey, this is an ERROR message.");

        }
    }
}
