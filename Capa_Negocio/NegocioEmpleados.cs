using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class NegocioEmpleados
    {
        private BDPEntities db = new BDPEntities();

        DatosEmpleados ejecutor = new DatosEmpleados();
        public void GuardarEmpleados(empleados empleados)
        {
            ejecutor.InsertarEmpleados(empleados);
        }

        public List<empleados> MostrarDatos()
        {
            return ejecutor.ListarEmpleados().ToList();
        }
        public void DeletedEmpleado(int id)
        {
            ejecutor.DeletedEmpleado(id);
        }
        public void EditEmpleado(empleados empleados)
        {
            ejecutor.EditEmpleado(empleados);
        }

        //public List<BUSCAESTUDIANTE_Result> BuscaEstudiante(string matri)
        //{
        //    return db.BUSCAESTUDIANTE(matri).ToList();
        //}
    }
}
