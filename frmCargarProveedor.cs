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
    public partial class frmCargarProveedor : Form
    {
        public frmCargarProveedor()
        {
            InitializeComponent();
        }

        public void btnCargar_Click(object sender, EventArgs e)

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

            
            
            StreamReader sr = new StreamReader("baseproveedores.csv");


            string leerLinea;
            string[] separarDatos;
            leerLinea = sr.ReadLine();
            

            separarDatos = leerLinea.Split(';');


            for (int indice = 0; indice < separarDatos.Length; indice++)
            {
                dgvDatos.Columns.Add(separarDatos[indice], separarDatos[indice]);
                

            }
            

            while (sr.EndOfStream == false)
            {
                leerLinea = sr.ReadLine();
                separarDatos = leerLinea.Split(';');
                dgvDatos.Rows.Add(separarDatos);
                
            }
            
            sr.Close();

            



        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal form1 = new FrmPrincipal();
            form1.Show();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Int32 n = dgvDatos.CurrentCell.RowIndex;
            dgvDatos.Rows[n].SetValues(txtNumero.Text, txtEntidad.Text, txtApertura.Text, txtExpediente.Text, txtJuzgado.Text, txtJurisdiccion.Text, txtDireccion, txtLiquidador.Text);
            MessageBox.Show("Fila modificada exitosamente");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // x es el número de fila seleccionado en la grilla
            Int32 x = dgvDatos.CurrentCell.RowIndex;
            dgvDatos.Rows.RemoveAt(x);
            MessageBox.Show("Fila eliminada ");
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
