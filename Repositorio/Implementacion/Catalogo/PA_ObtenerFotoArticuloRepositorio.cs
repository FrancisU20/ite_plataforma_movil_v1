using Contexto.EasyGestionEmpresarial;
using Entidades.Catalogo;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.Catalogo;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio.Implementacion.Catalogo
{
    public class PA_ObtenerFotoArticuloRepositorio : Repositorio<PA_ObtenerFotoArticulo>, IPA_ObtenerFotoArticuloRepositorio
    {
        public PA_ObtenerFotoArticuloRepositorio(CatalogoContextoMatriz contexto)
            : base(contexto)
        {
        }
        public void Inicializar()
        {
            this.Context = new CatalogoContextoMatriz();
        }

    }
}
