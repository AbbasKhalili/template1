using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            var list = await _context.Projects.ToListAsync();
            return ProjectMapper.Map(list);
        }

        public async Task<ProjectDto> GetById(long id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(a => a.Id == id);
            return ProjectMapper.Map(project);
        }

        public async Task<IList<ProjectDto>> GetGrid(int page, int size)
        {
            var list = await _context.Projects.ToListAsync();
            var result = list.Skip(page * size).Take(size).ToList();
            return ProjectMapper.Map(result);
        }
    }
}
