using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Client_Loyalty
{
    public partial class LogIn : System.Web.UI.Page
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            String user="";//RECIBIRA EL USUARIO INGRESADO
            String pass=""; //RECIBIRA LA CONTRASEÑA
            if(verificarLogIn(user,pass) == true)
            {
                //DIRIGIRSE A LA SIGUIENTE PAGINA
            }else
            {
                Response.Write("<script>window.alert('Usuario o Contraseña Incorrecta');</script>");
            }

        }

        public bool verificarLogIn(String user, String pass)
        {
            try
            {
                cn = new SqlConnection("Data Source=LAPTOP-F8V8Q28T\\MYHPSQL;Initial Catalog=LifsControlDb;Integrated Security=True");
                cn.Open();
                cmd = new SqlCommand(string.Format("Select IDLogIn, Contrasena from Usuarios where IDLogIn like '%{0}%' and Contrasena like '%{1}%'", user, pass),cn);

                dr = cmd.ExecuteReader();
                if((user.Equals(dr.GetString(0))) && pass.Equals(dr.GetString(1)))
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}