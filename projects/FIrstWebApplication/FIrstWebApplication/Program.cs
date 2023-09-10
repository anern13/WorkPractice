using Microsoft.EntityFrameworkCore;
using FIrstWebApplication;
using System.IO.Pipelines;
using System.Net.Mail;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//setup exception handlers
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

app.MapGet("/",() => "hey this is my website for testing");
/*****************************************************************************/

app.MapGet("/todoitems/complete", async (TodoDb db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());
/*****************************************************************************/

app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync());
/*****************************************************************************/
app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);

    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});
/*****************************************************************************/

app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if(todo is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(todo);
});
/*****************************************************************************/

app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    if (inputTodo.Name is not null)
        todo.Name = inputTodo.Name;

    todo.IsComplete = inputTodo.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});
/*****************************************************************************/

app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});
/*****************************************************************************/

app.MapGet("/todoitems/attachment/{id}", async (int id, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is not null)
    {
        if(todo.IsOnServer())
            return Results.File(todo.ServFilePath,null, todo.FileName);

        return Results.NotFound("attachment not found");
    }

    return Results.NotFound(id);
});
/*****************************************************************************/

app.MapPost("/todoitems/attachment/{id}", async (int id, TodoDb db, PipeReader file) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is not null)
    {
        if (todo.IsOnServer())
            return Results.Conflict("file already exist");
       
        await todo.Upload(file);
        await db.SaveChangesAsync();

        return Results.Created($"/todoitems/attachment/{todo.Id}", todo);
    }

    return Results.NotFound(id);
});
/*****************************************************************************/
app.MapPut("/todoitems/attachment/{id}", async (int id, TodoDb db, PipeReader file) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is not null)
    {
        if (!todo.IsOnServer())
            return Results.Conflict("file not exist");

        todo.Delete();
        await todo.Upload(file);
        await db.SaveChangesAsync();

        return Results.Accepted($"/todoitems/attachment/{todo.Id}", todo);
    }

    return Results.NotFound(id);
});
/*****************************************************************************/
app.MapDelete("/todoitems/attachment/{id}", async (int id, TodoDb db, PipeReader file) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is not null)
    {
        if (todo.IsOnServer())
        {
            todo.Delete();
            await db.SaveChangesAsync();
            return Results.Ok();
        }
    }

    return Results.NotFound(id);
});
/*****************************************************************************/


app.Run();
