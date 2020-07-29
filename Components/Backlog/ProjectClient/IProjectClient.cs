using System.Threading.Tasks;

namespace Backlog.ProjectClient
{
    public interface IProjectClient
    {
        Task<ProjectInfo> Get(long projectId);
    }
}