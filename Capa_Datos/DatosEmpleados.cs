using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class DatosEmpleados
    {
        private BDPEntities db = new BDPEntities();
        public void InsertarEmpleados(empleados empleados)
        {
            db.empleados.Add(empleados);
            db.SaveChanges();
        }

        public List<empleados> ListarEmpleados()
        {
            return db.empleados.ToList();
        }

        public void DeletedEmpleado(int id)
        {
            empleados empleados = db.empleados.Find(id);
            db.empleados.Remove(empleados);
            db.SaveChanges();
        }

        public void EditEmpleado(empleados empleados)
        {
            db.Entry(empleados).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
