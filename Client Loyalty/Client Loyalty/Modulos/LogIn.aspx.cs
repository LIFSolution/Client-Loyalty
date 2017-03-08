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
            //CADENA DE CONECCION     Data Source=LAPTOP-F8V8Q28T\MYHPSQL;Initial Catalog=LifsControlDb;Integrated Security=True

        }

        public bool verificarLogIn(String user, String pass)
        {
            try
            {
                cn = new SqlConnection("Data Source=LAPTOP-F8V8Q28T\\MYHPSQL;Initial Catalog=LifsControlDb;Integrated Security=True");
                cn.Open();
            }
            catch(Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}