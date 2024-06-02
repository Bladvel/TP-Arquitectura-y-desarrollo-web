using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace BLL
{
    public class Usuario
    {
        public bool ValidarUsuario(BE.Usuario user)
        {
            //Hardcodeo un usuario momentaneamente
            string email = "admin@admin.com";


            //Clave hash admin = 8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918
            string password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";

            if (user.Email == email)
            {
                return CryptoManager.Compare(user.Password, password);
            }

            return false;
            

        }

    }
}
