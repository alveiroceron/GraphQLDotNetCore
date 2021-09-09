using GraphQL.Types;
using GraphQL.Utilities;
using GraphQLDotNetCore.GraphQL.GraphQLQueries;
using System;

namespace GraphQLDotNetCore.GraphQL.GraphQLSchema
{
    public class OwnerSchema : Schema
    {
        public OwnerSchema(IServiceProvider provider)
            :base(provider)
        {
            Query = provider.GetRequiredService<OwnerQuery>();
            Mutation = provider.GetRequiredService<OwnerMutation>();
        }
    }
}
