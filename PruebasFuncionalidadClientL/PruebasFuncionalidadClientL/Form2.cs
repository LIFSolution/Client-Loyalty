using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PruebasFuncionalidadClientL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usuario = this.textBox1.Text;
            String nombres = textBox2.Text;
            String apellidos = textBox3.Text;
            String contrasena = textBox4.Text;
            int rol = 0;

            switch (comboBox1.SelectedItem.ToString())
            {
                case "Administrador":
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
            
        }

        public bool almacenaUsuario(String user, String nombre, String apell, String pass, int rol_id, int empresa_id, int is_active)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F8V8Q28T\\MYHPSQL;Initial Catalog=LifsControlDb;Integrated Security=True");
                con.Open();
                string commandString = "INSERT INTO Usuarios(Usuario, Nombres, Apellidos, Contrasena, RollID, EmpresaID, IsActive) values('"+user+ "', '" + nombre + "', '" + apell + "', '" + pass + "', " + rol_id + ", " + empresa_id + ", " + is_active + ")";

                SqlCommand cmd = new SqlCommand(commandString, con);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'lifsControlDbDataSet.Roles' Puede moverla o quitarla según sea necesario.
            

        }
    }
}
