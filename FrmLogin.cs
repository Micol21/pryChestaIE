using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryChestaIE
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.KeyPreview = true; // Habilita la previsualización de teclas en el formulario
            this.KeyDown += new KeyEventHandler(FrmLogin_KeyDown); // Suscribe el método Form1_KeyDown al evento KeyDown

        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Cierra el formulario cuando se presiona la tecla ESCAPE
            }
        }
        public static string usuario;
        public static string contraseña;
        int cantidad = 0;
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ClsUsuario login = new ClsUsuario();
            login.ValidarUsuario(txtUsuario.Text, txtContraseña.Text);

            

            clsLogs objLogs = new clsLogs();


            if (login.estadoConexion== "Existe")
            {
                objLogs.LogInicioSesionExitoso();


                this.Hide();
                FrmPrincipal principal = new FrmPrincipal();
                principal.Show();
            }
            else
            {
                cantidad++;
                MessageBox.Show("Usuario o contraseña incorrecta, Ingreselos de nuevo porfavor");
                txtContraseña.Clear();
                txtUsuario.Clear();
                //objLogs.RegistroLogInicioSesionFallido();

                if (cantidad > 2)
                {
                    MessageBox.Show("Acceso bloqueado ");
                    btnIngresar.Enabled = false;
                    cantidad = 0;
                }

            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
