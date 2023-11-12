using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;//permitir abrir archivos de base de datos
using System.IO;// crear leer archivos
using System.Windows.Forms;
using System.Data;

namespace pryChestaIE
{
    internal class ClsDatosElClub
    {
        OleDbConnection conexionBD;// se declara un objeto de tipo oledbconnection
        string cadenaConexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\EL_CLUB.accdb";
        public string estadoConexion = "";

        public void ConectarBD()
        {
            try
            {
                conexionBD = new OleDbConnection();//instancio un objeto en memoria  de esa clase 
                conexionBD.ConnectionString = cadenaConexion;// a donde esta la conexion
                conexionBD.Open();//abro la base
                estadoConexion = "Conectado";
            }

            catch (Exception ex)
            {
                //iria un mensaje

                estadoConexion = "Error: " + ex.Message;
            }
        }
    }
}
