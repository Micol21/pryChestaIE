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
            frmCargarProveedor form1 = new frmCargarProveedor();
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
