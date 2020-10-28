using System.Threading.Tasks;

namespace Project.Contracts
{
    public interface IProjectService : IFacadeService
    {
        Task<long> Create(ProjectViewModel model);
        Task Modify(ProjectViewModel model);
        Task Delete(long id);
    }
}