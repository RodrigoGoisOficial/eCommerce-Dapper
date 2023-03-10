using eCommerce.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private static List<Usuario> _db = new List<Usuario>()
        {
            new Usuario() { Id=1, Nome="Felipe Rodrigues", Email="felipe.rodrigues@gmail.com" },
            new Usuario() { Id=2, Nome="Marcelo Rui", Email="marcelo.rui@gmail.com" },
            new Usuario() { Id=3, Nome="Pricila Rai", Email="pricila.rai@gmail.com" }
        };

        public List<Usuario> Get()
        {
            return _db;
        }

        public Usuario Get(int id)
        {
            return _db.FirstOrDefault(a => a.Id == id);
        }

        public void Insert(Usuario usuario)
        {
            var ultimoUsuario = _db.LastOrDefault();

            if (ultimoUsuario == null)
            {
                usuario.Id = 1;
            }
            else
            {
                usuario.Id = ultimoUsuario.Id;
                usuario.Id++;
            }

            _db.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            _db.Remove(_db.FirstOrDefault(a => a.Id == usuario.Id));
            _db.Add(usuario);
        }

        public void Delete(int id)
        {
            _db.Remove(_db.FirstOrDefault(a => a.Id == id));
        }

    }
}
