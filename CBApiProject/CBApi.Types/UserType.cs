using CBApi.Database.Models;
using GraphQL.Types;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBApi.Types
{
    //public class UserType : ObjectType<User>
    //{
    //    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    //    {
    //        descriptor.Field(f => f.Id)
    //            .Type<NonNullType<IntType>>();
    //        descriptor.Field(f => f.UserName)
    //            .Type<NonNullType<StringType>>();
    //        descriptor.Field(u => u.Password)
    //           .Ignore();
    //        descriptor.Field(f => f.FullName)
    //            .Type<NonNullType<StringType>>();
    //        descriptor.Field(f => f.Email)
    //            .Type<NonNullType<StringType>>();
    //        descriptor.Field(u => u.Token)
    //          .Type<NonNullType<StringType>>();

    //        descriptor.Field(u => u.Active)
    //            .Type<NonNullType<BooleanType>>();

    //        descriptor.Field(f => f.CreatedAt)
    //            .Type<NonNullType<DateType>>();
    //    }
    //}

    //var schema = SchemaBuilder.New()
    //    .AddQueryType<UserType>();
    //.Create();


    //USE THIS FOR GRAPHQL

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
