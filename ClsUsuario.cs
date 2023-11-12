using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.CodeDom.Compiler;
using System.Data.Odbc;

namespace pryChestaIE
{


   
    internal class ClsUsuario
    {
        OleDbConnection conexionusuario = new OleDbConnection();
        OleDbCommand comandousuario = new OleDbCommand();
        OleDbDataReader lectorusuario;

        OleDbDataAdapter adaptadorBD;
        DataSet objDS = new DataSet();

        

        public string datosTabla = "";

        public string estadoConexion = "";
        string rutaArchivo;

        public static bool login;


        public ClsUsuario()
        {
            try
            {
                rutaArchivo = @"..\\..\\Resources\\BASE_USUARIOS.accdb";

                conexionusuario = new OleDbConnection();
                conexionusuario.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + rutaArchivo;
                conexionusuario.Open();

                 

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

                //Creo una instancia de la clase OleDbCommand para ejecutar los comandos en la base de datos
                comandousuario = new OleDbCommand();
                //Establezco la conexión, para que cuando se ejecute el comando lo opere en la base de datos que debe hacerse
                comandousuario.Connection = conexionusuario;
                //Establezco el tipo de comando, con este comando le indico que voy a leer una tabla en específica
                comandousuario.CommandType = System.Data.CommandType.TableDirect;
                //Le digo que tabla voy a traer 
                comandousuario.CommandText = "Usuarios";

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
                
                conexionusuario.Open();
                comandousuario = new OleDbCommand();

                comandousuario.Connection = conexionusuario;
                comandousuario.CommandType = System.Data.CommandType.TableDirect;
                comandousuario.CommandText = "Usuarios";

                lectorusuario = comandousuario.ExecuteReader();

                if (lectorusuario.HasRows)
                {
                    while (lectorusuario.Read())
                    {
                        if (lectorusuario[1].ToString() == FrmLogin.usuario && lectorusuario[2].ToString() == FrmLogin.contraseña)
                        {
                            login  = true;
                            break;
                        }
                        else
                        {
                            login = false;
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





