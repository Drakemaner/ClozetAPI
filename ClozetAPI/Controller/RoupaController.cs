using ClozetAPI.Banco;
using Microsoft.AspNetCore.Mvc;
using Models;
using ClozetAPI.DTO;
using System.Diagnostics.Metrics;

namespace ClozetAPI.Controller
{
    public static class RoupaController
    {
        public static void controllerRoupa(this WebApplication app)
        {
            
            app.MapPost("/Roupa", ([FromBody] RoupasRequestDTO roupa, [FromServices] DAL<Roupa> dalRoupa) =>
            {

                if (roupa is null)
                {
                    return Results.NotFound("Nenhuma Roupa Recebidoa");
                }

                var roupas = new Roupa(roupa.nome, roupa.tipo) { UsuarioId = roupa.usuarioID, CaminhoImagem = roupa.caminhoImagem};

                dalRoupa.Set(roupas);
                return Results.NoContent();
            });

            app.MapDelete("/Roupa/{nomeUsuario}/{nome}", (string nomeUsuario, string nome, [FromServices]  DAL<Roupa> dalRoupa, [FromServices]  DAL<Usuario> dalUsuario) =>
            {
                var usuario = dalUsuario.getFor(a => a.NomeUsuario.Equals(nomeUsuario));

                var roupa = dalRoupa.getFor(a => a.Nome.ToUpper().Equals(nome.ToUpper()) && a.UsuarioId == usuario.Id);

                if (roupa is null)
                {
                    return Results.NotFound("Usuário Não Encontrado");
                }

                dalRoupa.Delete(roupa);

                return Results.NoContent();
            });
        }

        private static ICollection<RoupasResponseDTO> GetEntity(IEnumerable<Roupa> roupas)
        {
            var roupasResponse = roupas.Select(a =>
            {
                return new RoupasResponseDTO(a.Nome, a.Tipo, a.CaminhoImagem);
            }).ToList();

            return roupasResponse;
        }

    }

    
}
