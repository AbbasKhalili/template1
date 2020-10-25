using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Contracts
{
    public interface IProjectQuery
    {
        Task<IList<ProjectDto>> GetAll();
        Task<ProjectDto> GetById(long id);
        Task<IList<ProjectDto>> GetGrid(int page,int size);
    }
}
