using System.ComponentModel;
using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Estudantes;

public static class EstudantesRotas
{
    public static void AddRotasEstudantes(this WebApplication app)
    {

        var rotasEstudantes = app.MapGroup(prefix: "estudantes");

        rotasEstudantes.MapPost(pattern: "", handler: async (AddEstudantesRequest request, AppDbContext context, CancellationToken ct) =>


        {
            var estudanteExiste = await context.Estudantes.AnyAsync(estudante => estudante.Nome == request.Nome, ct);

            if (estudanteExiste)
            {
                return Results.Conflict(error: "Nome já existente");
            }

            var novoEstudante = new Estudante(request.Nome);

            await context.Estudantes.AddAsync(novoEstudante);
            await context.SaveChangesAsync(ct);

            return Results.Ok(novoEstudante);
        });

        rotasEstudantes.MapGet(pattern: "", handler: async (AppDbContext context, CancellationToken ct) =>
        {
            var estudantes = await context.Estudantes.Where(estudante => estudante.Ativo).ToListAsync();
            return estudantes;
        });

        rotasEstudantes.MapPut(pattern:"{id}:guid", 
        handler: async(Guid id,UpdateEstudanteRequest request, AppDbContext context, CancellationToken ct) => {

            var estudante = await context.Estudantes
            .SingleOrDefaultAsync(estudante => estudante.Id == id);

            if (estudante == null)
            return Results.NotFound();

            estudante.AtualizarNome(request.Nome);

            await context.SaveChangesAsync(ct);
            return Results.Ok(estudante);
        });

        rotasEstudantes.MapDelete(pattern:"{id}:guid", 
        handler: async(Guid id, AppDbContext context, CancellationToken ct) => {

            var estudante = await context.Estudantes.SingleOrDefaultAsync(estudante => estudante.Id == id, ct);

            if (estudante == null)
            return Results.NotFound();

            estudante.Desativar();

            await context.SaveChangesAsync();

            return Results.Ok();
        });
    }
}