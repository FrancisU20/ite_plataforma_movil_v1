using Contexto.EasyGestionEmpresarial;
using Contexto.EasySeguridad;
using Entidades.EasyGestionEmpresarial;
using Entidades.EasySeguridad;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using Repositorio.Interfaz.EasySeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.EasySeguridad
{
    public class AtribucionesRepositorio : Repositorio<Atribuciones>, IAtribucionesRepositorio
    {
        public AtribucionesRepositorio(EasySeguridadContextoFarmacia context)
            : base(context)
        {
        }

        public void Inicializar()
        {
            this.Context = new EasySeguridadContextoFarmacia();
        }
    }
}
