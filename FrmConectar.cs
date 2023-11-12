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
           

            


        }

        public void FrmConectar_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
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

        private void btnConectar_Click(object sender, EventArgs e)
        {
            ClsDatosElClub objAccesoBD = new ClsDatosElClub();
            objAccesoBD.ConectarBD();

            lblEstadoConectado.Text = objAccesoBD.estadoConexion;
        }
    }
}
