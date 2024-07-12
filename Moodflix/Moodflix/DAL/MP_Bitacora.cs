using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BE;
using Services;

namespace DAL
{
    public class MP_Bitacora: Mapper<Bitacora>
    {
        MP_Usuario _mpUsuario = new MP_Usuario();

        public override Bitacora GetById(object id)
        {
            throw new NotImplementedException();
        }

        public override Bitacora Transform(DataRow dr)
        {
            Bitacora bitacora = new Bitacora();
            bitacora.ID = int.Parse(dr["ID"].ToString());
            bitacora.Fecha = DateTime.Parse(dr["FECHA"].ToString());
            //Arreglar cambio de bitacora
            try
            {
                bitacora.Modulo = (TipoModulo)Enum.Parse(typeof(TipoModulo), dr["MODULO"].ToString());
            }
            catch
            {
                bitacora.Modulo = TipoModulo.Desconocido;
            }


            try
            {
                bitacora.Operacion = (TipoOperacion)Enum.Parse(typeof(TipoOperacion), dr["OPERACION"].ToString());
            }
            catch (Exception e)
            {
                bitacora.Operacion = TipoOperacion.Desconocida;
            }

            
            bitacora.User = new Usuario();
            bitacora.User.ID = int.Parse(dr["ID_USUARIO"].ToString());


            return bitacora;

        }


        public override List<Bitacora> GetAll()
        {


            List<Bitacora> bitacoras = new List<Bitacora>();
            access.Open();
            DataTable dt = access.Read("LISTAR_BITACORA");
            access.Close();


            List<Usuario> usuarios = _mpUsuario.GetAll();

            foreach (DataRow registro in dt.Rows)
            {
                Bitacora bitacora = Transform(registro);

                bitacora.User = (from Usuario us in usuarios
                                 where us.ID == bitacora.User.ID
                                 select us).FirstOrDefault();
                bitacoras.Add(bitacora);
            }
            return bitacoras;

        }


        public List<Bitacora> FiltrarBitacora(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Bitacora> bitacoras = new List<Bitacora>();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                access.CreateParameter("@FechaInicio", fechaInicio),
                access.CreateParameter("@FechaFin", fechaFin)
            };

            access.Open();
            DataTable dt = access.Read("FILTRAR_BITACORA_FECHAS", parameters);
            access.Close();

            List<Usuario> usuarios = _mpUsuario.GetAll();

            foreach (DataRow registro in dt.Rows)
            {
                Bitacora bitacora = Transform(registro);

                bitacora.User = (from Usuario us in usuarios
                    where us.ID == bitacora.User.ID
                    select us).FirstOrDefault();
                bitacoras.Add(bitacora);
            }

            return bitacoras;
        }


        public override int Insert(Bitacora entity)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                access.CreateParameter("@fecha", entity.Fecha),
                access.CreateParameter("@id_usuario", entity.User.ID),
                access.CreateParameter("@modulo", entity.Modulo.ToString()),
                access.CreateParameter("@operacion", entity.Operacion.ToString())

            };

            access.Open();
            int filasAfectadas = access.Write("INSERTAR_BITACORA", parameters);
            access.Close();

            return filasAfectadas;

        }

        public override int Update(Bitacora entity)
        {
            throw new NotImplementedException();
        }

        public override int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
