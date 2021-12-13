using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
    public DeveloperController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }



    public IActionResult GetPopularDevelopers(
        int count)
{
    var popularDevelopers = _unitOfWork.Developers.GetPopularDevelopers(count);
    return Ok(popularDevelopers);
}

[HttpPost]
public IActionResult AddDeveloperAndProject(Developer d)
{
    var developer = new Developer
    {
        Followers = d.Followers,
        Name = d.Name
    };
    var project = new Project
    {
        Name = d.Name
    };
    _unitOfWork.Developers.Add(developer);
    _unitOfWork.Projects.Add(project);
    _unitOfWork.Complete();
    return Ok(developer);
}
    }
}