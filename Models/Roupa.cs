using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Models
{
    public class Roupa
    {

        public Roupa() { }  

        public Roupa(string nome, string tipo)
        {
            Nome = nome;
            Tipo = tipo;
        }

        
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Tipo { get; set; }

        public string CaminhoImagem { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
