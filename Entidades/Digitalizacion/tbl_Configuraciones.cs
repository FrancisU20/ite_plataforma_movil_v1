using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Digitalizacion
{
    public partial class tbl_Configuraciones
    {
        public int cfg_codigo { get; set; }
        public int amb_codigo { get; set; }
        public int com_codigo { get; set; }
        public string cfg_ip_server_app { get; set; }
        public string cfg_us_server_app { get; set; }
        public string cfg_pass_server_app { get; set; }
        public Nullable<int> cfg_compresion { get; set; }
        public string cfg_temp_app { get; set; }
        public string cfg_ip_server_img { get; set; }
        public string cfg_us_server_img { get; set; }
        public string cfg_pass_server_img { get; set; }
        public string cfg_destino_img { get; set; }
        public string cfg_estado { get; set; }
        public string cfg_usuario_registro { get; set; }
        public Nullable<System.DateTime> cfg_fecha_registro { get; set; }
        public string cfg_servicio_escaneo { get; set; }
        public string cfg_bdd { get; set; }
        public string cfg_bdd_pass { get; set; }
        public string cfg_bdd_usuario { get; set; }
        public string cfg_bdd_ip { get; set; }
        public string cfg_usuarios_locales { get; set; }
        public string cfg_centro_costo_aplica { get; set; }
        public string cfg_empresa_master { get; set; }
        public string cfg_url_api { get; set; }
        public string cfg_client_id { get; set; }
        public string cfg_client_secret { get; set; }
    }
}
