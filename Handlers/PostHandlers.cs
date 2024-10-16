using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using AspNetMinimalApiTemplate.Data;
using AspNetMinimalApiTemplate.Models;

namespace AspNetMinimalApiTemplate.Handlers;

public static class PostHandlers {
    public static void MapPostHandlers(this IEndpointRouteBuilder routes) {
        routes.MapGet("/posts", async (AppDbContext db) => {
            return await db.Posts.ToListAsync();
        });

        routes.MapPost("/posts", async (AppDbContext db, Post post) => {
            db.Posts.Add(post);
            await db.SaveChangesAsync();
            return Results.Created($"/posts/{post.Id}", post);
        });

        routes.MapGet("/posts/{id}", async (AppDbContext db, int id) => {
            return await db.Posts.FindAsync(id)
                is Post post
                    ? Results.Ok(post)
                    : Results.NotFound();
        });

        routes.MapPut("/posts/{id}", async (AppDbContext db, int id, Post inputPost) => {
            var post = await db.Posts.FindAsync(id);

            if(post is null) {
                return Results.NotFound();
            }

            post.Title = inputPost.Title;
            post.Content = inputPost.Content;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        routes.MapDelete("/posts/{id}", async (AppDbContext db, int id) => {
            if(await db.Posts.FindAsync(id) is Post post) {
                db.Posts.Remove(post);
                await db.SaveChangesAsync();
                return Results.Ok(post);
            }

            return Results.NotFound();
        });
    }
}

