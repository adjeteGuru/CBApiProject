using CBApi.DataAccess.Repository.Contracts;
using CBApi.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBApiProject.Queries
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(IUserRepository userRepository)
        {
            //pass as generic parameter list of clients 

            Field<ListGraphType<UserType>>(
                "users",
                //this discrib how to resolve the query (e.g: resolve with the Get() from the repository)  
                resolve: context => userRepository.GetAll());
        }
    }
}
