using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Contracts;

namespace ProjectHost.Controllers
{
    [ApiController]
    [Route("api/Project")]
    public class ProjectQueryController : ControllerBase
    {
        private readonly IProjectQuery _query;

        public ProjectQueryController(IProjectQuery query)
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
