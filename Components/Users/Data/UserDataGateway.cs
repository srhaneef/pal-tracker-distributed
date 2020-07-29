using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Users.Data
{
    public class UserDataGateway : IUserDataGateway
    {
        private readonly UserContext _context;

        public UserDataGateway(UserContext context)
        {
            _context = context;
        }

        public UserRecord Create(string name)
        {
            var recordToCreate = new UserRecord(name);

            _context.UserRecords.Add(recordToCreate);
            _context.SaveChanges();

            return recordToCreate;
        }

        public UserRecord FindObjectBy(long id) {
            try
            {
                return _context.UserRecords
                    .AsNoTracking()
                    .Single(u => u.Id == id);
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }

    }
}