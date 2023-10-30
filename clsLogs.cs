using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Data.OleDb;

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
        public void LogInicioSesion()
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
                nuevoRegistro["Descripcion"] = "Inicio exitoso";

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorlogs);
                adaptadorlogs.Update(objDS, "Logs");

                estadoConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }
        }
    }
}
