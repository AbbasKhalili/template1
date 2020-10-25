using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Contracts;

namespace Project.Query
{
    public class ProjectQuery : IProjectQuery
    {
        public async Task<IList<ProjectDto>> GetAll()
        {
            
        }

        public async Task<ProjectDto> GetById(long id)
        {
            
        }

        public async Task<IList<ProjectDto>> GetGrid(int page, int size)
        {
            
        }
    }
}
