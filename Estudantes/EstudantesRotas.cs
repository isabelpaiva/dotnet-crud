using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Estudantes;

public static class EstudantesRotas
{
    public static void AddRotasEstudantes(this WebApplication app)
    {

        var rotasEstudantes = app.MapGroup(prefix: "estudantes");

        rotasEstudantes.MapPost(pattern: "", handler: async (AddEstudantesRequest request, AppDbContext context) =>


        {
            var estudanteExiste = await context.Estudantes.AnyAsync(estudante => estudante.Nome == request.Nome);

            if (estudanteExiste)
            {
                return Results.Conflict(error: "Nome já existente");
            }

            var novoEstudante = new Estudante(request.Nome);

            await context.Estudantes.AddAsync(novoEstudante);
            await context.SaveChangesAsync();

            return Results.Ok(novoEstudante);
        });

        rotasEstudantes.MapGet(pattern:"", handler: async  (AppDbContext context)=> {
            var estudantes = await context.Estudantes.Where(estudante => estudante.Ativo).ToListAsync();
            return estudantes;
        });
    }  
}