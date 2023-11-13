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
using System.Security.Cryptography.X509Certificates;

namespace pryChestaIE
{


   
    internal class ClsUsuario
    {
        OleDbConnection conexionBD;// se declara un objeto de tipo oledbconnection
        OleDbCommand comandoBD;//traer, borrar datos
        OleDbDataReader lectorBD;//leer de inicio a fin registro de datos
        OleDbDataAdapter adaptadorDS;
        DataSet objDataSet = new DataSet();


        string cadenaConexion = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:..\\..\\Resources\\BASE_USUARIOS.accdb";
        public string estadoConexion = "";

        public static bool login;


        
        
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
                    estadoConexion = "Error: " + ex.Message;//devuelve mensaje de error

                }
            }
        


        


        public void RegistroLogInicioSesion()
        {
            try
            {
                ConectarBD();
                //Creo una instancia de la clase OleDbCommand para ejecutar los comandos en la base de datos
                comandoBD = new OleDbCommand();
                //Establezco la conexión, para que cuando se ejecute el comando lo opere en la base de datos que debe hacerse
                comandoBD.Connection = conexionBD;
                //Establezco el tipo de comando, con este comando le indico que voy a leer una tabla en específica
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                //Le digo que tabla voy a traer 
                comandoBD.CommandText = "Logs";

                adaptadorDS = new OleDbDataAdapter(comandoBD);

                adaptadorDS.Fill(objDataSet, "Logs");

                DataTable objTabla = objDataSet.Tables["Logs"];
                DataRow nuevoRegistro = objTabla.NewRow();

                nuevoRegistro["Categoria"] = "Inicio Sesión";
                nuevoRegistro["FechaHora"] = DateTime.Now;
                nuevoRegistro["Descripcion"] = "Inicio exitoso";

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


        public void ValidarUsuario(string nombreUser, string passUser)
        {
            try
            {
                ConectarBD();
                
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "Usuarios";

                lectorBD = comandoBD.ExecuteReader();

                if (lectorBD.HasRows)
                {
                    while (lectorBD.Read())
                    {
                        if (lectorBD[1].ToString() == nombreUser && lectorBD[2].ToString() == passUser)
                        {
                            estadoConexion = "Existe";
                            break;
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





