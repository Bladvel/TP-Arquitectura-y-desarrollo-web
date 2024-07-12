using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DAL
{
    public class BackupRepository
    {


        Access access = new Access();
        //string connectionString = WebConfigurationManager.ConnectionStrings["DanDesktop"].ConnectionString;

        //SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["DanDesktop"].ConnectionString);
        //public void CreateBackup(string consulta)
        //{

        //    string comando_consulta = "BACKUP DATABASE[MOODFLIX] TO DISK = N'" + consulta + "' WITH NOFORMAT, NOINIT, NAME = N'MOODFLIX-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
        //    SqlCommand cmd = new SqlCommand(comando_consulta, conexion);
        //    conexion.Open();
        //    cmd.ExecuteNonQuery();
        //    conexion.Close();
        //}

        public int CreateBackup(string ruta)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                access.CreateParameter("@ruta", ruta)
            };

            access.Open();
            int resultado = access.Write("GENERAR_BACKUP", parameters);
            access.Close();

            return resultado;
        }



        public void RestoresBackup(string consulta)
        {




            //string sql = @"
            //ALTER DATABASE [MOODFLIX] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            //RESTORE DATABASE [MOODFLIX] FROM DISK = N'" + consulta + @"' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10;
            //ALTER DATABASE [MOODFLIX] SET MULTI_USER;";


            using (SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["DanDesktop"].ConnectionString))
            {
                conexion.Open();

                SqlCommand cmd1 = new SqlCommand("ALTER DATABASE [MOODFLIX] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", conexion);
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("USE MASTER RESTORE DATABASE [MOODFLIX] FROM DISK = N'" + consulta + @"' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10;", conexion);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("ALTER DATABASE [MOODFLIX] SET MULTI_USER", conexion);
                cmd3.ExecuteNonQuery();

                conexion.Close();
            }




        }
    }
}
