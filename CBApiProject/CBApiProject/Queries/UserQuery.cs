using CBApi.DataAccess.Repository.Contracts;
using CBApi.Database;
using CBApi.Database.Models;
using CBApi.Types;
using GraphQL.Types;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CBApiProject.Queries
{
    //USE THIS FOR GRAPGQL

    //public class UserQuery : ObjectGraphType
    //{
    //    public UserQuery(IUserRepository userRepository)
    //    {
    //        //pass as generic parameter list of clients 

    //        Field<ListGraphType<UserType>>(
    //            "users",
    //            //this discrib how to resolve the query (e.g: resolve with the Get() from the repository)  
    //            resolve: context => userRepository.GetAll());
    //    }
    //}

    public class UserQuery
    {
        public UserQuery()
        {

        }

        public async Task<IReadOnlyList<User>> GetUsers([Service] CBApiContext dbContext)
        {
            return await dbContext.Users.ToListAsync();

        }

    }

}
