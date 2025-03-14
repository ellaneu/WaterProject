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
    public IEnumerable<Project> GetProjects()
    {
        var something = _waterContext.Projects.ToList();

        return something;
    }
    
    [HttpGet("FunctionalProjects")]
    public IEnumerable<Project> GetFunctionalProjects()
    {
        var something = _waterContext.Projects.Where(p => p.ProjectFunctionalityStatus == "Functional").ToList();

        return something;
    }
    
    
    
    
    
}

