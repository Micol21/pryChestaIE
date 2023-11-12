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
        }
        public static string usuario;
        public static string contraseña;
        int cantidad = 0;
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            contraseña = txtContraseña.Text;

            clsLogs objLogs = new clsLogs();


            if (ClsUsuario.login == true)
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
                //objLogs.RegistroLogInicioSesionFallido();

                if (cantidad > 3)
                {
                    MessageBox.Show("Acceso bloqueado ");
                    btnIngresar.Enabled = false;
                    cantidad = 0;
                }

            }
        }
    }
}
