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
    public partial class IngresoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //**************************************************************************** ESTO VA DENTRO DEL BOTON /////////////////////////////////////////////////////////////////////

            String usuario = "";//para almacenar el texto que esta ingresando la persona...
            String nombres = "";
            String apellidos = "";
            String contrasena = "";
            int rol = 0;

            String rolSelecto = "";//comboBox1.SelectedItem.ToString()
            switch (rolSelecto)//puede ser combobox o checkbox o radiobutton... la onda es que elija de algun lugar
            {
                case "Administrador"://podrian existir mas roles
                    rol = 1;
                    break;
                case "Empleado":
                    rol = 2;
                    break;
                case "Cliente":
                    rol = 3;
                    break;
                default:
                    break;
            }

            almacenaUsuario(usuario, nombres, apellidos, contrasena, rol, 1, 1);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }


        public void almacenaUsuario(String user, String nombre, String apell, String pass, int rol_id, int empresa_id, int is_active)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F8V8Q28T\\MYHPSQL;Initial Catalog=LifsControlDb;Integrated Security=True");
                con.Open();
                string commandString = "INSERT INTO Usuarios(Usuario, Nombres, Apellidos, Contrasena, RollID, EmpresaID, IsActive) values('" + user + "', '" + nombre + "', '" 
                                        + apell + "', '" + pass + "', " + rol_id + ", " + empresa_id + ", " + is_active + ")";

                SqlCommand cmd = new SqlCommand(commandString, con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
        }
    }
}