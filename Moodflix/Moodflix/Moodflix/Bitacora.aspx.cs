using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Moodflix
{
    public partial class Bitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar();
            }

            
        }

        BLL.Bitacora bllBitacora = new BLL.Bitacora();

        public void Listar()
        {
            gvBitacora.DataSource = bllBitacora.Listar();
            gvBitacora.DataBind();
        }


        


        protected void btnFiltrar_OnClick(object sender, EventArgs e)
        {

            

            if (string.IsNullOrEmpty(txtFechaHoraInicio.Value) || string.IsNullOrEmpty(txtFechaHoraFin.Value))
            {
                lblPrueba.Text = "Por favor selecciona una fecha de inicio y una fecha final";
                return;
            }
            DateTime fechaInicio = DateTime.Parse(txtFechaHoraInicio.Value);
            DateTime fechaFin = DateTime.Parse(txtFechaHoraFin.Value);


            if (fechaInicio>fechaFin)
            {
                lblPrueba.Text = "No se puede realizar la busqueda con la 'Fecha de Fin' menor a la 'Fecha de inicio'";
                return;
            }

            gvBitacora.DataSource = bllBitacora.Filtrar(fechaInicio, fechaFin);
            gvBitacora.DataBind();
        }
    }
}