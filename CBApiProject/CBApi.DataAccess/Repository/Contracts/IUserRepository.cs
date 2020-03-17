using CBApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBApi.DataAccess.Repository.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}
