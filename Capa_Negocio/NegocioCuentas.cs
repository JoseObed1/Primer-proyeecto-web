using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Negocio
{
    public class NegocioCuentas
    {
        private BDPEntities db = new BDPEntities();

        DatosCuentas ejecutor = new DatosCuentas();
        public void GuardarCuentas(cuentas cuentas)
        {
            ejecutor.InsertarCuentas(cuentas);
        }

        public List<cuentas> MostrarDatos()
        {
            return ejecutor.ListarCuentas().ToList();
        }
        public void DeletedCuentas(int id)
        {
            ejecutor.DeletedCuentas(id);
        }
        public void EditCuentas(cuentas cuentas)
        {
            ejecutor.EditCuentas(cuentas);
        }

        //public List<BUSCAESTUDIANTE_Result> BuscaEstudiante(string matri)
        //{
        //    return db.BUSCAESTUDIANTE(matri).ToList();
        //}
    }
}
