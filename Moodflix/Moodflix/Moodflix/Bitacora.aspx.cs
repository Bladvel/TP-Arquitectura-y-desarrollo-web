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

    }
}