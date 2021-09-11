using GraphQL;
using GraphQL.Types;
using GraphQLDotNetCore.Contracts;
using GraphQLDotNetCore.Entities;
using GraphQLDotNetCore.GraphQL.GraphQLTypes;
using System;

namespace GraphQLDotNetCore.GraphQL.GraphQLQueries
{
    public class OwnerMutation : ObjectGraphType
    {
        public OwnerMutation(IOwnerRepository repository)
        {
            Field<OwnerType>(
                name: "createOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" }),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    return repository.CreateOwner(owner);
                });

            Field<OwnerType>(
                name: "updateOwner",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    var ownerId = context.GetArgument<Guid>("ownerId");

                    var dbOwner = repository.GetById(ownerId);
                    if (dbOwner == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn´t find owner in db.."));
                        return null;

                    }
                    return repository.UpdateOwner(dbOwner, owner);

                }
            );

            Field<StringGraphType>(
                name: "deleteOwner",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" }),
                resolve: context =>
                {
                    var ownerId = context.GetArgument<Guid>("ownerId");

                    var owner = repository.GetById(ownerId);

                    if (owner == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn´t find owner in db.."));
                        return null;

                    }

                    repository.DeleteOwner(owner);
                    return $"The owner woth the id {ownerId} has been successfully deleted from db.";
                }
               );

        }
    }
}
