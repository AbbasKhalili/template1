using System.Collections.Generic;
using System.Linq;
using Project.Contracts;

namespace Project.Query
{
    public static class ProjectMapper
    {
        public static ProjectDto Map(Domain.Project model)
        {
            return new ProjectDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static List<ProjectDto> Map(List<Domain.Project> list)
        {
            return list.Select(Map).ToList();
        }
    }
}