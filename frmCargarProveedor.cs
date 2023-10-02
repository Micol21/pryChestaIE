using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pryChestaIE
{
    public partial class btnCargarProveedor : Form
    {
        public btnCargarProveedor()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            StreamWriter objsw = new StreamWriter("Nuevo Proveedor", true);
            objsw.WriteLine(txtNumero.Text);
            objsw.WriteLine(txtApertura.Text);
            objsw.WriteLine(txtJuzgado.Text);
            objsw.WriteLine(txtDireccion.Text);
            objsw.WriteLine(txtEntidad.Text);
            objsw.WriteLine(txtExpediente.Text);
            objsw.WriteLine(txtJurisdiccion.Text);
            objsw.WriteLine(txtLiquidador.Text);


            MessageBox.Show("Cargado Correctamente");
            txtNumero.Text = " ";
            txtApertura.Text = " ";
            txtJuzgado.Text = " ";
            txtDireccion.Text = " ";
            txtEntidad.Text = " ";
            txtExpediente.Text = " ";
            txtJurisdiccion.Text = " ";
            txtLiquidador.Text = " ";

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal form1 = new FrmPrincipal();
            form1.Show();

        }
    }
}
