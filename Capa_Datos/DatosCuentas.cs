using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class DatosCuentas
    {
        private BDPEntities db = new BDPEntities();
        public void InsertarCuentas(cuentas cuentas)
        {
            db.cuentas.Add(cuentas);
            db.SaveChanges();
        }

        public List<cuentas> ListarCuentas()
        {
            return db.cuentas.ToList();
        }

        public void DeletedCuentas(int id)
        {
            cuentas cuentas = db.cuentas.Find(id);
            db.cuentas.Remove(cuentas);
            db.SaveChanges();
        }

        public void EditCuentas(cuentas cuentas)
        {
            db.Entry(cuentas).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
