using GraphQL;
using GraphQL.Types;
using GraphQLNetExample.Context;
using GraphQLNetExample.Models;
using GraphQLNetExample.Types;

namespace GraphQLNetExample.Mutations;

public class NotesMutation : ObjectGraphType
{
    public NotesMutation()
    {
        Field<NoteType>(
            "createNote",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "message" }
            ),
            resolve: context =>
            {
                var message = context.GetArgument<string>("message");
                var notesContext = context.RequestServices.GetRequiredService<NotesContext>();

                var existingNote = notesContext.Note.FirstOrDefault(p => p.Message == message);
                if (existingNote is null)
                {
                    var note = new Note
                    {
                        Message = message,
                    };
                    notesContext.Note.Add(note);
                    notesContext.SaveChanges();
                    return note;    
                }

                //Dirty way to deal with this - need a better way to handle it!
                return new Note() { Message = "Note Already Exists!" };
            }
        );
    }
}