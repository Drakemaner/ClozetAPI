using Microsoft.AspNetCore.Mvc;
using Models;
using ClozetAPI.Banco;
using ClozetAPI.DTO;

namespace ClozetAPI.Controller
{
    public static class UsuarioController
    {

        public static void controllerUsuario(this WebApplication app)
        {
            app.MapGet("/Usuario", ([FromServices] DAL<Usuario> dal) =>
            {
                var usuarios = dal.Get();

                var usuariosResponse = GetEntities(usuarios);

                return Results.Ok(usuariosResponse);
            });

            app.MapGet("/Usuario/{nome}", ([FromServices] DAL<Usuario> dal, string nome) =>
            {
                var usuario = dal.getFor(a => a.NomeUsuario == nome);

                if(usuario is null)
                {
                    return Results.NotFound();
                }

                var responseUser = GetEntity(usuario);

                return Results.Ok(responseUser);
                
            });

            app.MapPost("/Usuario", ([FromBody]  UsuarioRequestDTO usuario, [FromServices] DAL<Usuario> dal) =>
            {

                dal.getFor(a => a.NomeUsuario == usuario.nomeUsuario);

                if (usuario is null)
                {
                    return Results.NotFound("Usuário Vazio");
                }

                var user = new Usuario(usuario.nomeCompleto, usuario.nomeUsuario, usuario.email, usuario.senha);

                dal.Set(user);
                return Results.NoContent();
            });

            app.MapDelete("/Usuario/{nome}", (string nome, [FromServices] DAL<Usuario> dal) =>
            {
                var usuario = dal.getFor(a => a.NomeUsuario.ToUpper().Equals(nome.ToUpper()));

                if (usuario is null)
                {
                    return Results.NotFound("Usuário Não Encontrado");
                }

                dal.Delete(usuario);

                return Results.NoContent();
            });

            app.MapPut("/Usuario/{nome}", ( string nome, [FromServices] DAL<Usuario> dal) =>
            {

                var usuario = dal.getFor(a => a.NomeUsuario == nome);

                if (usuario is null)
                {
                    return Results.NotFound("Usuário Não Encontrado no Bandco de Dados");
                }

                dal.Update(usuario);

                return Results.Ok(usuario);

            });
        }

        private static UsuarioResponseDTO GetEntity(Usuario usuario)
        {
            var roupas = usuario.Roupas.Select(a => new RoupasResponseDTO(a.Nome, a.Tipo, a.CaminhoImagem));
            return new UsuarioResponseDTO(usuario.Id, usuario.NomeCompleto, usuario.NomeUsuario, usuario.Email, roupas.ToList());
        }

        private static ICollection<UsuarioResponseDTO> GetEntities(IEnumerable<Usuario> usuarios)
        {
            var usuariosResponse = usuarios.Select(a => 
                {
                    var roupas = a.Roupas.Select(a => new RoupasResponseDTO(a.Nome, a.Tipo, a.CaminhoImagem));
                    return new UsuarioResponseDTO(a.Id, a.NomeCompleto, a.NomeUsuario, a.Email, roupas.ToList());
                }).ToList();

            return usuariosResponse;    
        }
    }
}
