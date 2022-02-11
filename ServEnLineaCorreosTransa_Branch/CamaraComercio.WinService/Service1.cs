using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using CamaraComercio.DataAccess.EF;
using OFV = CamaraComercio.DataAccess.EF.OficinaVirtual;

namespace CamaraComercio.WinService
{
    public partial class Service1 : ServiceBase
    {
        public DateTime? UltimaRevision;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.timer1.Start();
        }

        protected override void OnStop()
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!UltimaRevision.HasValue)
                UltimaRevision = DateTime.Now;

            var offset = DateTime.Now - UltimaRevision;
            if (Math.Abs(offset.Value.Hours) >= 24)
            {
                try
                {
                    var rep = new Repository<OFV.Transacciones, OFV.CamaraWebsiteEntities>
                        (new OFV.CamaraWebsiteEntities());

                    //TODO: Poner la cantidad de días en una variable del app.config
                    var transVencidas = rep.DoQuery().Where(d => d.Fecha <= DateTime.Today.AddDays(-29));

                    foreach (var transaccionVencida in transVencidas)
                    {
                        transaccionVencida.EstatusTransId = 15; //TODO: Sacar el ID de una variable en el app.config 
                    }
                    //Se guardan los cambios en la base de datos
                    rep.Save();

                    UltimaRevision = DateTime.Now;
                }

                catch (Exception ex)
                {
                    //TODO: Guardar error en un log
                    var msg = ex.Message;
                }
            }
        }
    }
}
