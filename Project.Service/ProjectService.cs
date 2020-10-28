using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
            var newId = await GetNextId();
            var project = new Domain.Project(newId, model.Name);
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return newId;
        }

        private async Task<long> GetNextId()
        {
            var param = new SqlParameter("@result", SqlDbType.BigInt) {Direction = ParameterDirection.Output};
            await _context.Database.ExecuteSqlRawAsync("set @result = next value for ProjectSequence", param);
            return (long)param.Value;
        }

        public async Task Modify(ProjectViewModel model)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(a => a.Id == model.Id);
            project?.Modify(model.Name);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(a => a.Id == id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
