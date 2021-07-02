using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class NegocioDepartamentos
    {
        private BDPEntities db = new BDPEntities();

        DatosDepartamentos ejecutor = new DatosDepartamentos();
        public void GuardarDepartamentos(departamentos departamentos)
        {
            ejecutor.InsertarDepartamentos(departamentos);
        }

        public List<departamentos> MostrarDatos()
        {
            return ejecutor.ListarDepartamentos().ToList();
        }
        public void DeletedDepartamentos(int id)
        {
            ejecutor.DeletedDepartamentos(id);
        }
        public void EditDepartamentos(departamentos departamentos)
        {
            ejecutor.EditDepartamentos(departamentos);
        }

        public string Sigla(string nombre)
        {
            return ejecutor.Sigla(nombre);
        }

        //public List<BUSCAESTUDIANTE_Result> BuscaEstudiante(string matri)
        //{
        //    return db.BUSCAESTUDIANTE(matri).ToList();
        //}
    }
}
