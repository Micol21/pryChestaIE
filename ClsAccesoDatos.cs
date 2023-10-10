using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace pryChestaIE
{
    internal class ClsAccesoDatos
    {
        

        //Abrir la base de datos 
        public void AbrirBD()


        {

            try
            {
                OleDbConnection objcnn = new OleDbConnection();
                OleDbCommand objcmd = new OleDbCommand();
                OleDbDataReader objdr;
                // asignar la cadena al objeto conexión
                string conexionuno = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = .../.../Resources/BaseProveedores.accdb";
                // definir la cadena de conexión
                objcnn.ConnectionString = conexionuno;

                // abrir la conexión con la base de datos
                objcnn.Open();

                // establecer las propiedades al objeto comando
                objcmd.Connection = objcnn;
                objcmd.CommandType = CommandType.TableDirect;
                objcmd.CommandText = "users";// nombrede la tabla a leer
                                             // ejecutar la lectura de la tabla con un objetoDataReader
                objdr = objcmd.ExecuteReader();

                if (objdr.HasRows)
                {
                    string datos = "";
                    while (objdr.Read())// leer mientras existanregistros
                    {
                        datos += objdr.GetString(0) + ", " + objdr.GetString(1) + "\r\n";
                    }
                    MessageBox.Show(datos, "Tabla de Cantantes– DataReader");

                }
                objcnn.Close();
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
