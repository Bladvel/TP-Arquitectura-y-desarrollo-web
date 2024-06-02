using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class MP_Usuario: Mapper<BE.Usuario>
    {
        public override Usuario GetById(object id)
        {
            throw new NotImplementedException();
        }

        public override Usuario Transform(DataRow dr)
        {
            Usuario usuario = new Usuario();
            usuario.ID = int.Parse(dr["ID"].ToString());
            usuario.Email = dr["EMAIL"].ToString();
            usuario.Password = dr["PASSWORD"].ToString();
            usuario.Username = dr["USERNAME"].ToString();


            return usuario;
        }

        public override List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            access.Open();
            DataTable dt = access.Read("LISTAR_USUARIO");
            access.Close();
            foreach (DataRow dr in dt.Rows)
            {
                usuarios.Add(Transform(dr));
            }

            return usuarios;
        }

        public override int Insert(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public override int Update(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public override int Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
