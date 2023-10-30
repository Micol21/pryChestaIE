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


   
    internal class ClsUsuario
    {
        OleDbConnection conexionusuario;
        OleDbCommand comandousuario;
        OleDbDataReader lectorusuario;

        OleDbDataAdapter adaptadorBD;
        DataSet objDS;

        string rutaArchivo;
        public string estadoConexion;

        public ClsUsuario()
        {
            try
            {
                rutaArchivo = @"..\\..\\Resources\\BaseProveedores.accdb";

                conexionusuario = new OleDbConnection();
                conexionusuario.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaArchivo;
                conexionusuario.Open();

                objDS = new DataSet();

                estadoConexion = "Conectado";
            }
            catch (Exception error)
            {
                estadoConexion = error.Message;
            }
        }


        public void RegistroLogInicioSesion()
        {
            try
            {
                comandousuario = new OleDbCommand();

                comandousuario.Connection = conexionusuario;
                comandousuario.CommandType = System.Data.CommandType.TableDirect;
                comandousuario.CommandText = "Logs";

                adaptadorBD = new OleDbDataAdapter(comandousuario);

                adaptadorBD.Fill(objDS, "Logs");

                DataTable objTabla = objDS.Tables["Logs"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Categoria"] = "Inicio Sesión";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Descripcion"] = "Inicio exitoso";

                objTabla.Rows.Add(nuevoRegistro);

                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(objDS, "Logs");

                estadoConexion = "Registro exitoso de log";
            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }

        }


        public void ValidarUsuario(string nombreUser, string passUser)
        {
            try
            {
                comandousuario = new OleDbCommand();

                comandousuario.Connection = conexionusuario;
                comandousuario.CommandType = System.Data.CommandType.TableDirect;
                comandousuario.CommandText = "Usuario";

                lectorusuario = comandousuario.ExecuteReader();

                if (lectorusuario.HasRows)
                {
                    while (lectorusuario.Read())
                    {
                        if (lectorusuario[1].ToString() == nombreUser && lectorusuario[2].ToString() == passUser)
                        {
                            estadoConexion = "Usuario EXISTE";
                        }
                    }
                }

            }
            catch (Exception error)
            {

                estadoConexion = error.Message;
            }
        }
}


}





