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
    public partial class frmPantallaABM : Form
    {
        public frmPantallaABM()
        {
            InitializeComponent();
        }
        string leerLinea;
        string[] separarDatos;
        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("Listadodeaseguradores.csv");

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
    }
}
