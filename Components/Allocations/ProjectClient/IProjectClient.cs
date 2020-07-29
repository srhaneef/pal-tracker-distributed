using System.Threading.Tasks;

namespace Allocations.ProjectClient
{
    public interface IProjectClient
    {
        Task<ProjectInfo> Get(long projectId);
    }
}