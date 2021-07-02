using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class DatosDocumentos
    {
        private BDPEntities db = new BDPEntities();
        public void InsertarDocumentos(documento documento)
        {
            db.documento.Add(documento);
            db.SaveChanges();
        }

        public List<documento> ListarDocumentos()
        {
            return db.documento.ToList();
        }

        public void DeletedDocumentos(int id)
        {
            documento documento = db.documento.Find(id);
            db.documento.Remove(documento);
            db.SaveChanges();
        }

        public void EditDocumentos(documento documento)
        {
            db.Entry(documento).State = EntityState.Modified;
            db.SaveChanges();
        }
        public string CodeGen(string siglaOr, string siglaDest)
        {
            DateTime fecha = DateTime.Now;
            Random rd = new Random();
            int rand_num = rd.Next(1, 999);
            string finalString = "";
            if (rand_num < 10)
            {
                finalString = "00" + rand_num;
            }
            else if (rand_num >= 10 & rand_num < 100)
            {
                finalString = "0" + rand_num;
            }
            else if (rand_num >= 100)
            {
                finalString = rand_num.ToString();
            }
            //string finalString = string.Format("%d%03d", rand_num);
            string code = fecha.ToString("yyyy")+ "-" +siglaOr + "-" + siglaDest + "-" + finalString;
            return code;
        }
    }
}
