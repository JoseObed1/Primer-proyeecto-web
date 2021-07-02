using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class DatosDepartamentos
    {
        private BDPEntities db = new BDPEntities();
        public void InsertarDepartamentos(departamentos departamentos)
        {
            db.departamentos.Add(departamentos);
            db.SaveChanges();
        }

        public List<departamentos> ListarDepartamentos()
        {
            return db.departamentos.ToList();
        }

        public void DeletedDepartamentos(int id)
        {
            departamentos departamentos = db.departamentos.Find(id);
            db.departamentos.Remove(departamentos);
            db.SaveChanges();
        }

        public void EditDepartamentos(departamentos departamentos)
        {
            db.Entry(departamentos).State = EntityState.Modified;
            db.SaveChanges();
        }

        public string Sigla(string nombre)
        {
            departamentos tempdept = db.departamentos.FirstOrDefault(s => s.nombre == nombre);
            //if (!String.IsNullOrEmpty(nombre))
            //{
            //    sigla = sigla.Where(s => s.nombre.Contains(nombre));
            //}
            System.Diagnostics.Debug.WriteLine(tempdept.sigla.ToString());
            return tempdept.sigla.ToString();

        }
    }
}
