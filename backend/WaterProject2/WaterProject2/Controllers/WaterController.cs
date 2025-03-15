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
    public IActionResult GetProjects(int pageHowMany = 10, int pageNum = 1)
    {
        var something = _waterContext.Projects
            .Skip((pageNum - 1) * pageHowMany)
            .Take(pageHowMany)
            .ToList();
        
        var totalNumProjects = _waterContext.Projects.Count();

        return Ok(new
        {
            Projects = something,
            TotalNumProjects = totalNumProjects
        });
    }
    
    [HttpGet("FunctionalProjects")]
    public IEnumerable<Project> GetFunctionalProjects()
    {
        var something = _waterContext.Projects.Where(p => p.ProjectFunctionalityStatus == "Functional").ToList();

        return something;
    }
    
    
    
    
    
}

