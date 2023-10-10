using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryChestaIE
{
    public partial class FrmConectar : Form
    {
        public FrmConectar()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            ClsAccesoDatos obLogin = new ClsAccesoDatos();

            obLogin.AbrirBD();
            // definir la cadena de conexión


        }
    }
}
