namespace ClozetAPI.DTO
{
    public record UsuarioResponseDTO(int id, string nomeCompleto, string nomeUsuario, string email, ICollection<RoupasResponseDTO> roupas);
}
