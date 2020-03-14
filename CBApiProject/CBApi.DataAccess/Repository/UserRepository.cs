using CBApi.DataAccess.Repository.Contracts;
using CBApi.Database;
using CBApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBApi.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CBApiContext _dbContext;
        public UserRepository(CBApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }
    }
}
