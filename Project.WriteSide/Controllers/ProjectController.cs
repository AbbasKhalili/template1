﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Contracts;

namespace Project.WriteSide.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<long> Get(ProjectViewModel model)
        {
            return await _service.Create(model);
        }

        [HttpPut("{id:long}")]
        public async Task Put(long id, ProjectViewModel model)
        {
            model.Id = id;
            await _service.Modify(model);
        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
