using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Services;

namespace BLL
{
    public class Usuario
    {
        private MP_Usuario _mpUsuario = new MP_Usuario();
        public bool ValidarUsuario(BE.Usuario pUsuario)
        {
            //Hardcodeo un usuario momentaneamente
            //string email = "admin@admin.com";

            var user = GetUser(pUsuario.Email);
            if (user == null)
            {
                throw new LoginException(LoginResult.InvalidEmail);
            }

            if (CryptoManager.Compare(pUsuario.Password, user.Password))
            {
                return true;
            }

            throw new LoginException(LoginResult.InvalidPassword);

            //Clave hash admin = 8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918
            //string password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";

            //if (pUsuario.Email == email)
            //{
            //    return CryptoManager.Compare(pUsuario.Password, password);
            //}

            //return false;
            

        }

        public BE.Usuario GetUser(string email)
        {
            BE.Usuario user = _mpUsuario.GetAll().FirstOrDefault(u => u.Email.Equals(email));
            return user;
        }


        public BE.Usuario GetUserByUsername(string identityName)
        {
            BE.Usuario user = _mpUsuario.GetAll().FirstOrDefault(u => u.Username.Equals(identityName));
            return user;
        }
    }
}
