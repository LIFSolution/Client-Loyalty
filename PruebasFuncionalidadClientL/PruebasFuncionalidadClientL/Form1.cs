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
    public partial class Form1 : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user = "";//RECIBIRA EL USUARIO INGRESADO
            String pass = ""; //RECIBIRA LA CONTRASEÑA
            user = this.textBox1.Text;//ramd777
            pass = textBox2.Text;     //7189rafa

            if (verificarLogIn(user, pass) == true)
            {
                //DIRIGIRSE A LA SIGUIENTE PAGINA
                MessageBox.Show("¡CORRECTO!");
            }
            else
            {
                //Response.Write("<script>window.alert('Usuario o Contraseña Incorrecta');</script>");
                MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTO!");
            }
        }

        public bool verificarLogIn(String usu, String pass)
        {
            try
            {
                int bandera = 0;
                cn = new SqlConnection("Data Source=LAPTOP-F8V8Q28T\\MYHPSQL;Initial Catalog=LifsControlDb;Integrated Security=True");
                cn.Open();
                cmd = new SqlCommand(string.Format("Select * From Usuarios Where Usuario = '{0}' and Contrasena = '{1}'", usu, pass), cn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    bandera = 3;
                }

                cn.Close();
                if(bandera != 0)
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
