using System;
using System.Collections.Generic;

#nullable disable

namespace ListaComandos.DAL.Entities
{
    public partial class TbComando
    {
        public int Id { get; set; }
        public int IdSistema { get; set; }
        public string Comando { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual TbSistema IdSistemaNavigation { get; set; }
    }
}
