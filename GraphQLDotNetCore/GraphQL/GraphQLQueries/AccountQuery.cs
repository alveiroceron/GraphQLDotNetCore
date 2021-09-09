using GraphQL.Types;
using GraphQLDotNetCore.Contracts;

namespace GraphQLDotNetCore.GraphQL.GraphQLQueries
{
    public class AccountQuery: ObjectGraphType
    {
        public AccountQuery(IAccountRepository repository)
        {
            //Guid id = new Guid();

            //Field<ListGraphType<AccountType>>(
            //    name: "accounts",
            //    resolve: context => repository.GetAll());



        }
    }
}
