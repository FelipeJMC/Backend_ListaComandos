using System;
using System.Collections.Generic;

#nullable disable

namespace ListaComandos.DAL.Entities
{
    public partial class TbUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
