using ApiEscolaDanca.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiEscolaDanca.UserClass
{
    public static class UsuariosRotas
    {
        public static void MapearRotasUsuario(this WebApplication app)
        {
            var RotasUsuarios = app.MapGroup("/usuarios");

            //Create
            RotasUsuarios.MapPost("/",
                async (Add_Usuario usuario, AppDbContext context) =>
            {
                //Verificação booleana para verificar se o usuario já existe
                var usuarioExistente = await context.Usuarios_Alunos.AnyAsync(user => user.UserIdFirebase == usuario.UserIdFirebase);

                if(usuarioExistente)
                {
                    return Results.Conflict("Usuário já existe");
                }
                else
                {
                    var novoUsuario = new Usuarios(usuario.UserIdFirebase, usuario.Nome, usuario.CPF, usuario.Email, usuario.Telefone, usuario.DataNascimento);

                    await context.Usuarios_Alunos.AddAsync(novoUsuario);
                    await context.SaveChangesAsync();

                    return Results.Ok(novoUsuario);
                }
            });

            //Read
            RotasUsuarios.MapGet("/{userIdFirebase}", async (string userIdFirebase, AppDbContext context) =>
            {
                var usuario = await context.Usuarios_Alunos
                    .Where(user => user.UserIdFirebase == userIdFirebase)
                    .Select(user => new Read_Usuario(user.Nome, user.Email, user.Telefone, user.CPF, user.DataNascimento))
                    .FirstOrDefaultAsync();

                return usuario is not null
                    ? Results.Ok(usuario)
                    : Results.NotFound("Usuário não encontrado");
            });

            //Update
            RotasUsuarios.MapPut("/{userIdFirebase}", async (string userIdFirebase, Update_Usuario dadosAtualizados,AppDbContext context) =>
            {
                var usuario = await context.Usuarios_Alunos
                    .FirstOrDefaultAsync(u => u.UserIdFirebase == userIdFirebase);

                if (usuario is null)
                    return Results.NotFound("Usuário não encontrado.");
                else
                {
                    usuario.Telefone = dadosAtualizados.Telefone;

                    await context.SaveChangesAsync();

                    return Results.Ok("Usuário atualizado com sucesso.");
                }
            });
        }
    }
}
