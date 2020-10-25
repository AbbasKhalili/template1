using System.Threading.Tasks;
using Project.Contracts;
using Project.DataAccess;

namespace Project.Service
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectContext _context;

        public ProjectService(ProjectContext context)
        {
            _context = context;
        }

        public async Task<long> Create(ProjectViewModel model)
        {
            
        }

        public async Task Modify(ProjectViewModel model)
        {
            
        }

        public async Task Delete(long id)
        {
            
        }
    }
}
