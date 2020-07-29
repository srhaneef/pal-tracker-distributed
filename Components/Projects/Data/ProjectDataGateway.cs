using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Projects.Data
{
    public class ProjectDataGateway : IProjectDataGateway
    {
        private readonly ProjectContext _context;

        public ProjectDataGateway(ProjectContext context)
        {
            _context = context;
        }

        public ProjectRecord Create(long accountId, string name)
        {
            var recordToCreate = new ProjectRecord(accountId, name, true);

            _context.ProjectRecords.Add(recordToCreate);
            _context.SaveChanges();

            return recordToCreate;
        }

        public List<ProjectRecord> FindBy(long accountId) => _context.ProjectRecords
            .AsNoTracking()
            .Where(a => a.AccountId == accountId)
            .ToList();

        public ProjectRecord FindObject(long projectId)
        {
            try
            {
                return _context.ProjectRecords
                    .AsNoTracking()
                    .Single(a => a.Id == projectId);
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }
    }
}