using Microsoft.AspNetCore.Mvc;

namespace DotnetK8sApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InfoController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private readonly IConfiguration _configuration;

    public InfoController(IWebHostEnvironment environment, IConfiguration configuration)
    {
        _environment = environment;
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            service = "dotnet-k8s-api",
            environment = _environment.EnvironmentName,
            version = _configuration["App:Version"] ?? "dev",
            podName = Environment.GetEnvironmentVariable("POD_NAME") ?? "local"
        });
    }
}
