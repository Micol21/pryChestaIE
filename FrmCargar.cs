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
    public partial class FrmCargar : Form
    {
        public FrmCargar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            prbPorcentaje.Increment(13);
            lblPorcentaje.Text = prbPorcentaje.Value.ToString()+ "%";

            if(prbPorcentaje.Value == prbPorcentaje.Maximum)
            {
                timer1.Stop();
                this.Hide();
                FrmLogin ventanaprincipal = new FrmLogin();
                ventanaprincipal.Show();
            }

        }

        private void FrmCargar_Load(object sender, EventArgs e)
        {

        }
    }
}
