using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Moodflix
{
    public partial class Backup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnExaminarBackup_OnClick(object sender, EventArgs e)
        {
            
        }

        BLL.BackupService bllBackupService = new BLL.BackupService();

        protected void btnComenzarRestore_OnClick(object sender, EventArgs e)
        {
            if (FileUploadRestore.HasFile)
            {
                string rutaRestore = FileUploadRestore.PostedFile.FileName;
                txtRutaRestore.Text = rutaRestore;

                
                try
                {
                    //TODO no funciona el restore por problema de permisos
                    
                    string path = Server.MapPath("~/App_Data/" + FileUploadRestore.FileName);
                    FileUploadRestore.SaveAs(path);

                    
                    bllBackupService.RestoresBackup(path);

                    
                    ClientScript.RegisterStartupScript(this.GetType(), "alert1", "alert('Restore completado con éxito.');", true);
                }
                catch (Exception ex)
                {
                    
                    ClientScript.RegisterStartupScript(this.GetType(), "alert2", $"alert('Error durante el restore: {ex.Message}');", true);
                }
            }
            else
            {
                // Mensaje de archivo no seleccionado
                ClientScript.RegisterStartupScript( this.GetType(), "alert3", "alert('Seleccione un archivo de backup para continuar.');", true);
            }
        }
    }
}