using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Security.Cryptography.X509Certificates;

namespace pryChestaIE
{
    internal class clsLogs
    {
        OleDbConnection conexionlogs;
        OleDbCommand comandologs;
        OleDbDataReader lectorlogs;

        OleDbDataAdapter adaptadorlogs;
        DataSet objDS;

        string rutaArchivo;
        public string estadoConexion;

        string cadenaConexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\BASE_USUARIOS.accdb";

        public string datosTabla = "";

        public void ConectarBD()
        {
            try
            {
                conexionlogs = new OleDbConnection();
                conexionlogs.ConnectionString = cadenaConexion;
                conexionlogs.Open();
                estadoConexion = "Conectado";
            }
            catch (Exception ex) 
            { estadoConexion = "Error: " + ex.Message; }
        }




        public void LogInicioSesionExitoso()
        {
            try
            {
                ConectarBD();
                comandologs = new OleDbCommand();

                comandologs.Connection = conexionlogs;
                comandologs.CommandType = System.Data.CommandType.TableDirect;
                comandologs.CommandText = "Logs";
                //Creo el objeto DataAdapter pasando como parámetro el objeto comando que quiero vincular
                adaptadorlogs = new OleDbDataAdapter(comandologs);
                //Ejecuto la lectura de la tabla y almaceno su contenido en el dataAdapter
                adaptadorlogs.Fill(objDS, "Logs");
                //Obtengo una referencia a la tabla
                DataTable objTabla = objDS.Tables["Logs"];

                DataRow nuevoRegistro = objTabla.NewRow();

                //Asigno los valores a todos los campos del DataRow
                nuevoRegistro["Categoria"] = "Inicio Sesión";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Descripcion"] = "Inicio exitoso";

                //Agrego el DataRow a la tabla
                objTabla.Rows.Add(nuevoRegistro);

                //Creo el objeto OledBCommandBuilder pasando como parámetro el DataAdapter
                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorlogs);

                //Actualizo la base con los cambios realizados
                adaptadorlogs.Update(objDS, "Logs");

                estadoConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }


            
        }

        public void RegistroLogInicioSesionFallido()
        {
            try
            {

                comandologs = new OleDbCommand();
                


                comandologs.Connection = conexionlogs;
                comandologs.CommandType = System.Data.CommandType.TableDirect;
                comandologs.CommandText = "Logs";

               

                adaptadorlogs = new OleDbDataAdapter(comandologs);

                adaptadorlogs.Fill(objDS, "Logs");

                DataTable objTabla = objDS.Tables["Logs"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Categoria"] = "Inicio Sesión";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Descripcion"] = "Inicio fallido";
                nuevoRegistro["Usuario"] = FrmLogin.usuario;

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorlogs);
                adaptadorlogs.Update(objDS, "Logs");

                estadoConexion = "Registro fallido de log";
            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }
        }
    }
}
