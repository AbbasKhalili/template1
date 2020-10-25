using System.Threading.Tasks;

namespace Project.Contracts
{
    public interface IProjectService
    {
        Task<long> Create(ProjectViewModel model);
        Task Modify(ProjectViewModel model);
        Task Delete(long id);
    }
}