using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryChestaIE
{
    public partial class FrmLista : Form
    {
        public FrmLista()
        {
            InitializeComponent();
        }
        string leerLinea;
        string[] separarDatos;
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("baseproveedores.csv");

            leerLinea = sr.ReadLine();
            separarDatos = leerLinea.Split(';');

            for (int indice = 0; indice < separarDatos.Length; indice++)
            {
                grilla.Columns.Add(separarDatos[indice], separarDatos[indice]);
            }

            while (sr.EndOfStream == false)
            {
                leerLinea = sr.ReadLine();
                separarDatos = leerLinea.Split(';');
                grilla.Rows.Add(separarDatos);
            }

            sr.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal form1 = new FrmPrincipal();
            form1.Show();
        }
    }
}
