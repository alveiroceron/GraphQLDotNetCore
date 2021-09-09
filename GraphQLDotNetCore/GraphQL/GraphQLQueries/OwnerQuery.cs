using GraphQL;
using GraphQL.Types;
using GraphQLDotNetCore.Contracts;
using GraphQLDotNetCore.GraphQL.GraphQLTypes;
using System;

namespace GraphQLDotNetCore.GraphQL.GraphQLQueries
{
    public class OwnerQuery : ObjectGraphType
    {
        public OwnerQuery(IOwnerRepository repository)
        {
           
            Field<ListGraphType<OwnerType>>(
                name: "owners",
                resolve: context => repository.GetAll());

            Field<OwnerType>(
                name: "owner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>{ Name = "ownerId" }),
                resolve: context =>
                {
                    Guid id;
                    if (!Guid.TryParse(context.GetArgument<string>("ownerId"), out id))
                    {
                        context.Errors.Add(new ExecutionError("wrong value for guid"));
                        return null;
                    }

                    return repository.GetById(id);
                });
               
         
        }
    }
}
