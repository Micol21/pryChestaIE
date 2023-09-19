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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void cargarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            btnCargarProveedor form1 = new btnCargarProveedor();
            form1.Show();
        }

        private void mostrarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMostrarProveedor form1 = new frmMostrarProveedor();
            form1.Show();
        }
    }
}
