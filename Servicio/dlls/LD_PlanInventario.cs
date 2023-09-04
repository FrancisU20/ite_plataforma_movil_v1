using EasySoft.Excepciones;
using EasySoft.LogicaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Servicio.dlls
{
    public class LD_PlanInventario : ADGenerico
    {
        public LD_PlanInventario(String App, String BDD)
            : base(App, BDD)
        {
        }

        public Object ObtenerIdPlan(string oficina)
        {
            try
            {
                String sql = "select isnull(max(id_plan),0) + 1 as id_plan from plan_inventario (nolock) WHERE oficina='" + oficina + "'";
                ComandoSelect = CrearComando(sql, CommandType.Text);
                return EjecutarEscalar(ComandoSelect);
            }
            catch { return null; }
        }
        public DataTable ObtenerPlanInventario(String TOP, String where)
        {
            String sql = "select TOP " + TOP + " * from plan_inventario (nolock) ";
            DataTable dt = new DataTable("plan_inventario");
            if (!where.Equals(""))
                sql += " where " + where;
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public DataTable ObtenerPlanArticulos(String TOP, String where)
        {
            String sql = "select TOP " + TOP + " * from PLAN_ARTICULOS (nolock) ";
            DataTable dt = new DataTable("PLAN_ARTICULOS");
            if (!where.Equals(""))
                sql += " where " + where;
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public DataTable ObtenerPlanOficinas(String TOP, String where)
        {
            String sql = "select TOP " + TOP + " * from PLAN_OFICINAS (nolock) ";
            DataTable dt = new DataTable("PLAN_OFICINAS");
            if (!where.Equals(""))
                sql += " where " + where;
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public DataTable ObtenerCausa(string where)
        {
            DataTable dt = new DataTable("tbl_tipocausa");
            String sql = "SELECT * FROM dbo.tbl_tipocausa with(nolock)";

            if (!where.Equals(""))
                sql += " where " + where;

            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public String GrabarPlanInventario(DataSet dsPlanInventario, DataSet dsKardex)
        {

            IDbTransaction objTran = CrearTransaccion();
            try
            {
                DataTable dtPlan = dsPlanInventario.Tables[0].Copy();
                DataTable dtArticulos = dsPlanInventario.Tables[1].Copy();
                DataTable dtOficinas = dsPlanInventario.Tables[2].Copy();
                DataTable dtTBL_ARTICULOS = dsPlanInventario.Tables[3].Copy();

                if (dtPlan.Rows.Count > 0)
                    Grabar(dtPlan);
                if (dtArticulos.Rows.Count > 0)
                    Grabar(dtArticulos);
                if (dtOficinas.Rows.Count > 0)
                    Grabar(dtOficinas);

                if (dsKardex != null)
                {
                    //realizar el recorrido para grabar
                    Int32 tam = dsKardex.Tables.Count;
                    for (int i = 0; i < tam; i++)
                    {
                        if (dsKardex.Tables[i] != null)
                            Grabar(dsKardex.Tables[i]);
                    }
                }

                //if (dtTBL_ARTICULOS != null)
                //    Grabar(dtTBL_ARTICULOS);

                string codigo = "";
                foreach (DataRow dr in dtTBL_ARTICULOS.Rows)
                    codigo = codigo + "'" + dr["codigo"].ToString().Trim() + "',";
                if (codigo != "")
                    codigo = codigo.Substring(0, codigo.Length - 1);
                else
                    codigo = "''";

                String sql = "UPDATE dbo.tbl_articulos SET RESTRINGIDO_INVENTARIO='N'";
                sql += "where codigo in (" + codigo + ")";
                ComandoUpdate = CrearComando(sql, CommandType.Text);
                EjecutarNoQuery(ComandoUpdate);

                objTran.Commit();
                return "OK";
            }
            catch (Exception ex)
            {
                if (objTran != null)
                    objTran.Rollback();
                throw new EasyExcepcion("Error: ", ex);
                return ex.Message;
            }

        }
        public String ModificarPlanArticulo(DataSet dsPlanArticulo)
        {
            IDbTransaction objTran = CrearTransaccion();
            try
            {
                DataTable dtArticulos = dsPlanArticulo.Tables[0].Copy();
                DataTable dtTBL_ARTICULOS = dsPlanArticulo.Tables[1].Copy();

                if (dtArticulos.Rows.Count > 0)
                    Grabar(dtArticulos);
                if (dtTBL_ARTICULOS.Rows.Count > 0)
                    Grabar(dtTBL_ARTICULOS);
                objTran.Commit();
                return "OK";
            }
            catch (Exception ex)
            {
                if (objTran != null)
                    objTran.Rollback();
                throw new EasyExcepcion("Error: ", ex);
                return ex.Message;
            }

        }
        public DataTable ObtenerImprimirPlan(String ID_PLAN, String OFICINA, String ESTADO)
        {
            String sql = "select p.ID_PLAN,p.NOMBRE,p.FECHA_INICIO,p.FECHA_FIN,  " +
                         "p.SOLICITANTE, p.ESTADO, p.NOCONTEO,p.USUARIO as USUARIO_CREACION, p.USUARIO_MODIFICA, " +
                         "p.FECHA_CREACION, p.FECHA_MODIFICA, pa.COD_ARTICULO, art.DESCRIPCION as  NOMBRE_ARTICULO, " +
                         "cla.clase as COD_CLASE, cla.descripcion as NOMBRE_CLASE,lin.linea as COD_LINEA,  " +
                         "lin.descripcion as NOMBRE_LINEA,o.sucursal, " +
                         "o.oficina, o.nombre as NOMBRE_OFICINA " +
                         "from dbo.PLAN_INVENTARIO p (nolock) " +
                         "inner join dbo.PLAN_OFICINAS po (nolock) on " +
                         "p.id_plan = po.id_plan AND p.oficina=po.oficina_creacion " +
                         "inner join oficina o (nolock) on " +
                         "po.sucursal = o.sucursal " +
                         "and po.oficina = o.oficina " +
                         "inner join dbo.PLAN_ARTICULOS pa (nolock) on " +
                         "p.id_plan = pa.id_plan AND p.oficina=pa.oficina " +
                         "inner join tbl_articulos art (nolock) on " +
                         "pa.cod_articulo = art.codigo " +
                         "inner join tbl_clases cla (nolock) on " +
                         "art.clase = cla.clase " +
                         "and art.clase = pa.clase " +
                         "inner join tbl_lineas lin (nolock) on " +
                         "cla.clase = lin.clase " +
                         "and pa.clase = lin.clase " +
                         "and pa.linea = lin.linea " +
                         "where p.id_plan = " + ID_PLAN + " and p.oficina = '" + OFICINA + "' " +
                         "and pa.estado = '" + ESTADO + "'";
            DataTable dt = new DataTable("DTPLANINVENTARIO");
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dt);
            return dt;


        }
        public DataTable ObtenerPlanDescuentoCabecera(String TOP, String Where)
        {
            String sql = "select " + TOP + " * from PLAN_DESCUENTOCAB (nolock) ";
            if (!Where.Equals(""))
                sql += "WHERE " + Where;
            DataTable dt = new DataTable("PLAN_DESCUENTOCAB");
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public DataTable ObtenerPlanDescuentoDetalle(String TOP, String Where)
        {
            String sql = "select " + TOP + " * from PLAN_DESCUENTODET (nolock) ";
            if (!Where.Equals(""))
                sql += "WHERE " + Where;
            DataTable dt = new DataTable("PLAN_DESCUENTODET");
            ComandoSelect = CrearComando(sql, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public DataTable ObtenerValorDescuento(String TOP, String Where)
        {
            string SQL = "select pa.*,ar.DESCRIPCION,cla.DESCRIPCION as NOMBRECLASE,lin.DESCRIPCION as NOMBRELINEA, " +
                        //"(pa.diferencia * ar.PPP)/valor_POS as VALORDIFERENCIA,p.DESCONTABLE " +
                        "pa.VALORDIFERENCIA,p.DESCONTABLE " +
                        "from dbo.PLAN_ARTICULOS pa with(nolock) " +
                        "inner join tbl_articulos ar (nolock) on " +
                        "pa.cod_articulo = ar.codigo " +
                        "inner join tbl_clases cla with(nolock) on " +
                        "ar.clase = cla.clase " +
                        "inner join tbl_lineas lin with(nolock) on " +
                        "ar.linea = lin.linea " +
                        "and ar.clase = lin.clase " +
                        "INNER JOIN dbo.PLAN_INVENTARIO  p " +
                        "ON pa.ID_PLAN=p.ID_PLAN AND pa.oficina=p.oficina AND pa.ORIGEN=p.ORIGEN ";
            if (!Where.Equals(""))
                SQL += "WHERE " + Where;
            DataTable dt = new DataTable("tbl_detalledsc");
            ComandoSelect = CrearComando(SQL, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public DataTable ObtenerPlanificacionesXDia(string oficina)
        {
            DataTable dt = new DataTable("PLAN_FACTURACION");
            string SQL = "SELECT * FROM dbo.PLAN_FACTURACION WITH (NOLOCK) " +
                         " WHERE estado='CREADO' and oficina='" + oficina + "' AND " +
                         " convert(varchar,FECHA_INICIO,111) <= convert(varchar,GETDATE(),111) AND " +
                         " convert(varchar,FECHA_FIN,111) >= convert(varchar,GETDATE(),111)";
            ComandoSelect = CrearComando(SQL, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public DataTable ObtenerPlanFacturacion(string oficina, string id_plan)
        {
            DataTable dt = new DataTable("PLAN_FACTURACION");
            string SQL = "SELECT * FROM dbo.PLAN_FACTURACION WITH (NOLOCK) " +
                         " WHERE estado='CREADO' and oficina='" + oficina.Trim() + "' AND id_plan=" + id_plan.Trim();
            ComandoSelect = CrearComando(SQL, CommandType.Text);
            Recuperar(dt);
            return dt;
        }
        public String GuardarPlanDescuentos(DataSet dsPlanDesctos)
        {
            IDbTransaction objT = CrearTransaccion();
            try
            {
                DataTable PlanDscCab = dsPlanDesctos.Tables[0].Copy();
                DataTable PlanDscDet = dsPlanDesctos.Tables[1].Copy();
                DataTable dtPlanInventario = dsPlanDesctos.Tables[2].Copy();

                if (PlanDscCab.Rows.Count > 0)
                    Grabar(PlanDscCab);
                if (PlanDscDet.Rows.Count > 0)
                    Grabar(PlanDscDet);
                if (dtPlanInventario.Rows.Count > 0)
                    Grabar(dtPlanInventario);
                objT.Commit();
                return "OK";
            }
            catch (Exception ex)
            {
                if (objT != null)
                    objT.Rollback();
                throw new EasyExcepcion("Error: ", ex);
                //return ex.Message;
            }
        }
    }
}
