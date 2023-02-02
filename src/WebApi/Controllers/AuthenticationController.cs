using Microsoft.AspNetCore.Mvc;

namespace JMTopUpBackend.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> logger;
    private readonly ICryptographyService cryptographyService;

    public AuthenticationController(ILogger<AuthenticationController> logger, ICryptographyService cryptographyService)
    {
        this.logger = logger;
        this.cryptographyService = cryptographyService;
    }
}
