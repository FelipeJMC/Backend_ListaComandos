using ListaComandos.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaComandos.DAL
{
    public class UsuarioDAL
    {
        public IEnumerable<TbUsuario> ListarTodo()
        {
            var _db = new ComandosContext();
            return _db.TbUsuarios.ToList();
        }
        public TbUsuario Login(string usuario, string password)
        {
            var _db = new ComandosContext();
            return _db.TbUsuarios
                      .Where(x => x.Usuario == usuario && x.Password == password)
                      .FirstOrDefault();
        }




    }
}
