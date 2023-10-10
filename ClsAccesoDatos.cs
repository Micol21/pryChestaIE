using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryChestaIE
{
    internal class ClsAccesoDatos
    {
        OleDbConnection conexion;

        //Abrir la base de datos 
        public void AbrirBD()


        {
            try
            {
                conexion = new OleDbConnection("@Provider = Microsoft.ACE.OLEDB.12.0; Data Source = .../.../Resources/BaseProveedores.accdb");

                conexion.Open();
            }
            catch (Exception ex ){
                //iria un mensaje
                MessageBox.Show(ex.Message);
                throw;
            }
            
        }
       
        //Validar usuario 
    }
}
