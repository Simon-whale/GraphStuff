using GraphQLNetExample.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLNetExample.Context;

public class NotesContext : DbContext
{
    public DbSet<Note> Note { get; set; }

    public NotesContext(DbContextOptions option) : base(option)
    {
        var t = option;
    }
}