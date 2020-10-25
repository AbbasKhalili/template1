using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Contracts;

namespace Project.QuerySide.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectQuery _query;

        public ProjectController(IProjectQuery query)
        {
            _query = query;
        }

        [HttpGet]
        public async Task<IList<ProjectDto>> Get()
        {
            return await _query.GetAll();
        }

        [HttpGet("{id:long}")]
        public async Task<ProjectDto> Get(long id)
        {
            return await _query.GetById(id);
        }

        [HttpGet("GetGrid/{page:int}/{size:int}")]
        public async Task<IList<ProjectDto>> Get(int page, int size)
        {
            return await _query.GetGrid(page, size);
        }
    }
}
