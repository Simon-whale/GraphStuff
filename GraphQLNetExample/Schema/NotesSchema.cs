using GraphQLNetExample.Mutations;
using GraphQLNetExample.Queries;

namespace GraphQLNetExample.Schema;

public class NotesSchema : GraphQL.Types.Schema
{
    public NotesSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<NoteQuery>();
        Mutation = serviceProvider.GetRequiredService<NotesMutation>();
    }
}