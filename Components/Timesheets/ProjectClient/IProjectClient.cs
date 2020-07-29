using System.Threading.Tasks;

namespace Timesheets.ProjectClient
{
    public interface IProjectClient
    {
        Task<ProjectInfo> Get(long projectId);
    }
}