using Configuracion.Models;
using Entidades.EasyGestionEmpresarial;
using Repositorio.Interfaz.bdgeneral;
using Repositorio.Interfaz.EasyGestionEmpresarial;
using Servicio.Interfaz;
using Servicio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace Servicio.Implementacion
{
    public class ServicioInverntarioTotal : IServicioInverntarioTotal
    {
        IPA_IpServidorRepositorio iPA_IpServidorRepositorio;
        IPV_INVENTARIO_TOTAL_LOGINRepositorio iPV_INVENTARIO_TOTAL_LOGINRepositorio;
        IPV_INVENTARIO_TOTAL_MARGENRepositorio iPV_INVENTARIO_TOTAL_MARGENRepositorio;
        IPV_INVENTARIO_TOTALRepositorio iPV_INVENTARIO_TOTALRepositorio;
        Itbl_articulosRepositorio itbl_ArticulosRepositorio;
        Itbl_articulos_codigosbarraRepositorio itbl_Articulos_CodigosbarraRepositorio;
        IPA_ConsultarArtituloInventarioTotal iPA_ConsultarArtituloInventarioTotal;
        IPV_INVENTARIO_TOTAL_DETALLERepositorio iPV_INVENTARIO_TOTAL_DETALLERepositorio;
        IPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio;
        IPV_INVENTARIO_TOTAL_BARRASRepositorio iPV_INVENTARIO_TOTAL_BARRASRepositorio;
        IOFICINARepositorio iOFICINARepositorio;
        IOFICINA_IPServerRepositorio iOFICINA_IPServerRepositorio;

        public ServicioInverntarioTotal(IPA_IpServidorRepositorio iPA_IpServidorRepositorio,
            IPV_INVENTARIO_TOTAL_LOGINRepositorio pV_INVENTARIO_TOTAL_LOGINRepositorio,
            IPV_INVENTARIO_TOTAL_MARGENRepositorio ipV_INVENTARIO_TOTAL_MARGENRepositorio,
            IPV_INVENTARIO_TOTALRepositorio iPV_INVENTARIO_TOTALRepositorio,
            Itbl_articulos_codigosbarraRepositorio itbl_Articulos_CodigosbarraRepositorio,
            Itbl_articulosRepositorio itbl_ArticulosRepositorio,
            IPA_ConsultarArtituloInventarioTotal iPA_ConsultarArtituloInventarioTotal,
            IPV_INVENTARIO_TOTAL_DETALLERepositorio iPV_INVENTARIO_TOTAL_DETALLERepositorio,
            IPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio,
            IPV_INVENTARIO_TOTAL_BARRASRepositorio iPV_INVENTARIO_TOTAL_BARRASRepositorio,
            IOFICINA_IPRepositorio iOFICINA_IPRepositorio,
            IOFICINARepositorio iOFICINARepositorio,
            IOFICINA_IPServerRepositorio iOFICINA_IPServerRepositorio
            )
        {
            this.iPA_IpServidorRepositorio = iPA_IpServidorRepositorio;
            iPV_INVENTARIO_TOTAL_LOGINRepositorio = pV_INVENTARIO_TOTAL_LOGINRepositorio;
            iPV_INVENTARIO_TOTAL_MARGENRepositorio = ipV_INVENTARIO_TOTAL_MARGENRepositorio;
            this.iPV_INVENTARIO_TOTALRepositorio = iPV_INVENTARIO_TOTALRepositorio;
            this.itbl_ArticulosRepositorio = itbl_ArticulosRepositorio;
            this.itbl_Articulos_CodigosbarraRepositorio = itbl_Articulos_CodigosbarraRepositorio;
            this.iPA_ConsultarArtituloInventarioTotal = iPA_ConsultarArtituloInventarioTotal;
            this.iPV_INVENTARIO_TOTAL_DETALLERepositorio = iPV_INVENTARIO_TOTAL_DETALLERepositorio;
            this.iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio = iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio;
            this.iPV_INVENTARIO_TOTAL_BARRASRepositorio = iPV_INVENTARIO_TOTAL_BARRASRepositorio;
            this.iOFICINA_IPServerRepositorio = iOFICINA_IPServerRepositorio;
            this.iOFICINARepositorio = iOFICINARepositorio;
        }

        public void Inicializar()
        {
            iPA_IpServidorRepositorio.Inicializar();
            iPV_INVENTARIO_TOTAL_LOGINRepositorio.Inicializar();
            iPV_INVENTARIO_TOTAL_MARGENRepositorio.Inicializar();
            iPV_INVENTARIO_TOTALRepositorio.Inicializar();
            iPA_ConsultarArtituloInventarioTotal.Inicializar();
            iPV_INVENTARIO_TOTAL_DETALLERepositorio.Inicializar();
            iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio.Inicializar();
            iPV_INVENTARIO_TOTAL_BARRASRepositorio.Inicializar();
            iOFICINA_IPServerRepositorio.Inicializar();
            iOFICINARepositorio.Inicializar();
        }

        public Result Ingreso(string ipServidor, string ipCliente, string nombreCorto)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = ""
            };

            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            var result = ip.Match(ipCliente);
            if (!result.Success)
            {
                resultado.mensaje = "La ip Cliente no es válida. [ " + ipCliente + " ] ";
                return resultado;
            }

            var result2 = ip.Match(ipCliente);
            if (!result2.Success)
            {
                resultado.mensaje = "La ip Servidor no es válida. [ " + ipServidor + " ] ";
                return resultado;
            }

            var objs = new Dictionary<string, string>();

            List<PV_IpServidor> paIpServidor = iPA_IpServidorRepositorio.All().ToList();

            if (paIpServidor != null)
            {
                if (!ipServidor.Equals(paIpServidor.ElementAt(0).ipservidor))
                {
                    resultado.mensaje += "[Dirección ip no válida]";
                    return resultado;
                }
                else
                {
                    var inventarioLogin = iPV_INVENTARIO_TOTAL_LOGINRepositorio.Find(x => x.usuario.ToUpper().Equals(nombreCorto.ToUpper()));
                    if (inventarioLogin != null)
                    {
                        if (inventarioLogin.estado.Equals("ACTIVO"))
                        {
                            if (inventarioLogin.login.Equals("N") || (inventarioLogin.login.Equals("S") && inventarioLogin.ip.Equals(ipCliente)))
                            {

                                inventarioLogin.login = "S";
                                inventarioLogin.ip = ipCliente;

                                bool resp = GuardarBloqueo(inventarioLogin);
                                if (resp)
                                {
                                    int margen = 500;
                                    var dtmargen = iPV_INVENTARIO_TOTAL_MARGENRepositorio.Filter(x => x.tipo.Equals("MARGEN")).ToList();
                                    try
                                    {
                                        margen = Convert.ToInt16(dtmargen.ElementAt(0));
                                    }
                                    catch
                                    {
                                        margen = 500;
                                    }
                                    resultado.mensaje = "OK";
                                    resultado.respuesta = "OK";
                                    return resultado;
                                }
                                else
                                {
                                    resultado.mensaje += "[Error al guardar el bloqueo de usuario]";
                                    return resultado;
                                }

                            }
                            else
                            {
                                resultado.mensaje += "[El usuario " + nombreCorto.ToUpper() + " se encuentra registrado en la IP " + inventarioLogin.ip + "]";
                                return resultado;
                            }

                        }
                        else
                        {
                            resultado.mensaje += "[El usuario se encuentra inactivo.]";
                            return resultado;
                        }
                    }
                    else
                    {
                        resultado.mensaje += "No existe este usuario creado.";
                        return resultado;
                    }
                }
            }
            else
            {
                resultado.mensaje += "[No se pudo recuperar la ip de servidor pmov.pa_IpServidor]";
                return resultado;
            }
        }

        private bool GuardarBloqueo(PV_INVENTARIO_TOTAL_LOGIN login)
        {
            try
            {
                iPV_INVENTARIO_TOTAL_LOGINRepositorio.Update(login);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Result Inventario(string ipServidor, string nombreCorto)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al iniciar sesión. "
            };

            PV_INVENTARIO_TOTAL_MARGEN pV_INVENTARIO_TOTAL_MARGEN = iPV_INVENTARIO_TOTAL_MARGENRepositorio.Find(x => x.tipo.Equals("MARGEN"));

            int margen = 500;
            try
            {
                margen = Convert.ToInt16(pV_INVENTARIO_TOTAL_MARGEN.margen);
            }
            catch
            {
                margen = 500;
            }

            List<string> estados = new List<string> { "INICIADO", "RECONTEO" };
            var inventariosTotales = iPV_INVENTARIO_TOTALRepositorio.Filter(x => x.estado.Equals("INICIADO") || x.estado.Equals("RECONTEO")).ToList();

            if (inventariosTotales != null)
            {
                if (inventariosTotales.Count() > 0)
                {
                    InventarioTotalModel inventarioTotalModel = new InventarioTotalModel
                    {
                        CabeceraOCVisible = true,
                        CabeceraVisible = false,
                        CodigoInventario = inventariosTotales.ElementAt(0).cod_inventario,
                        Descripcion = inventariosTotales.ElementAt(0).descripcion.ToUpper(),
                        Sucursal = inventariosTotales.ElementAt(0).sucursal,
                        Oficina = inventariosTotales.ElementAt(0).oficina,
                        IdBodega = inventariosTotales.ElementAt(0).idbodega,
                        Tipo = inventariosTotales.ElementAt(0).tipo.ToUpper().Replace("\n", ""),
                        Estado = inventariosTotales.ElementAt(0).estado.ToUpper(),
                        LabelTotal = inventariosTotales.ElementAt(0).Total,
                        NumeroConteo = inventariosTotales.ElementAt(0).conteo,
                        Fecha = inventariosTotales.ElementAt(0).fecha.ToString("yyyy-MM-dd"),
                        Usuario = inventariosTotales.ElementAt(0).usuario.ToUpper(),
                        Margen = margen
                    };

                    resultado.respuesta = "OK";
                    resultado.mensaje = inventarioTotalModel;
                    return resultado;
                }
                else
                    resultado.mensaje = "No existen inventarios pendientes por realizar.";
            }
            else
                resultado.mensaje = "Error al sacar Datos de la Base de Datos";

            return resultado;
        }

        public Result CargaInicialArticulos()
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al iniciar sesión. "
            };

            var articulos = itbl_ArticulosRepositorio.All().Select(x => new { x.codigo, x.descripcion }).ToList();
            List<ArticuloInventarioTotal> articulosModel = new List<ArticuloInventarioTotal>();
            var codigosArt = articulos.Select(x => x.codigo).Distinct().ToList();
            var codigosBarra = itbl_Articulos_CodigosbarraRepositorio.Filter(x => x.es_principal.Equals("S")).Select(x => new { x.codigo, x.codigo_barra, x.es_principal }).Distinct().ToList();

            foreach (var item in articulos)
            {
                var cb = codigosBarra.FirstOrDefault(x => x.codigo.Equals(item.codigo));
                if (cb != null)
                {
                    ArticuloInventarioTotal tmp = new ArticuloInventarioTotal
                    {
                        Codigo = item.codigo,
                        CodigoBarra = cb.codigo_barra,
                        Descripcion = item.descripcion.ToUpper()
                    };
                    articulosModel.Add(tmp);
                }
            }

            resultado.respuesta = "OK";
            resultado.mensaje = articulosModel;

            return resultado;
        }

        public Result BuscarArticuloInventario(string codigo, string codigoBarras, string descripcion, int conteo, int inventario, string usuario)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al iniciar sesión. "
            };

            try
            {
                codigoBarras = codigoBarras.Replace(" ","").Replace("\n", "");
                //codigo = codigo.Replace(" ", "");
                //codigo = codigo.Replace(@"\n", "");
                usuario = usuario.ToUpper();

                string sql = "EXEC pmov.PA_ConsultarArtituloInventarioTotal ";
                var obj = new Dictionary<string, string>();
                List<PA_ConsultarArtituloInventarioTotal> dtbusq = null;
                bool flagBarra = false;
                if (conteo >= 1)
                {
                    if (!string.IsNullOrEmpty(codigo))
                        sql += conteo + ", '" + codigo + "','',''";
                    else if (!string.IsNullOrEmpty(codigoBarras))
                    {
                        flagBarra = true;
                        sql += conteo + ", '','" + codigoBarras + "',''";
                    }

                    else if (!string.IsNullOrEmpty(descripcion))
                        sql += conteo + ", '','','" + descripcion + "'";

                    if (string.IsNullOrEmpty(codigo) && string.IsNullOrEmpty(codigoBarras) && string.IsNullOrEmpty(descripcion))
                    {
                        //sql += conteo + ", '','',''";
                        resultado.respuesta = "OK";
                        resultado.mensaje = new List<PA_ConsultarArtituloInventarioTotal>();
                        return resultado;
                    }

                    if (!string.IsNullOrEmpty(usuario))
                        sql += ",'" + usuario + "'";
                    else
                        sql += ",''";

                    if (inventario != 0)
                        sql += "," + inventario;
                    else
                        sql += ",0";



                    dtbusq = iPA_ConsultarArtituloInventarioTotal.SqlQuery(sql, obj, 0).ToList();

                    // SI ES MAYOR QUE UNO SE DEBE PODER SELECCIONAR EL ARTÍCULO
                    if (dtbusq != null && dtbusq.Count() > 1)
                    {
                        List<StockArticuloInventario> stockArticuloInventarios = new List<StockArticuloInventario>();

                        foreach (var item in dtbusq)
                        {
                            StockArticuloInventario stockArticuloInventario = new StockArticuloInventario
                            {
                                Barra = item.codigo_barra,
                                Codigo = item.codigo,
                                Descripcion = item.descripcion.ToUpper(),
                                ValorPOS = item.valor_POS.ToString(),
                                Existencias = item.existencias.ToString(),
                                Laboratorio = item.laboratorio.ToUpper(),
                                Entero = "0",
                                Fraccion = "0"
                            };
                            stockArticuloInventarios.Add(stockArticuloInventario);
                        }

                        resultado.respuesta = "OK";
                        resultado.mensaje = stockArticuloInventarios;
                        return resultado;
                    }

                    if (dtbusq != null && dtbusq.Count() == 1)
                    {
                        string codigoArticulo = dtbusq.ElementAt(0).codigo;
                        var inventarioDetalle = iPV_INVENTARIO_TOTAL_DETALLERepositorio.Filter(x =>
                        x.codigo.Equals(codigoArticulo) &&
                        x.cod_inventario == inventario).ToList();

                        if (inventarioDetalle != null && inventarioDetalle.Count() > 0)
                        {
                            var detalleItem = inventarioDetalle.ElementAt(0);
                            List<StockArticuloInventario> stockArticuloInventarios = new List<StockArticuloInventario>();
                            StockArticuloInventario stockArticuloInventario = new StockArticuloInventario();

                            if (detalleItem.estado.ToString().Equals("INICIADO") || detalleItem.estado.ToString().Equals("RECONTEO"))
                            {
                                PV_INVENTARIO_TOTAL_DETALLE_USUARIO dtart = iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio.Find(x => x.codigo.Equals(detalleItem.codigo) && x.cod_inventario == inventario && x.digitado == conteo && x.usuario.ToUpper().Equals(usuario));

                                if (dtart != null)
                                {
                                    stockArticuloInventario.Entero = (Convert.ToInt64(dtart.cantidad_grabada) / Convert.ToInt64(dtbusq.ElementAt(0).valor_POS)).ToString();
                                    stockArticuloInventario.Fraccion = (Convert.ToInt64(dtart.cantidad_grabada) - Convert.ToInt64(stockArticuloInventario.Entero) * Convert.ToInt64(dtbusq.ElementAt(0).valor_POS)).ToString();
                                    stockArticuloInventario.EsContado = dtart.contado;
                                }
                                else
                                {
                                    stockArticuloInventario.Entero = "0";
                                    stockArticuloInventario.Fraccion = "0";
                                    stockArticuloInventario.EsContado = "N";
                                }

                                stockArticuloInventario.Existencias = detalleItem.existencias.ToString();
                                stockArticuloInventario.Barra = dtbusq.ElementAt(0).codigo_barra;
                                stockArticuloInventario.Codigo = dtbusq.ElementAt(0).codigo;
                                stockArticuloInventario.ValorPOS = dtbusq.ElementAt(0).valor_POS.ToString();

                                stockArticuloInventario.Stock = (Convert.ToInt64(dtbusq.ElementAt(0).existencias) / Convert.ToInt16(dtbusq.ElementAt(0).valor_POS)).ToString();
                                stockArticuloInventario.Unidades = (Convert.ToInt64(dtbusq.ElementAt(0).existencias) - (Convert.ToInt16(stockArticuloInventario.Stock) * Convert.ToInt16(dtbusq.ElementAt(0).valor_POS))) + "";

                                if (conteo <= 1)
                                {
                                    stockArticuloInventario.Stock = "-";
                                    stockArticuloInventario.Unidades = "-";
                                }

                                stockArticuloInventario.Descripcion = dtbusq.ElementAt(0).descripcion;
                                stockArticuloInventario.Laboratorio = dtbusq.ElementAt(0).laboratorio;

                                stockArticuloInventarios.Add(stockArticuloInventario);

                                if (conteo > 1)
                                {
                                    // CONSULTA HISTORIALES

                                    var detallesConteo = iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio.Filter(x => x.cod_inventario == inventario && x.codigo.Equals(stockArticuloInventario.Codigo)).ToList();
                                    detallesConteo = detallesConteo.OrderBy(x => x.fecha_ingreso).ToList();
                                    if (detallesConteo.Count > 1)
                                    {
                                        long maxConteo = detallesConteo.Select(x => x.digitado).Max();
                                        if (maxConteo > 1)
                                        {
                                            maxConteo = maxConteo - 1;
                                            detallesConteo.RemoveAt(detallesConteo.Count - 1);


                                            List<HistorialConteo> historialConteos = new List<HistorialConteo>();
                                            foreach (var h in detallesConteo)
                                            {
                                                if (h.digitado != maxConteo + 1)
                                                {
                                                    HistorialConteo historial = new HistorialConteo
                                                    {
                                                        Usuario = h.usuario.ToUpper() + " - " + h.digitado,
                                                        Cantidad = h.cantidad_grabada.ToString()
                                                    };
                                                    historialConteos.Add(historial);
                                                }
                                            }
                                            stockArticuloInventarios.ElementAt(0).Historiales = historialConteos;
                                        }
                                    }
                                }

                                resultado.respuesta = "OK";
                                resultado.mensaje = stockArticuloInventarios;
                                return resultado;
                            }
                            else
                            {
                                resultado.respuesta = "ERROR";
                                if (detalleItem.estado.Equals("PROCESO"))
                                    resultado.mensaje = "Cierre la aplicación y vuelva abrir, el inventario actual se encuentra en estado PROCESO";
                                else
                                    resultado.mensaje = "El artículo " + dtbusq.ElementAt(0).descripcion + " se encuentra en estado: " + detalleItem.estado;

                                return resultado;
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(codigo) || !string.IsNullOrEmpty(codigoBarras))
                            {
                                var itotal = iPV_INVENTARIO_TOTALRepositorio.Find(x => x.cod_inventario == inventario);
                                if (itotal != null)
                                {
                                    if (itotal.Total.Equals("S"))
                                    {
                                        tbl_articulos articulo = null;
                                        if (!string.IsNullOrEmpty(codigo))
                                            articulo = itbl_ArticulosRepositorio.Find(x => x.codigo.Equals(codigo));
                                        else
                                        {
                                            tbl_articulos_codigosbarra barra = itbl_Articulos_CodigosbarraRepositorio.Find(x => x.codigo_barra.Equals(codigoBarras));
                                            articulo = itbl_ArticulosRepositorio.Find(x => x.codigo.Equals(barra.codigo));
                                        }

                                        if (articulo != null)
                                        {
                                            PV_INVENTARIO_TOTAL_DETALLE detalle = new PV_INVENTARIO_TOTAL_DETALLE
                                            {
                                                codigo = articulo.codigo,
                                                cod_inventario = inventario,
                                                idbodega = itotal.idbodega,
                                                oficina = itotal.oficina,
                                                sucursal = itotal.sucursal,
                                                estado = "INICIADO",
                                                proceso = "NOPROCESADO",
                                                psicotropico = articulo.es_psicotropico == null ? "N" : articulo.es_psicotropico,
                                                existencias = 0,
                                                ventas = 0,
                                                devoluciones = 0,
                                                digitado = 0,
                                                diferencia = 0,
                                                valor_diferencia = 0
                                            };
                                            iPV_INVENTARIO_TOTAL_DETALLERepositorio.Create(detalle);

                                            resultado.respuesta = "OK";
                                            resultado.mensaje = "El artículo " + articulo.descripcion.ToUpper() + " se adjuntó al conteo de Inventario";
                                            return resultado;
                                        }else
                                        {
                                            if (!string.IsNullOrEmpty(codigoBarras))
                                            {
                                                // REGISTRO DE BARRA DESCONOCIDA
                                                try
                                                {
                                                    var inventariosTotales = iPV_INVENTARIO_TOTALRepositorio.Filter(x => x.estado.Equals("INICIADO") || x.estado.Equals("RECONTEO")).ToList();
                                                    var existe = iPV_INVENTARIO_TOTAL_BARRASRepositorio.Find(x => x.cod_inventario == inventario && x.codigo_barra.Equals(codigoBarras));
                                                    if (existe == null)
                                                        if (inventariosTotales.Count > 1)
                                                        {
                                                            PV_INVENTARIO_TOTAL_BARRAS pvBarra = new PV_INVENTARIO_TOTAL_BARRAS
                                                            {
                                                                codigo_barra = codigoBarras,
                                                                cod_inventario = inventario,
                                                                idbodega = inventariosTotales.ElementAt(0).idbodega,
                                                                oficina = inventariosTotales.ElementAt(0).oficina,
                                                                sucursal = inventariosTotales.ElementAt(0).sucursal
                                                            };
                                                            iPV_INVENTARIO_TOTAL_BARRASRepositorio.Create(pvBarra);
                                                        }
                                                }
                                                catch (Exception ex)
                                                {

                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            resultado.respuesta = "error";
                            resultado.mensaje = "El artículo [" + dtbusq.ElementAt(0).descripcion.ToUpper() + "] no pertenece al conteo de inventario.";
                            return resultado;

                        }
                    }
                    else
                    {
                        // REGISTRO DE BARRA DESCONOCIDA
                        try
                        {
                            var inventariosTotales = iPV_INVENTARIO_TOTALRepositorio.Filter(x => x.estado.Equals("INICIADO") || x.estado.Equals("RECONTEO")).ToList();
                            var existe = iPV_INVENTARIO_TOTAL_BARRASRepositorio.Find(x => x.cod_inventario == inventario && x.codigo_barra.Equals(codigoBarras));
                            if (existe == null)
                                if (inventariosTotales.Count >= 1)
                                {
                                    PV_INVENTARIO_TOTAL_BARRAS pvBarra = new PV_INVENTARIO_TOTAL_BARRAS
                                    {
                                        codigo_barra = codigoBarras,
                                        cod_inventario = inventario,
                                        idbodega = inventariosTotales.ElementAt(0).idbodega,
                                        oficina = inventariosTotales.ElementAt(0).oficina,
                                        sucursal = inventariosTotales.ElementAt(0).sucursal
                                    };
                                    iPV_INVENTARIO_TOTAL_BARRASRepositorio.Create(pvBarra);
                                }
                        }
                        catch (Exception ex)
                        {

                        }

                        resultado.respuesta = "error";
                        resultado.mensaje = "No existe esta información a buscar en el conteo actual.";
                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.mensaje = ex.Message;
            }

            return resultado;
        }

        public Result RegistroCantidades(string usuario, string ipCliente, int entero, int fraccion, string codigoArticulo, int valorPos, int conteo, int inventario)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al iniciar sesión. "
            };

            try
            {
                int margen = 500;
                PV_INVENTARIO_TOTAL_MARGEN pV_INVENTARIO_TOTAL_MARGEN = iPV_INVENTARIO_TOTAL_MARGENRepositorio.Find(x => x.tipo.Equals("MARGEN"));

                if (pV_INVENTARIO_TOTAL_MARGEN != null && pV_INVENTARIO_TOTAL_MARGEN.margen != 0)
                    margen = pV_INVENTARIO_TOTAL_MARGEN.margen;

                string verificacionUsuario = VerificacionUsuarioLogeado(usuario, ipCliente);
                if (!verificacionUsuario.Equals(""))
                    resultado.mensaje += verificacionUsuario;

                int valorIngresado = (entero * valorPos) + fraccion;


                if (valorIngresado > margen)
                {
                    resultado.mensaje = "La cantidad excede al máximo permitido";
                    return resultado;
                }


                PV_INVENTARIO_TOTAL pV_INVENTARIO_TOTAL = iPV_INVENTARIO_TOTALRepositorio.Find(x => x.cod_inventario == inventario);

                if (pV_INVENTARIO_TOTAL == null)
                {
                    resultado.mensaje = "El invetario no existe.";
                    return resultado;
                }



                if (pV_INVENTARIO_TOTAL.conteo != conteo)
                {
                    resultado.mensaje = "El Conteo de la cabecera no es el mismo con el detalle, Cierre la aplicación y Vuelva a intentar";
                    return resultado;
                }

                if (!pV_INVENTARIO_TOTAL.estado.Equals("INICIADO") && !pV_INVENTARIO_TOTAL.estado.Equals("RECONTEO"))
                {
                    resultado.mensaje = "El estado de la Cabecera es " + pV_INVENTARIO_TOTAL.estado.ToUpper() + ", Cierre la aplicación y Vuelva a intentar";
                    return resultado;
                }

                usuario = usuario.ToUpper();

                PV_INVENTARIO_TOTAL_DETALLE_USUARIO iVdUsuario = iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio.Find(x =>
                x.codigo.Equals(codigoArticulo) &&
                x.digitado == conteo &&
                x.usuario.ToUpper().Equals(usuario) &&
                x.cod_inventario == inventario
                );

                if (iVdUsuario == null)
                {
                    iVdUsuario = new PV_INVENTARIO_TOTAL_DETALLE_USUARIO
                    {
                        cod_inventario = inventario,
                        sucursal = pV_INVENTARIO_TOTAL.sucursal,
                        oficina = pV_INVENTARIO_TOTAL.oficina,
                        idbodega = pV_INVENTARIO_TOTAL.idbodega,
                        codigo = codigoArticulo,
                        usuario = usuario.ToLower(),
                        digitado = conteo,
                        cantidad_grabada = valorIngresado,
                        fecha_modificacion = DateTime.Now,
                        fecha_ingreso = DateTime.Now,
                        contado = "S"
                    };

                    iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio.Create(iVdUsuario);
                }
                else
                {
                    iVdUsuario.cantidad_grabada = valorIngresado;
                    iVdUsuario.fecha_modificacion = DateTime.Now;
                    iVdUsuario.contado = "S";

                    iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio.Update(iVdUsuario);
                }
                resultado.respuesta = "OK";
                resultado.mensaje = "Guardado correctamente.";
                return resultado;
            }
            catch (Exception ex)
            {
                resultado.mensaje += ex.Message.ToUpper();
            }
            return resultado;
        }

        private string VerificacionUsuarioLogeado(string usuario, string ipCliente)
        {
            usuario = usuario.ToUpper();
            PV_INVENTARIO_TOTAL_LOGIN pV_INVENTARIO_TOTAL_LOGIN = iPV_INVENTARIO_TOTAL_LOGINRepositorio.Find(x => x.login.ToUpper().Equals(usuario));

            if (pV_INVENTARIO_TOTAL_LOGIN == null)
                return "Error al sacar información de la base de datos";
            else if (!pV_INVENTARIO_TOTAL_LOGIN.Equals("ACTIVO"))
                return "El usuario " + usuario + " se encuentra INACTIVO";

            //if (dtbusq.Rows[0]["login"].ToString().Equals("N") || (dtbusq.Rows[0]["login"].ToString().Equals("S") && dtbusq.Rows[0]["IP"].ToString().Equals(ipCliente())))

            if (pV_INVENTARIO_TOTAL_LOGIN.login.Equals("N") || (pV_INVENTARIO_TOTAL_LOGIN.login.Equals("S") && pV_INVENTARIO_TOTAL_LOGIN.ip.Equals(ipCliente)))
            {
                pV_INVENTARIO_TOTAL_LOGIN.login = "S";
                pV_INVENTARIO_TOTAL_LOGIN.ip = ipCliente;
                bool guardarBloqueo = GuardarBloqueo(pV_INVENTARIO_TOTAL_LOGIN);

                if (!guardarBloqueo)
                    return "Error al guardar el bloqueo de usuario.";
            }
            else
                return "El usuario " + usuario + " se encuentra registrado en la IP " + pV_INVENTARIO_TOTAL_LOGIN.ip;

            return "";
        }

        public Result CerrarSesion(string usuario, string ip)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al recuperar los datos. "
            };

            usuario = usuario.ToUpper();
            PV_INVENTARIO_TOTAL_LOGIN pV_INVENTARIO_TOTAL_LOGIN = iPV_INVENTARIO_TOTAL_LOGINRepositorio.Find(x => x.usuario.ToUpper().Equals(usuario));


            if (pV_INVENTARIO_TOTAL_LOGIN != null)
            {
                pV_INVENTARIO_TOTAL_LOGIN.login = "N";
                pV_INVENTARIO_TOTAL_LOGIN.ip = ip;
                iPV_INVENTARIO_TOTAL_LOGINRepositorio.Update(pV_INVENTARIO_TOTAL_LOGIN);

                resultado.respuesta = "OK";
                resultado.mensaje = "Sesión finalizada.";
                return resultado;
            }
            else
                resultado.mensaje = "El usuario no está registrado.";

            return resultado;
        }

        public Result CargarSiguiente(string usuario, int conteo, int inventario)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al consultar la información."
            };


            try
            {
                string sql = "EXEC pmov.PA_ConsultarArtituloInventarioTotal ";
                var obj = new Dictionary<string, string>();
                List<PA_ConsultarArtituloInventarioTotal> dtbusq = null;
                if (conteo > 1)
                {
                    sql += conteo + ", '','','','" + usuario + "'," + inventario;

                    dtbusq = iPA_ConsultarArtituloInventarioTotal.SqlQuery(sql, obj, 0).ToList();

                    // SI ES MAYOR QUE UNO SE DEBE PODER SELECCIONAR EL ARTÍCULO
                    if (dtbusq != null && dtbusq.Count() > 0)
                    {
                        StockArticuloInventario stockArticuloInventario = new StockArticuloInventario();
                        PA_ConsultarArtituloInventarioTotal item = dtbusq.ElementAt(0);
                        string usuarioItem = usuario.ToUpper();
                        PV_INVENTARIO_TOTAL_DETALLE_USUARIO dtart = iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio.Find(x => x.codigo.Equals(item.codigo) && x.cod_inventario == inventario && x.digitado == conteo && usuarioItem.Equals(x.usuario.ToUpper()) && x.contado.Equals("N"));
                        if (dtart != null)
                        {
                            stockArticuloInventario.Entero = (Convert.ToInt64(dtart.cantidad_grabada) / Convert.ToInt64(dtbusq.ElementAt(0).valor_POS)).ToString();
                            stockArticuloInventario.Fraccion = (Convert.ToInt64(dtart.cantidad_grabada) - Convert.ToInt64(stockArticuloInventario.Entero) * Convert.ToInt64(dtbusq.ElementAt(0).valor_POS)).ToString();

                            if (dtart.contado.Equals("S"))
                            {
                                resultado.respuesta = "error";
                                var a = new List<PA_ConsultarArtituloInventarioTotal>();
                                resultado.mensaje = a;
                                return resultado;
                            }
                            else
                                stockArticuloInventario.EsContado = dtart.contado;
                        }
                        else
                        {
                            dtart = iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio.Find(x => x.codigo.Equals(item.codigo) && x.cod_inventario == inventario && x.digitado == conteo && usuarioItem.Equals(x.usuario.ToUpper()));
                            if (dtart != null)
                            {
                                resultado.respuesta = "OK";
                                resultado.mensaje = "Se finalizó el conteo de todos los artículos del inventario.";
                                stockArticuloInventario.EsContado = dtart.contado;
                                return resultado;
                            }
                            else
                            {
                                stockArticuloInventario.EsContado = "N";
                                stockArticuloInventario.Entero = "0";
                                stockArticuloInventario.Fraccion = "0";
                            }
                        }

                        stockArticuloInventario.Existencias = dtbusq.ElementAt(0).existencias.ToString();
                        stockArticuloInventario.Barra = dtbusq.ElementAt(0).codigo_barra;
                        stockArticuloInventario.Codigo = dtbusq.ElementAt(0).codigo;
                        stockArticuloInventario.ValorPOS = dtbusq.ElementAt(0).valor_POS.ToString();

                        stockArticuloInventario.Stock = (Convert.ToInt64(dtbusq.ElementAt(0).existencias) / Convert.ToInt64(dtbusq.ElementAt(0).valor_POS)).ToString();
                        stockArticuloInventario.Unidades = (Convert.ToInt64(dtbusq.ElementAt(0).existencias) - (Convert.ToInt64(stockArticuloInventario.Stock) * Convert.ToInt64(dtbusq.ElementAt(0).valor_POS))) + "";

                        if (conteo <= 1)
                        {
                            stockArticuloInventario.Stock = "-";
                            stockArticuloInventario.Unidades = "-";
                        }

                        stockArticuloInventario.Descripcion = dtbusq.ElementAt(0).descripcion;
                        stockArticuloInventario.Laboratorio = dtbusq.ElementAt(0).laboratorio;

                        // CONSULTA HISTORIALES

                        var detallesConteo = iPV_INVENTARIO_TOTAL_DETALLE_USUARIORepositorio.Filter(x => x.cod_inventario == inventario && x.codigo.Equals(item.codigo)).ToList();
                        List<HistorialConteo> historialConteos = new List<HistorialConteo>();
                        if (detallesConteo.Count() > 0)
                        {
                            detallesConteo = detallesConteo.OrderBy(x => x.fecha_ingreso).ToList();
                            long maxConteo = detallesConteo.Select(x => x.digitado).Max();
                            if (maxConteo > 1)
                            {
                                maxConteo = maxConteo - 1;
                                detallesConteo.RemoveAt(detallesConteo.Count - 1);
                                foreach (var h in detallesConteo)
                                {
                                    if (h.digitado != maxConteo + 1)
                                    {
                                        HistorialConteo historial = new HistorialConteo
                                        {
                                            Usuario = h.usuario.ToUpper() + " - " + h.digitado,
                                            Cantidad = h.cantidad_grabada.ToString()
                                        };
                                        historialConteos.Add(historial);
                                    }
                                }

                                stockArticuloInventario.Historiales = historialConteos;
                            }
                        }

                        resultado.respuesta = "OK";
                        resultado.mensaje = stockArticuloInventario;
                        return resultado;
                    }
                    else
                        return resultado;
                }
                else
                {
                    resultado.mensaje = "El conteo de inventario debe ser mayor a " + conteo;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                resultado.mensaje = "Error al procesar. " + ex.Message;
                return resultado;
            }
        }

        public Result RecuperarFarmacia(string ip)
        {
            Result resultado = new Result
            {
                respuesta = "error",
                mensaje = "Error al consultar la información."
            };

            var redSplit = ip.Split('.');
            if (redSplit.Count() != 4)
            {
                resultado.mensaje = "IP no válida.";
                return resultado;
            }
            var todo = iOFICINA_IPServerRepositorio.All().ToList();
            var ipObject = iOFICINA_IPServerRepositorio.Find(x => x.ip_red.Equals(ip));
            if (ipObject != null)
            {
                var oficina = iOFICINARepositorio.Find(x => x.CODIGO_OFICINA.Equals(ipObject.oficina));
                if (oficina != null)
                {
                    FarmaciaModel farmaciaModel = new FarmaciaModel
                    {
                        Farmacia = oficina.NOMBRE.ToUpper(),
                        IP = ip
                    };
                    resultado.respuesta = "OK";
                    resultado.mensaje = farmaciaModel;
                    return resultado;
                }
                else
                {
                    resultado.mensaje = "La oficina no esta registrada para [Código oficina: " + ipObject.oficina + "].";
                    return resultado;
                }
            }
            else
            {
                resultado.mensaje = "IP no válida.";
                return resultado;
            }
        }
    }
}
