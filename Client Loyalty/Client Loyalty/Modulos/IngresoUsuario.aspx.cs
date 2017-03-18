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
        SqlConnection cn = new SqlConnection("Data Source=LAPTOP-F8V8Q28T\\MYHPSQL;Initial Catalog=LifsControlDb;Integrated Security=True");
        List<String> lista = new List<String>();
        int bandera1 = 0;

        ////**************************************************************************** ESTO VA DENTRO DEL BOTON /////////////////////////////////////////////////////////////////////

        //String usuario = "";//para almacenar el texto que esta ingresando la persona...
        //String nombres = "";
        //String apellidos = "";
        //String contrasena = "";
        //String monto = "";// textBox5.Text;
        //int rol = 0;
        //int codigoTipoCuenta = 0;
        //String rolSelecto = "";// comboBox1.SelectedItem.ToString(); PUEDE SER COMBOBOX O LO QUE SEA LA ONDA ES QUE ELIJA ALGO
        //String tipoCuenta = "";

        //switch (rolSelecto)//   3 ROLES POR DEFECTO...
        //{
        //    case "Administrador":
        //        rol = 1;
        //        break;
        //    case "Empleado":
        //        rol = 2;
        //        break;
        //    case "Cliente":
        //        rol = 3;
        //        break;
        //    default:
        //        break;
        //}

        //if (bandera1 == 1)
        //{
        //    tipoCuenta = "";// comboBox2.SelectedItem.ToString(); DE NUEVO PUEDE SER COMBO BOX O LO QUE SEA
        //    for (int i = 0; i < lista.Count; i++)
        //    {
        //        string[] j = lista[i].Split(',');
        //        if (tipoCuenta.Equals(j[1]))
        //        {
        //            codigoTipoCuenta = Int32.Parse(j[0]);
        //        }
        //    }
        //}

        //if (obtieneCodigoUsuario(usuario, "", "", "", 1) != 0)
        //{
        //    //EL USUARIO YA EXISTE
        //}
        //else
        //{
        //    almacenaUsuario(usuario, nombres, apellidos, contrasena, rol, 1, 1);
        //}

        //int codigoUsuario = obtieneCodigoUsuario(usuario, nombres, apellidos, contrasena, 2);
        //almacenaCuenta(codigoUsuario, codigoTipoCuenta, monto, 1);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Page_Load(object sender, EventArgs e)
        {
            //comboBox1.SelectedIndex = 0;
            llenaTipoCuentas();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////// Hace falta el ingreso del codigo, la creacion del codigo de barras
        ////////////////////////////////////////////////////////////////////////////////////////////

        public void llenaTipoCuentas()
        {
            if (verificaTipoCuenta() == true)
            {
                for (int a = 0; a < lista.Count; a++)
                {
                    string[] j = lista[a].Split(',');
                    //comboBox2.Items.Add(j[1]);
                }
                //comboBox2.SelectedIndex = 0;
                bandera1 = 1;
            }
            else
            {
                //comboBox2.Visible = false;
                //label6.Visible = false;
                bandera1 = 0;
            }
        }
        
        public void almacenaUsuario(String user, String nombre, String apell, String pass, int rol_id, int empresa_id, int is_active)
        {
            try
            {
                cn.Open();
                string commandString = "INSERT INTO Usuarios(Usuario, Nombres, Apellidos, Contrasena, RollID, EmpresaID, IsActive) values('" + user + "', '" + nombre + "', '"
                                        + apell + "', '" + pass + "', " + rol_id + ", " + empresa_id + ", " + is_active + ")";

                SqlCommand cmd = new SqlCommand(commandString, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public bool verificaTipoCuenta()
        {
            try
            {
                int bandera = 0;
                cn.Open();
                SqlCommand cmd = new SqlCommand(string.Format("Select * From TipoCuentas"), cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    String line = dr.GetInt32(0).ToString() + "," + dr.GetString(1).ToString();
                    lista.Add(line);
                    bandera++;
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

        public int obtieneCodigoUsuario(String usuario, String nombre, String apellido, String contrasena, int decide)//1 para comprobar existencia de usuario, 2 para obtener codigo de usuario
        {
            try
            {
                int line = 0;
                cn.Open();
                SqlCommand cmd;

                if (decide == 1)
                {
                    cmd = new SqlCommand(string.Format("Select * From Usuarios WHERE Usuario = '{0}'", usuario), cn);
                }
                else
                {
                    cmd = new SqlCommand(string.Format("Select * From Usuarios WHERE Usuario = '{0}' and Nombres = '{1}' and Apellidos = '{2}' and Contrasena = '{3}'", usuario, nombre, apellido, contrasena), cn);
                }

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    line = dr.GetInt32(0);
                }

                cn.Close();
                if (line != 0)
                {
                    return line;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 0;
        }

        public void almacenaCuenta(int id_user, int id_cuenta, String monto, int is_active)
        {
            try
            {
                cn.Open();
                string commandString = "INSERT INTO Cuentas (UsuarioID, TipoCuentaID, Monto, IsActive) values(" + id_user + ", " + id_cuenta + ", '" + monto + "', " + is_active + ")";

                SqlCommand cmd = new SqlCommand(commandString, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}