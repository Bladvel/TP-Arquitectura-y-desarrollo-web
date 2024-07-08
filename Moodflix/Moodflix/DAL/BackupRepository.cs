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
        //string connectionString = WebConfigurationManager.ConnectionStrings["DanDesktop"].ConnectionString;

        SqlConnection conexion = new SqlConnection(WebConfigurationManager.ConnectionStrings["DanDesktop"].ConnectionString);
        public void CreateBackup(string consulta)
        {

            string comando_consulta = "BACKUP DATABASE[MOODFLIX] TO DISK = N'" + consulta + "' WITH NOFORMAT, NOINIT, NAME = N'MOODFLIX-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            SqlCommand cmd = new SqlCommand(comando_consulta, conexion);
            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void RestoresBackup(string consulta)
        {

            


            string sql = @"
            ALTER DATABASE [MOODFLIX] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            RESTORE DATABASE [MOODFLIX] FROM DISK = N'" + consulta + @"' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10;
            ALTER DATABASE [MOODFLIX] SET MULTI_USER;";


            conexion.Open();

            string str1 = string.Format("ALTER DATABASE [SISCAB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            SqlCommand cmd1 = new SqlCommand(str1, conexion);
            cmd1.ExecuteNonQuery();

            string str2 = @"USE MASTER RESTORE DATABASE [MOODFLIX] FROM DISK = N'" + consulta + @"' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10;";
            SqlCommand cmd2 = new SqlCommand(str2, conexion);
            cmd2.ExecuteNonQuery();

            string str3 = string.Format("ALTER DATABASE [SISCAB] SET MULTI_USER");
            SqlCommand cmd3 = new SqlCommand(str3, conexion);
            cmd3.ExecuteNonQuery();

            conexion.Close();

           


        }
    }
}
