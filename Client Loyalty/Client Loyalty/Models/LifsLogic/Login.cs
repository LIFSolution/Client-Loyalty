using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client_Loyalty.Models.LifsLogic
{
    public class LoginLogic
    {
        public int IngresoNuevoUsuario(lifsEF.Usuarios Miusuario)
        {
            int iresultado = 0;
            //evaluar usuario 
            lifsEF.LifsControlDbEntities dbcontext = new lifsEF.LifsControlDbEntities();
            dbcontext.Usuarios.Add(Miusuario);
            
            return iresultado;
        }
    }
}