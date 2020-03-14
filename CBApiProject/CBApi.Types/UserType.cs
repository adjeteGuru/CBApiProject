using CBApi.Database.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBApi.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {

            Field(a => a.Id);
            Field(a => a.UserName);
            Field(a => a.FullName);
            Field(a => a.CreatedAt);
            Field(a => a.Email);
   
        }
    }
}
