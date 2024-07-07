using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Services;

namespace BLL
{
    public class DVH
    {
        MP_Dvh mpDvh = new MP_Dvh();
        Usuario bllUsuario = new Usuario();
        Emocion bllEmocion = new Emocion();
        Pelicula bllPelicula = new Pelicula();
        Libro bllLibro = new Libro();

        public List<Services.DVH> Listar()
        {
            return mpDvh.GetAll();
        }

        public int Insertar(Services.DVH dvh)
        {
            return mpDvh.Insert(dvh);
        }

        public int Actualizar(Services.DVH dvh)
        {
            return mpDvh.Update(dvh);
        }

        public string ObtenerDV(string cadena)
        {
            return CryptoManager.Hash(cadena);
        }

        

        public void Recalcular(List<Services.DVH> dvhs, List<BE.Usuario> usuarios)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                string cadena = bllUsuario.Concatenar(usuarios[i]);
                Services.DVH dvh = new Services.DVH();
                dvh.Tabla = "USUARIO";
                dvh.Registro = usuarios[i].ID;
                dvh.DV = ObtenerDV(cadena);

                var existeDvh = dvhs.FirstOrDefault(d => d.Tabla == dvh.Tabla && d.Registro == dvh.Registro);
                if (existeDvh != null)
                {
                    Actualizar(dvh);
                }
                else
                {
                    Insertar(dvh);
                }

            }
        }

        public void Recalcular(List<Services.DVH> dvhs, List<BE.Emocion> emociones)
        {
            for (int i = 0; i < emociones.Count; i++)
            {
                string cadena = bllEmocion.Concatenar(emociones[i]);
                Services.DVH dvh = new Services.DVH();
                dvh.Tabla = "EMOCION";
                dvh.Registro = emociones[i].ID;
                dvh.DV = ObtenerDV(cadena);

                var existeDvh = dvhs.FirstOrDefault(d => d.Tabla == dvh.Tabla && d.Registro == dvh.Registro);
                if (existeDvh != null)
                {
                    Actualizar(dvh);
                }
                else
                {
                    Insertar(dvh);
                }

            }
        }

        public void Recalcular(List<Services.DVH> dvhs, List<BE.Pelicula> peliculas)
        {
            for (int i = 0; i < peliculas.Count; i++)
            {
                string cadena = bllPelicula.Concatenar(peliculas[i]);
                Services.DVH dvh = new Services.DVH();
                dvh.Tabla = "PELICULA";
                dvh.Registro = peliculas[i].ID;
                dvh.DV = ObtenerDV(cadena);

                var existeDvh = dvhs.FirstOrDefault(d => d.Tabla == dvh.Tabla && d.Registro == dvh.Registro);
                if (existeDvh != null)
                {
                    Actualizar(dvh);
                }
                else
                {
                    Insertar(dvh);
                }

            }
        }
        public void Recalcular(List<Services.DVH> dvhs, List<BE.Libro> libros)
        {
            for (int i = 0; i < libros.Count; i++)
            {
                string cadena = bllLibro.Concatenar(libros[i]);
                Services.DVH dvh = new Services.DVH();
                dvh.Tabla = "LIBRO";
                dvh.Registro = libros[i].ID;
                dvh.DV = ObtenerDV(cadena);

                var existeDvh = dvhs.FirstOrDefault(d => d.Tabla == dvh.Tabla && d.Registro == dvh.Registro);
                if (existeDvh != null)
                {
                    Actualizar(dvh);
                }
                else
                {
                    Insertar(dvh);
                }

            }
        }

        public List<Services.DVH> ValidarDigitoVerificador()
        {
            List<Services.DVH> registrosInvalidos = new List<Services.DVH>();

            // Listar todas las entidades de la base de datos
            List<BE.Pelicula> peliculas = bllPelicula.Listar();
            List<BE.Emocion> emociones = bllEmocion.Listar();
            List<BE.Libro> libros = bllLibro.Listar();
            List<BE.Usuario> usuarios = bllUsuario.Listar();
            

            
            List<Services.DVH> dVHs = Listar();


            foreach (var pelicula in peliculas)
            {
                var cadena = bllPelicula.Concatenar(pelicula);
                var hash = ObtenerDV(cadena);

                var dvh = dVHs.FirstOrDefault(d => d.Tabla == "PELICULA" && d.Registro == pelicula.ID);
                if (dvh != null && hash != dvh.DV)
                {
                    registrosInvalidos.Add(dvh);
                }


            }

            foreach (var emocion in emociones)
            {
                var cadena = bllEmocion.Concatenar(emocion);
                var hash = ObtenerDV(cadena);
                var dvh = dVHs.FirstOrDefault(d => d.Tabla == "EMOCION" && d.Registro == emocion.ID);
                if (dvh != null && hash != dvh.DV)
                {
                    registrosInvalidos.Add(dvh);
                }
            }

            
            foreach (var usuario in usuarios)
            {
                var cadena = bllUsuario.Concatenar(usuario);
                var hash = ObtenerDV(cadena);

                var dvh = dVHs.FirstOrDefault(d => d.Tabla == "USUARIO" && d.Registro == usuario.ID);
                if (dvh != null && hash != dvh.DV)
                {
                    registrosInvalidos.Add(dvh);
                }
            }


            foreach (var libro in libros)
            {
                var cadena = bllLibro.Concatenar(libro);
                var hash = ObtenerDV(cadena);

                var dvh = dVHs.FirstOrDefault(d => d.Tabla == "LIBRO" && d.Registro == libro.ID);
                if (dvh != null && hash != dvh.DV)
                {
                    registrosInvalidos.Add(dvh);
                }
            }

            return registrosInvalidos;
        }





    }
}
