using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Services;

namespace BLL
{
    public class DVV
    {
        private MP_Dvv mpDvv = new MP_Dvv();
        Usuario bllUsuario = new Usuario();
        Emocion bllEmocion = new Emocion();
        Pelicula bllPelicula = new Pelicula();
        Libro bllLibro = new Libro();
        Bitacora bllBitacora = new Bitacora();


        public List<Services.DVV> Listar()
        {
            return mpDvv.GetAll();
        }

        public int Insertar(Services.DVV dvv)
        {
            return mpDvv.Insert(dvv);
        }

        public int Actualizar(Services.DVV dvv)
        {
            return mpDvv.Update(dvv);
        }

        public void BorrarRegistros()
        {
            mpDvv.DeleteAll();
        }


        public string ObtenerDV(string cadena)
        {
            return CryptoManager.Hash(cadena);
        }


        private string ConcatenarColumna<T>(List<T> entities, string columnName)
        {
            return string.Join("", entities.Select(entity => ObtenerValorColumna(entity, columnName)));
        }





        public void Recalcular()
        {
            List<Services.DVV> dVVs = Listar();

            var entitiesAndColumns = new List<(List<object> entities, List<string> columns)>
            {
                (bllLibro.Listar().Cast<object>().ToList(), new List<string> { "ID", "NOMBRE", "DESCRIPCION", "FECHA", "AUTOR", "EDITORIAL", "ID_EMOCION", "URI_RELATIVO", "PRECIO" }),
                (bllEmocion.Listar().Cast<object>().ToList(), new List<string> { "ID", "NOMBRE", "URI_RELATIVO" }),
                (bllPelicula.Listar().Cast<object>().ToList(), new List<string> { "ID", "NOMBRE", "DESCRIPCION", "FECHA", "GENERO", "DIRECTOR", "ID_EMOCION", "URI_RELATIVO", "PRECIO" }),
                (bllUsuario.Listar().Cast<object>().ToList(), new List<string> { "ID", "USERNAME", "EMAIL", "PASSWORD" }),
                (bllBitacora.Listar().Cast<object>().ToList(), new List<string> { "ID", "ID_USUARIO", "FECHA", "OPERACION", "MODULO" })
            };

            foreach (var (entities, columns) in entitiesAndColumns)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    var vectorHASH = ObtenerDV(ConcatenarColumna(entities, columns[i]));
                    var dvv = dVVs.FirstOrDefault(d => d.Tabla == entities.First().GetType().Name.ToUpper() && d.Columna == i + 1);
                    if (dvv != null)
                    {
                        dvv.DV = vectorHASH;
                        Actualizar(dvv);
                    }
                    else
                    {
                        dvv = new Services.DVV
                        {
                            Tabla = entities.First().GetType().Name.ToUpper(),
                            Columna = i + 1,
                            DV = vectorHASH
                        };
                        Insertar(dvv);
                    }
                }
            }
        }

        //public bool ValidarDigitoVerificador()
        //{
        //    List<Services.DVV> dVVs = Listar();
        //    bool ok = true;

        //    var entitiesAndColumns = new List<(List<object> entities, List<string> columns)>
        //    {
        //        (bllLibro.Listar().Cast<object>().ToList(), new List<string> { "ID", "NOMBRE", "DESCRIPCION", "FECHA", "AUTOR", "EDITORIAL", "ID_EMOCION", "URI_RELATIVO", "PRECIO" }),
        //        (bllEmocion.Listar().Cast<object>().ToList(), new List<string> { "ID", "NOMBRE", "URI_RELATIVO" }),
        //        (bllPelicula.Listar().Cast<object>().ToList(), new List<string> { "ID", "NOMBRE", "DESCRIPCION", "FECHA", "GENERO", "DIRECTOR" , "ID_EMOCION", "URI_RELATIVO", "PRECIO"}),
        //        (bllUsuario.Listar().Cast<object>().ToList(), new List<string> { "ID", "USERNAME", "EMAIL", "PASSWORD" }),
        //        (bllBitacora.Listar().Cast<object>().ToList(), new List<string> { "ID", "ID_USUARIO", "FECHA", "OPERACION", "MODULO" })
        //    };

        //    foreach (var (entities, columns) in entitiesAndColumns)
        //    {
        //        for (int i = 0; i < columns.Count; i++)
        //        {
        //            var vectorHASH = ObtenerDV(ConcatenarColumna(entities, columns[i]));
        //            var dvv = dVVs.FirstOrDefault(d => d.Tabla == entities.First().GetType().Name.ToUpper() && d.Columna == i + 1);
        //            if (dvv != null && vectorHASH != dvv.DV)
        //            {
        //                ok = false;
        //            }
        //        }
        //    }

        //    return ok;
        //}


        public List<ColumnaInvalida> ValidarDigitoVerificador()
        {
            List<Services.DVV> dVVs = Listar();
            List<ColumnaInvalida> columnasInvalidas = new List<ColumnaInvalida>();

            var entitiesAndColumns = new List<(List<object> entities, List<string> columns)>
            {
                (bllLibro.Listar().Cast<object>().ToList(), new List<string> { "ID", "NOMBRE", "DESCRIPCION", "FECHA", "AUTOR", "EDITORIAL", "ID_EMOCION", "URI_RELATIVO", "PRECIO" }),
                (bllEmocion.Listar().Cast<object>().ToList(), new List<string> { "ID", "NOMBRE", "URI_RELATIVO" }),
                (bllPelicula.Listar().Cast<object>().ToList(), new List<string> { "ID", "NOMBRE", "DESCRIPCION", "FECHA", "GENERO", "DIRECTOR", "ID_EMOCION", "URI_RELATIVO", "PRECIO" }),
                (bllUsuario.Listar().Cast<object>().ToList(), new List<string> { "ID", "USERNAME", "EMAIL", "PASSWORD" }),
                (bllBitacora.Listar().Cast<object>().ToList(), new List<string> { "ID", "ID_USUARIO", "FECHA", "OPERACION", "MODULO" })
            };

            foreach (var (entities, columns) in entitiesAndColumns)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    var vectorHASH = ObtenerDV(ConcatenarColumna(entities, columns[i]));
                    var dvv = dVVs.FirstOrDefault(d => d.Tabla == entities.First().GetType().Name.ToUpper() && d.Columna == i + 1);

                    if (dvv != null && vectorHASH != dvv.DV)
                    {
                        columnasInvalidas.Add(new ColumnaInvalida { DVV = dvv, Estado = "Modificada" });
                    }
                    else if (dvv == null)
                    {
                        columnasInvalidas.Add(new ColumnaInvalida { DVV = new Services.DVV { Tabla = entities.First().GetType().Name.ToUpper(), Columna = i + 1, DV = vectorHASH }, Estado = "Eliminada" });
                    }
                }
            }

            return columnasInvalidas;
        }




        private string ObtenerValorColumna<T>(T entity, string columnName)
        {
            if (entity is BE.Libro libro)
            {
                switch (columnName)
                {
                    case "ID":
                        return libro.ID.ToString();
                    case "NOMBRE":
                        return libro.Nombre;
                    case "DESCRIPCION":
                        return libro.Descripcion;
                    case "FECHA":
                        return libro.Fecha.ToString();
                    case "AUTOR":
                        return libro.Autor;
                    case "EDITORIAL":
                        return libro.Editorial;
                    case "ID_EMOCION":
                        return libro.Emocion.ID.ToString();
                    case "URI_RELATIVO":
                        return libro.Uri;
                    case "PRECIO":
                        return libro.Precio.ToString();
                    default:
                        throw new ArgumentException("Nombre de columna invalido");
                }
            }
            else if (entity is BE.Emocion emocion)
            {
                switch (columnName)
                {
                    case "ID":
                        return emocion.ID.ToString();
                    case "NOMBRE":
                        return emocion.TipoEmocion.ToString();
                    case "URI_RELATIVO":
                        return emocion.Uri;
                    default:
                        throw new ArgumentException("Nombre de columna invalido");
                }
            }
            else if (entity is BE.Pelicula pelicula)
            {
                switch (columnName)
                {
                    case "ID":
                        return pelicula.ID.ToString();
                    case "NOMBRE":
                        return pelicula.Nombre;
                    case "DESCRIPCION":
                        return pelicula.Descripcion;
                    case "FECHA":
                        return pelicula.Fecha.ToString();
                    case "GENERO":
                        return pelicula.Genero;
                    case "DIRECTOR":
                        return pelicula.Director;
                    case "ID_EMOCION":
                        return pelicula.Emocion.ID.ToString();
                    case "URI_RELATIVO":
                        return pelicula.Uri;
                    case "PRECIO":
                        return pelicula.Precio.ToString();
                    default:
                        throw new ArgumentException("Nombre de columna invalido");
                }
            }
            else if (entity is BE.Usuario usuario)
            {
                switch (columnName)
                {
                    case "ID":
                        return usuario.ID.ToString();
                    case "USERNAME":
                        return usuario.Username;
                    case "EMAIL":
                        return usuario.Email;
                    case "PASSWORD":
                        return usuario.Password;
                    default:
                        throw new ArgumentException("Nombre de columna invalido");
                }
            }
            else if (entity is Services.Bitacora bitacora)
            {
                switch (columnName)
                {
                    case "ID":
                        return bitacora.ID.ToString();
                    case "ID_USUARIO":
                        return bitacora.User.ID.ToString();
                    case "FECHA":
                        return bitacora.Fecha.ToString();
                    case "OPERACION":
                        return bitacora.Operacion.ToString();
                    case "MODULO":
                        return bitacora.Modulo.ToString();
                    default:
                        throw new ArgumentException("Nombre de columna invalido");
                }
            }
            else
            {
                throw new ArgumentException("Tipo de entidad desconocida");
            }
        }

    }
}
