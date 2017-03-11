using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Client_Loyalty.Modulos
{
    public partial class logIn : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection("Data Source=LAPTOP-F8V8Q28T\\MYHPSQL;Initial Catalog=LifsControlDb;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        ////**************************************************************************** ESTO VA DENTRO DEL BOTON /////////////////////////////////////////////////////////////////////

        //String user ="";//RECIBIRA EL USUARIO INGRESADO
        //String pass=""; //RECIBIRA LA CONTRASEÑA
        //if(verificarLogIn(user,pass) == true)
        //{
        //    //DIRIGIRSE A LA SIGUIENTE PAGINA
        //}else
        //{
        //    Response.Write("<script>window.alert('Usuario o Contraseña Incorrecta');</script>");
        //}

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool verificarLogIn(String usu, String pass)
        {
            try
            {
                int bandera = 0;
                cn.Open();
                cmd = new SqlCommand(string.Format("Select * From Usuarios Where Usuario = '{0}' and Contrasena = '{1}'", usu, pass), cn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    bandera = 3;
                }

                cn.Close();
                if (bandera != 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}