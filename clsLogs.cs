using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace pryChestaIE
{
    internal class clsLogs
    {
        OleDbConnection conexionBD;// se declara un objeto de tipo oledbconnection
        OleDbCommand comandoBD;//traer, borrar datos
        OleDbDataReader lectorBD;//leer de inicio a fin registro de datos
        OleDbDataAdapter adaptadorDS;
        DataSet objDataSet = new DataSet();

        
        public string estadoConexion;

        string cadenaConexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\BASE_USUARIOS.accdb";

        public string datosTabla = "";

        public void ConectarBD()
        {
            try
            {
                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = cadenaConexion;
                conexionBD.Open();
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

                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;

                //Establezco el tipo de comando, con este comando le indico que voy a trabajar con una tabla específica
                comandoBD.CommandType = System.Data.CommandType.TableDirect;

                //Le digo que tabla quiero traer
                comandoBD.CommandText = "Logs";

                //Creo el objeto DataAdapter pasando como parámetro el objeto comando que quiero vincular
                adaptadorDS = new OleDbDataAdapter(comandoBD);

                //Ejecuto la lectura de la tabla y almaceno su contenido en el dataAdapter
                adaptadorDS.Fill(objDataSet, "Logs");

                //Obtengo una referencia a la tabla

                DataTable objTabla = objDataSet.Tables["Logs"];

                //Creo el nuevo DataRow con la estructura de campos de la tabla de la cual quiero traer los datos
                DataRow nuevoRegistro = objTabla.NewRow();

                //Asigno los valores a todos los campos del DataRow
                nuevoRegistro["Categoria"] = "Inicio Sesión";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Descripcion"] = "Inicio exitoso";
                nuevoRegistro["Usuario"] = FrmLogin.usuario;

                //Agrego el DataRow a la tabla
                objTabla.Rows.Add(nuevoRegistro);


                //Creo el objeto OledBCommandBuilder pasando como parámetro el DataAdapter
                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorDS);

                //Actualizo la base con los cambios realizados
                adaptadorDS.Update(objDataSet, "Logs");

                estadoConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }


            
        }

        

        public void LogInicioSesionFallido()
        {
            try
            {
                ConectarBD();

                comandoBD = new OleDbCommand();


                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Logs";

                adaptadorDS = new OleDbDataAdapter(comandoBD);

                adaptadorDS.Fill(objDataSet, "Logs");

                DataTable objTabla = objDataSet.Tables["Logs"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Categoria"] = "Inicio Sesión";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Descripcion"] = "Inicio fallido";
                nuevoRegistro["Usuario"] = FrmLogin.usuario;

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorDS);
                adaptadorDS.Update(objDataSet, "Logs");

                estadoConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }
        }
    }
}
