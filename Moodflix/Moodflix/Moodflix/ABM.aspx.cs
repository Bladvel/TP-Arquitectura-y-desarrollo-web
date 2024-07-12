using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;

namespace Moodflix
{
    public partial class ABM : System.Web.UI.Page
    {
        BLL.Pelicula bllPelicula = new BLL.Pelicula();
        BLL.Libro bllLibro = new BLL.Libro();
        BLL.Emocion bllEmocion = new BLL.Emocion();
        BLL.DVH bllDvh = new BLL.DVH();
        BLL.DVV bllDvv = new BLL.DVV();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEmociones();
                CargarPeliculas();
                CargarLibros();
            }
        }


        private void CargarEmociones()
        {
            List<Emocion> emociones = bllEmocion.Listar();
            ddlEmocionPelicula.DataSource = emociones;
            ddlEmocionPelicula.DataTextField = "Nombre";
            ddlEmocionPelicula.DataValueField = "ID";
            ddlEmocionPelicula.DataBind();

            ddlEmocionLibro.DataSource = emociones;
            ddlEmocionLibro.DataTextField = "Nombre";
            ddlEmocionLibro.DataValueField = "ID";
            ddlEmocionLibro.DataBind();
        }

        private void CargarPeliculas()
        {
            List<Pelicula> peliculas = bllPelicula.Listar();
            gvPeliculas.DataSource = peliculas;
            gvPeliculas.DataBind();
        }

        private void CargarLibros()
        {
            List<Libro> libros = bllLibro.Listar();
            gvLibros.DataSource = libros;
            gvLibros.DataBind();
        }

        protected void btnAgregarPelicula_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Pelicula pelicula = new Pelicula
                {
                    Nombre = txtNombrePelicula.Text,
                    Descripcion = txtDescripcionPelicula.Text,
                    Fecha = DateTime.Parse(txtFechaPelicula.Value),
                    Precio = float.Parse(txtPrecioPelicula.Text),
                    Uri = txtUriPelicula.Text,
                    Emocion = new Emocion { ID = int.Parse(ddlEmocionPelicula.SelectedValue) },
                    Genero = txtGenero.Text,
                    Director = txtDirector.Text
                };

                bllPelicula.Insertar(pelicula);
                CargarPeliculas();
                
                
                bllDvh.Recalcular(bllDvh.Listar(), bllPelicula.Listar());
                bllDvv.Recalcular();
                ClientScript.RegisterStartupScript(this.GetType(), "alert4", "alert('Producto cargado con éxito.');", true);
            }
        }

        protected void btnActualizarPelicula_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int id = int.Parse(gvPeliculas.SelectedRow.Cells[0].Text);
                Pelicula pelicula = new Pelicula
                {
                    ID = id,
                    Nombre = txtNombrePelicula.Text,
                    Descripcion = txtDescripcionPelicula.Text,
                    Fecha = DateTime.Parse(txtFechaPelicula.Value),
                    Precio = float.Parse(txtPrecioPelicula.Text),
                    Uri = txtUriPelicula.Text,
                    Emocion = new Emocion { ID = int.Parse(ddlEmocionPelicula.SelectedValue) },
                    Genero = txtGenero.Text,
                    Director = txtDirector.Text
                };

                bllPelicula.Actualizar(pelicula);
                CargarPeliculas();

                
                bllDvh.Recalcular(bllDvh.Listar(), bllPelicula.Listar());
                bllDvv.Recalcular();

                ClientScript.RegisterStartupScript(this.GetType(), "alert5", "alert('Producto actualizado con éxito.');", true);
            }
        }

        protected void btnEliminarPelicula_OnClick(object sender, EventArgs e)
        {
            int id = int.Parse(gvPeliculas.SelectedRow.Cells[0].Text);
            bllPelicula.Eliminar(id);
            CargarPeliculas();

            
            bllDvh.Recalcular(bllDvh.Listar(), bllPelicula.Listar());
            bllDvv.Recalcular();

            ClientScript.RegisterStartupScript(this.GetType(), "alert6", "alert('Producto eliminado con éxito.');", true);
        }

        protected void gvPeliculas_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(gvPeliculas.SelectedRow.Cells[0].Text);
            Pelicula pelicula = bllPelicula.ObtenerPorId(id);
            txtNombrePelicula.Text = pelicula.Nombre;
            txtDescripcionPelicula.Text = pelicula.Descripcion;
            txtFechaPelicula.Value = pelicula.Fecha.ToString("yyyy-MM-dd");
            txtPrecioPelicula.Text = pelicula.Precio.ToString();
            txtUriPelicula.Text = pelicula.Uri;
            ddlEmocionPelicula.SelectedValue = pelicula.Emocion.ID.ToString();
            txtGenero.Text = pelicula.Genero;
            txtDirector.Text = pelicula.Director;
        }

        protected void btnAgregarLibro_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Libro libro = new Libro
                {
                    Nombre = txtNombreLibro.Text,
                    Descripcion = txtDescripcionLibro.Text,
                    Fecha = DateTime.Parse(txtFechaLibro.Text),
                    Precio = float.Parse(txtPrecioLibro.Text),
                    Uri = txtUriLibro.Text,
                    Emocion = new Emocion { ID = int.Parse(ddlEmocionLibro.SelectedValue) },
                    Autor = txtAutor.Text,
                    Editorial = txtEditorial.Text
                };

                bllLibro.Insertar(libro);
                CargarLibros();

                
                bllDvh.Recalcular(bllDvh.Listar(), bllLibro.Listar());
                bllDvv.Recalcular();
                ClientScript.RegisterStartupScript(this.GetType(), "alert1", "alert('Producto cargado con éxito.');", true);
            }
        }

        protected void btnActualizarLibro_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int id = int.Parse(gvLibros.SelectedRow.Cells[0].Text);
                Libro libro = new Libro
                {
                    ID = id,
                    Nombre = txtNombreLibro.Text,
                    Descripcion = txtDescripcionLibro.Text,
                    Fecha = DateTime.Parse(txtFechaLibro.Text),
                    Precio = float.Parse(txtPrecioLibro.Text),
                    Uri = txtUriLibro.Text,
                    Emocion = new Emocion { ID = int.Parse(ddlEmocionLibro.SelectedValue) },
                    Autor = txtAutor.Text,
                    Editorial = txtEditorial.Text
                };

                bllLibro.Actualizar(libro);
                CargarLibros();
                
                bllDvh.Recalcular(bllDvh.Listar(), bllLibro.Listar());
                bllDvv.Recalcular();
                ClientScript.RegisterStartupScript(this.GetType(), "alert2", "alert('Producto actualizado con éxito.');", true);
            }
        }

        protected void btnEliminarLibro_OnClick(object sender, EventArgs e)
        {
            int id = int.Parse(gvLibros.SelectedRow.Cells[0].Text);
            bllLibro.Eliminar(id);
            CargarLibros();

            
            bllDvh.Recalcular(bllDvh.Listar(), bllLibro.Listar());
            bllDvv.Recalcular();

            ClientScript.RegisterStartupScript(this.GetType(), "alert3", "alert('Producto eliminado con éxito.');", true);
        }

        protected void gvLibros_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(gvLibros.SelectedRow.Cells[0].Text);
            Libro libro = bllLibro.ObtenerPorId(id);
            txtNombreLibro.Text = libro.Nombre;
            txtDescripcionLibro.Text = libro.Descripcion;
            txtFechaLibro.Text = libro.Fecha.ToString("yyyy-MM-dd");
            txtPrecioLibro.Text = libro.Precio.ToString();
            txtUriLibro.Text = libro.Uri;
            ddlEmocionLibro.SelectedValue = libro.Emocion.ID.ToString();
            txtAutor.Text = libro.Autor;
            txtEditorial.Text = libro.Editorial;
        }
    }
}