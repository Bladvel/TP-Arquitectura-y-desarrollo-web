using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class MP_Libro: Mapper<Libro>
    {
        public override Libro GetById(object id)
        {
            throw new NotImplementedException();
        }

        private MP_Emocion mpEmocion = new MP_Emocion();

        public override Libro Transform(DataRow dr)
        {
            Libro libro = new Libro();
            libro.ID = int.Parse(dr["ID"].ToString());
            libro.Nombre = dr["NOMBRE"].ToString();
            libro.Descripcion = dr["DESCRIPCION"].ToString();
            libro.Fecha = DateTime.Parse(dr["FECHA"].ToString());
            libro.Autor = dr["AUTOR"].ToString();
            libro.Editorial = dr["EDITORIAL"].ToString();
            libro.Emocion = mpEmocion.GetById(dr["ID_EMOCION"].ToString());
            libro.Uri = dr["URI_RELATIVO"].ToString();
            libro.Precio = float.Parse(dr["PRECIO"].ToString());

            return libro;


        }

        public override List<Libro> GetAll()
        {
            List<Libro> libros = new List<Libro>();

            access.Open();
            DataTable dt = access.Read("LISTAR_LIBRO");
            access.Close();

            foreach (DataRow dr in dt.Rows)
            {
                libros.Add(Transform(dr));
            }

            return libros;
        }

        public override int Insert(Libro entity)
        {
            throw new NotImplementedException();
        }

        public override int Update(Libro entity)
        {
            throw new NotImplementedException();
        }

        public override int Delete(Libro entity)
        {
            throw new NotImplementedException();
        }
    }
}
