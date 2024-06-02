using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Bitacora
    {
        private MP_Bitacora _mpBitacora = new MP_Bitacora();
        public int Insertar(Services.Bitacora bitacora)
        {
            return _mpBitacora.Insert(bitacora);
        }

        public List<Services.Bitacora> Listar()
        {
            return _mpBitacora.GetAll();
        }
    }
}
