using CBApiProject.Queries;
using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBApiProject.Schema
{
    public class CBApiSchema : GraphQL.Types.Schema
    {//and need to take Idependency resolver as a ctor parameter and
        //pass it to the base class
        public CBApiSchema(IDependencyResolver resolver)
            //pass it to the base class
            : base(resolver)
        {
            Query = resolver.Resolve<UserQuery>();
        }


       
    }
}
