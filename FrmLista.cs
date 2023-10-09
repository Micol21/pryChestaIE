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
        
        public void btnMostrar_Click(object sender, EventArgs e)
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

            string DatoLeido;

           // StreamReader AD = new StreamReader("Nuevo Proveedor");//Abrir AD 
            //DatoLeido = AD.ReadLine();//Leer AD
            //while (DatoLeido != null)
           // {
                
               // grilla.Rows.Add(DatoLeido);
                //DatoLeido = AD.ReadLine();//Leer AD
           // }
            //AD.Close();//Cerrar AD
            //AD.Dispose();//Liberar el objeto 



        }

        public void Listar(DataGridView grilla)
        {
            string DatoLeido;
            StreamReader AD = new StreamReader("Nuevo Proveedor");//Abrir AD 
            DatoLeido = AD.ReadLine();//Leer AD
            while (DatoLeido != null)
            {
                grilla.Rows.Add(DatoLeido);
                DatoLeido = AD.ReadLine();//Leer AD
            }
            AD.Close();//Cerrar AD
            AD.Dispose();//Liberar el objeto 
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal form1 = new FrmPrincipal();
            form1.Show();
        }

        public void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
