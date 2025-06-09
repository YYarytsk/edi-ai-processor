
using Microsoft.AspNetCore.Mvc;
using System.IO;

[ApiController]
[Route("api/[controller]")]
public class EDIController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public EDIController(IWebHostEnvironment env)
    {
        _env = env;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Invalid file.");

        var uploadPath = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");
        Directory.CreateDirectory(uploadPath);
        var filePath = Path.Combine(uploadPath, file.FileName);

        using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }

        var ediContent = await System.IO.File.ReadAllTextAsync(filePath);
        var segments = ediContent.Split('~');

        return Ok(new {
            FileName = file.FileName,
            ParsedContent = ediContent,
            Segments = segments
        });
    }
}
