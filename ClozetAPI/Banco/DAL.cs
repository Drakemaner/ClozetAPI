using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace ClozetAPI.Banco
{
    public class DAL<T> where T : class
    {
        private readonly BancoContext bancoContext;

        public DAL(BancoContext bancoContext)
        {
            this.bancoContext = bancoContext;
        }

        public ICollection<T> Get()
        {
            return bancoContext.Set<T>().ToList();
        }

        public void Set(T valor)
        {
            bancoContext.Set<T>().Add(valor);
            bancoContext.SaveChanges();
        }

        public T? getFor(Func<T, Boolean> condition)
        {
            return bancoContext.Set<T>().FirstOrDefault(condition);
        }

        public void Delete(T valor)
        {
            bancoContext.Set<T>().Remove(valor);
            bancoContext.SaveChanges();
        }

        public void Update(T valor)
        {
            bancoContext.Set<T>().Update(valor);
            bancoContext.SaveChanges();
        }
    }
}
