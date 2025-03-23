using Microsoft.AspNetCore.Mvc;
using WaterProject2.Data;

namespace WaterProject2.Controllers;

[ApiController]
[Route("[controller]")]

public class WaterController : ControllerBase
{
    private WaterDbContext _waterContext;
    
    public WaterController(WaterDbContext temp)
    {
        _waterContext = temp;
    }
    
    [HttpGet("AllProjects")]
    public IActionResult GetProjects(int pageHowMany = 10, int pageNum = 1, [FromQuery] List<string>? projectTypes = null)
    {
        
        var query = _waterContext.Projects.AsQueryable();

        if (projectTypes != null && projectTypes.Any())
        {
            query = query.Where(p => projectTypes.Contains(p.ProjectType));
        }
        
        string favoriteProject = Request.Cookies["favoriteProject"];
        Console.WriteLine($"favoriteProject: {favoriteProject}");
        
        HttpContext.Response.Cookies.Append("FavoriteProjectType", "Borehole Well and Hand Pump", new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.Now.AddMinutes(1)
        
        });
        
        var totalNumProjects = query.Count();
        
        var something = query
            .Skip((pageNum - 1) * pageHowMany)
            .Take(pageHowMany)
            .ToList();

        return Ok(new
        {
            Projects = something,
            TotalNumProjects = totalNumProjects
        });
    }

    [HttpGet("GetProjectTypes")]
    public IActionResult GetProjectTypes()
    {
        var projectTypes = _waterContext.Projects
            .Select(p => p.ProjectType)
            .Distinct()
            .ToList();
        
        return Ok(projectTypes);
    }
    
    [HttpGet("FunctionalProjects")]
    public IEnumerable<Project> GetFunctionalProjects()
    {
        var something = _waterContext.Projects.Where(p => p.ProjectFunctionalityStatus == "Functional").ToList();

        return something;
    }
    
    
    
    
    
}

