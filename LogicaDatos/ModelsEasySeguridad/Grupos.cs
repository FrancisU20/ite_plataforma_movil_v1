using System;
using System.Collections.Generic;

namespace LogicaDatos.ModelsEasySeguridad
{
    public partial class Grupos
    {
        public Grupos()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public string Grupo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
