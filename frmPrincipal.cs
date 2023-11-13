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
            this.KeyPreview = true; // Habilita la previsualización de teclas en el formulario
            this.KeyDown += new KeyEventHandler(FrmLista_KeyDown); // Suscribe el método Form1_KeyDown al evento KeyDown
        }

        private void FrmLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Cierra el formulario cuando se presiona la tecla ESCAPE
            }
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

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pantallaABMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLista form1 = new FrmLista();
            form1.Show();
        }

        private void eLCLUBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmConectar form1 = new FrmConectar();
            form1.Show();
        }
    }
}
