using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Servicio.dlls
{
    public class LN_PlanInventario
    {
        LD_PlanInventario ld_planinventario = new LD_PlanInventario("PUNTOVENTA", "CONPVEASY");

        public LN_PlanInventario()
        {
        }
        public Int64 ObtenerIdPlan(string oficina)
        {
            Object obj = ld_planinventario.ObtenerIdPlan(oficina);
            if (obj != null)
                return Convert.ToInt64(obj);
            else
                return -1;
        }
        public DataTable ObtenerPlanInventario(String TOP, String where)
        {
            return ld_planinventario.ObtenerPlanInventario(TOP, where);
        }
        public String GrabarPlanInventario(DataSet dsPlanInventario, DataSet dsKardex)
        {
            return ld_planinventario.GrabarPlanInventario(dsPlanInventario, dsKardex);
        }
        public DataTable ObtenerPlanArticulos(String TOP, String where)
        {
            return ld_planinventario.ObtenerPlanArticulos(TOP, where);
        }
        public DataTable ObtenerPlanOficinas(String TOP, String where)
        {
            return ld_planinventario.ObtenerPlanOficinas(TOP, where);
        }
        public DataTable ObtenerCausa(string where)
        {
            return ld_planinventario.ObtenerCausa(where);
        }
        public String ModificarPlanArticulo(DataSet dsPlanArticulo)
        {
            return ld_planinventario.ModificarPlanArticulo(dsPlanArticulo);
        }
        public DataTable ObtenerImprimirPlan(String ID_PLAN, String OFICINA, String ESTADO)
        {
            return ld_planinventario.ObtenerImprimirPlan(ID_PLAN, OFICINA, ESTADO);
        }
        public DataTable ObtenerPlanDescuentoCabecera(String TOP, String Where)
        {
            return ld_planinventario.ObtenerPlanDescuentoCabecera(TOP, Where);
        }
        public DataTable ObtenerPlanDescuentoDetalle(String TOP, String Where)
        {
            return ld_planinventario.ObtenerPlanDescuentoDetalle(TOP, Where);
        }
        public String GuardarPlanDescuentos(DataSet dsPlanDsctos)
        {
            return ld_planinventario.GuardarPlanDescuentos(dsPlanDsctos);
        }
        public DataTable ObtenerPlanificacionesXDia(string oficina)
        {
            return ld_planinventario.ObtenerPlanificacionesXDia(oficina);
        }
        public DataTable ObtenerPlanFacturacion(string oficina, string id_plan)
        {
            return ld_planinventario.ObtenerPlanFacturacion(oficina, id_plan);
        }
        public DataTable ObtenerValorDescuento(String TOP, String Where)
        {
            return ld_planinventario.ObtenerValorDescuento(TOP, Where);
        }
    }
}
