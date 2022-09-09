using GraphQL.Types;
using GraphQLNetExample.Context;
using GraphQLNetExample.Models;
using GraphQLNetExample.Types;

namespace GraphQLNetExample.Queries;

public class NoteQuery : ObjectGraphType
{
    public NoteQuery()
    {
        Field<ListGraphType<NoteType>>("notes", resolve: context => new List<Note>
        {
            new Note { Id = Guid.NewGuid(), Message = "Hello World!" },
            new Note { Id = Guid.NewGuid(), Message = "Hello World! How are you?" }
        });
        Field<ListGraphType<NoteType>>("notesFromEF", resolve: context =>
        {
            var notesContext = context.RequestServices.GetRequiredService<NotesContext>();
            return notesContext.Note.ToList();
        });
    }
}