using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Contracts;
using Project.DataAccess;

namespace Project.Query
{
    public class ProjectQuery : IProjectQuery
    {
        private readonly ProjectContext _context;

        public ProjectQuery(ProjectContext context)
        {
            _context = context;
        }

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
