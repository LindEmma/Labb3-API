
using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<APIDbContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/persons", async (APIDbContext context) =>
            {
                var people = await context.Persons.ToListAsync();
                if (people == null || !people.Any())
                {
                    return Results.NotFound("Hittade inga personer");
                }
                return Results.Ok(people);
            });
            app.MapPost("/persons", async (Person person, APIDbContext context) =>
            {
                // Lägg till personen i kontexten
                context.Persons.Add(person);

                // Lägg till intressen för den nya personen, om det finns några
                if (person.Interests != null)
                {
                    foreach (var interest in person.Interests)
                    {
                        context.Interests.Add(interest);
                    }
                }

                // Spara ändringarna i databasen
                await context.SaveChangesAsync();

                return Results.Created($"/people/{person.PersonId}", person);
            });

            // Get interests connected to Person based on PersonId
            app.MapGet("/persons/{personId}/interests", async (int personId, APIDbContext context) =>
            {
                var person = await context.Persons.Include(p => p.Interests).FirstOrDefaultAsync(p => p.PersonId == personId);
                if (person == null)
                {
                    return Results.NotFound("Person not found");
                }
                return Results.Ok(person.Interests);
            });

            // Get links connected to Person by PersonId
            app.MapGet("/persons/{personId}/interests/links", async (int personId, APIDbContext context) =>
            {
                var person = await context.Persons
                                         .Where(p => p.PersonId == personId)
                                         .Include(p => p.Interests)
                                             .ThenInclude(i => i.Links)
                                         .FirstOrDefaultAsync();

                if (person == null)
                {
                    return Results.NotFound("Person not found");
                }

                var links = person.Interests.SelectMany(i => i.Links).ToList();

                if (links.Count == 0)
                {
                    return Results.NotFound("No links connected to person");
                }

                return Results.Ok(links);
            });

            // Adds new interests to Person by PersonId
            app.MapPut("/persons/{personId}/interests", async (int personId, List<Interest> newInterests, APIDbContext context) =>
            {
                var person = await context.Persons
                                            .Where(p => p.PersonId == personId)
                                            .Include(p => p.Interests)
                                            .FirstOrDefaultAsync();
                if (person == null)
                {
                    return Results.NotFound("Person not found");
                }

                // Adds interests
                person.Interests.AddRange(newInterests);

                await context.SaveChangesAsync();

                return Results.Ok("Interests added successfully");
            });

            // Add a link to an interest by interestId and personId
            app.MapPut("/persons/{personId}/interests/{interestId}/links", async (int personId, int interestId, List<Link> newLinks, APIDbContext context) =>
            {
                var person = await context.Persons
                                             .Where(p => p.PersonId == personId)
                                             .Include(p => p.Interests)
                                             .ThenInclude(i => i.Links)
                                             .FirstOrDefaultAsync();

                if (person == null)
                {
                    return Results.NotFound("Person not found");
                }

                var interest = person.Interests.FirstOrDefault(i => i.InterestId == interestId);

                if (interest == null)
                {
                    return Results.NotFound("Interest not found for this person");
                }

                interest.Links.AddRange(newLinks);

                await context.SaveChangesAsync();

                return Results.Ok("Links updated successfully");
            });

            app.Run();
        }
    }
}
