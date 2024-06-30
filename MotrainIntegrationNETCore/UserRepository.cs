using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotrainIntegrationNETCore
{
    public class UserRepository
    {
        private readonly DataContext _context;

        public UserRepository()
        {
            _context = new DataContext();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.FromSqlRaw("EXEC APIGetAllUsers").ToList();
        }
    }
}
