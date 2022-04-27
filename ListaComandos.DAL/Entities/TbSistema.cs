using System;
using System.Collections.Generic;

#nullable disable

namespace ListaComandos.DAL.Entities
{
    public partial class TbSistema
    {
        public TbSistema()
        {
            TbComandos = new HashSet<TbComando>();
        }

        public int Id { get; set; }
        public string Sistema { get; set; }

        public virtual ICollection<TbComando> TbComandos { get; set; }
    }
}
