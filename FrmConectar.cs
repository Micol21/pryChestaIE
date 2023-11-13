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

        ClsDatosElClub objAccesoBD;//instaciar el objeto como una variable global

        public FrmConectar()
        {
            InitializeComponent();
            objAccesoBD = new ClsDatosElClub();//lo crea en memoria cuando se abre el formulario
            this.KeyPreview = true; // Habilita la previsualización de teclas en el formulario
            this.KeyDown += new KeyEventHandler(FrmConectar_KeyDown); // Suscribe el método Form1_KeyDown al evento KeyDown
        }

        private void FrmConectar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Cierra el formulario cuando se presiona la tecla ESCAPE
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

            objAccesoBD.TraerDatos(dgvSocios);
            


        }

        public void FrmConectar_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            objAccesoBD.BuscarSocioPorApellido(txtBuscar.Text,dgvSocios);
            txtBuscar.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text != "")//si la caja de texto no esta vacia 
            {
                objAccesoBD.RegistrarDatosDataSet(txtNombre.Text);
            }
            else 
            { MessageBox.Show("Ingrese el nombre que quiere registar!!"); }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void btnConectar_Click(object sender, EventArgs e)
        {
            
            objAccesoBD.ConectarBD();

            lblEstadoConectado.Text = objAccesoBD.estadoConexion;
        }
    }
}
