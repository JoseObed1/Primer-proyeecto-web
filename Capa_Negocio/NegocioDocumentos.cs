using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class NegocioDocumentos
    {
        private BDPEntities db = new BDPEntities();

        DatosDocumentos ejecutor = new DatosDocumentos();
        public void GuardarDocumentos(documento documento)
        {
            ejecutor.InsertarDocumentos(documento);
        }

        public List<documento> MostrarDocumentos()
        {
            return ejecutor.ListarDocumentos().ToList();
        }
        public void DeletedDocumentos(int id)
        {
            ejecutor.DeletedDocumentos(id);
        }
        public void EditDocumentos(documento documento)
        {
            ejecutor.EditDocumentos(documento);
        }

        public string CodeGen(string siglaOr, string siglaDest)
        {
            return ejecutor.CodeGen(siglaOr, siglaDest);
        }

        //public List<BUSCAESTUDIANTE_Result> BuscaEstudiante(string matri)
        //{
        //    return db.BUSCAESTUDIANTE(matri).ToList();
        //}
    }
}
