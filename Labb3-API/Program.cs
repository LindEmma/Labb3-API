using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

// Emma Lind .NET23, Labb3 - API
namespace Labb3_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<APIDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Get all people in database
            app.MapGet("/persons", async (APIDbContext context) =>
            {
                var people = await context.Persons.ToListAsync();
                if (people == null || !people.Any())
                {
                    return Results.NotFound("Hittade inga personer");
                }
                return Results.Ok(people);
            });

            // Create a new person
            app.MapPost("/persons", async (Person person, APIDbContext context) =>
            {
                // Adds the person
                context.Persons.Add(person);

                // Adds persons interests
                if (person.Interests != null)
                {
                    foreach (var interest in person.Interests)
                    {
                        context.Interests.Add(interest);
                    }
                }

                // Saves changes to database
                await context.SaveChangesAsync();

                return Results.Created($"/people/{person.PersonId}", person);
            });

            // Get interests connected to a Person based on PersonId
            app.MapGet("/persons/{personId}/interests", async (int personId, APIDbContext context) =>
            {
                var person = await context.Persons
                            .Include(p => p.Interests)
                            .FirstOrDefaultAsync(p => p.PersonId == personId);

                if (person == null)
                {
                    return Results.NotFound("Person not found"); //checks if person exists
                }

                return Results.Ok(person.Interests); //returns persons interests
            });

            // Get links connected to Person by PersonId
            app.MapGet("/persons/{personId}/interests/links", async (int personId, APIDbContext context) =>
            {
                // gets person by personid, with interests and links
                var person = await context.Persons
                                         .Where(p => p.PersonId == personId)
                                         .Include(p => p.Interests)
                                         .ThenInclude(i => i.Links)
                                         .FirstOrDefaultAsync();

                if (person == null)
                {
                    return Results.NotFound("Person not found"); //checks if person exists
                }

                var links = person.Interests.SelectMany(i => i.Links).ToList(); //checks for persons links

                if (links.Count == 0)
                {
                    return Results.NotFound("No links connected to person"); //checks if person has any links
                }

                return Results.Ok(links); //returns persons links if they exist
            });

            // Adds new interests to Person by PersonId
            app.MapPut("/persons/{personId}/interests", async (int personId, List<Interest> newInterests, APIDbContext context) =>
            {
                //checks person by personId
                var person = await context.Persons
                                            .Where(p => p.PersonId == personId)
                                            .Include(p => p.Interests)
                                            .FirstOrDefaultAsync();
                if (person == null)
                {
                    return Results.NotFound("Person not found");
                }

                // Adds new interest/interests to list
                person.Interests.AddRange(newInterests);

                // saves to database
                await context.SaveChangesAsync();

                return Results.Ok("Interests added successfully");
            });

            // Add a link to an interest by interestId and personId
            app.MapPut("/persons/{personId}/interests/{interestId}/links", async (int personId, int interestId, List<Link> newLinks, APIDbContext context) =>
            {
                // checks person by personId, include interests and links
                var person = await context.Persons
                                             .Where(p => p.PersonId == personId)
                                             .Include(p => p.Interests)
                                             .ThenInclude(i => i.Links)
                                             .FirstOrDefaultAsync();

                if (person == null)
                {
                    return Results.NotFound("Person not found"); //checks if person exists
                }

                var interest = person.Interests.FirstOrDefault(i => i.InterestId == interestId); // checks correct interest by interestId

                if (interest == null)
                {
                    return Results.NotFound("Interest not found for this person"); //checks if interest exists for this person
                }

                interest.Links.AddRange(newLinks); //adds link to list

                //saves to db
                await context.SaveChangesAsync();

                return Results.Ok("Links updated successfully");
            });

            app.Run();
        }
    }
}
