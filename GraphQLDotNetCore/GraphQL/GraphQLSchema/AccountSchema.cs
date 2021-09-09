using GraphQL.Types;
using GraphQL.Utilities;
using GraphQLDotNetCore.GraphQL.GraphQLQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNetCore.GraphQL.GraphQLSchema
{
    public class AccountSchema: Schema
    {
        public AccountSchema(IServiceProvider provider)
            :base(provider)
        {
            Query = provider.GetRequiredService<AccountQuery>();
        }
    }
}
