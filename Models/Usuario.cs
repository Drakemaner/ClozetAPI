using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Usuario
    {

        public Usuario() { }

        public Usuario(string nomeCompleto, string nomeUsuario, string email, string senha)
        {
            NomeCompleto = nomeCompleto;
            NomeUsuario =  nomeUsuario;
            Email = email;
            Senha = senha;
        }

        public int Id { get; set; }

        public string NomeCompleto { get; set; }
                      
        public string NomeUsuario { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public virtual ICollection<Roupa>? Roupas { get; set; } = new List<Roupa>();   
    }
}
