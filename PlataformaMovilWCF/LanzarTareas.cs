using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;
using System.Threading.Tasks;

namespace PlataformaMovilWCF
{
    public class LanzarTareas
    {
        public Timer _timer { get; set; }

        public Task _PendientesRecepcionTask { get; set; }

        public LanzarTareas()
        {
            LanzarPrimeraVez();
        }

        private void SetTimer()
        {
            _timer = new System.Timers.Timer();
            //_timer.Interval = 10000;
            _timer.Interval = 21600000;

            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        // SECCIÓN PARA REGISTRAR LAS TAREAS 
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {

            //****************************** NOTIFICACIÓN PEDIDOS PENDIENTES **************//
            // 1 TAREA
            if (_PendientesRecepcionTask == null || _PendientesRecepcionTask.IsCompleted)
            {
                Tareas.PendientesRecepcion pendientesRecepcion = new Tareas.PendientesRecepcion();
                _PendientesRecepcionTask = new Task(() => pendientesRecepcion.VerificarPendientes());
                _PendientesRecepcionTask.Start();
            }

        }


        // LANZAR UNA SOLA VEZ


        public void LanzarPrimeraVez()
        {
            //****************************** NOTIFICACIÓN PEDIDOS PENDIENTES **************//
            // 1 TAREA
            if (_PendientesRecepcionTask == null || _PendientesRecepcionTask.IsCompleted)
            {
                Tareas.PendientesRecepcion pendientesRecepcion = new Tareas.PendientesRecepcion();
                _PendientesRecepcionTask = new Task(() => pendientesRecepcion.VerificarPendientes());
                _PendientesRecepcionTask.Start();
            }

            SetTimer();
        }
    }
}