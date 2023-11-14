using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;//permitir abrir archivos de base de datos
using System.IO;// crear leer archivos
using System.Windows.Forms;
using System.Data;//para llamar al data set 
using System.Data.Odbc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pryChestaIE
{
    internal class ClsDatosElClub
    {
        OleDbConnection conexionBD ;// se declara un objeto de tipo oledbconnection
        OleDbCommand comandoBD;//traer, borrar datos
        OleDbDataReader lectorBD;//leer de inicio a fin registro de datos
        OleDbDataAdapter adaptadorDS;
        DataSet objDataSet = new DataSet();


        string cadenaConexion = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:..\\..\\Resources\\EL_CLUB.accdb";
        public string estadoConexion = "";
        public string errores;
        public string datosextraidos;
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

                estadoConexion = "Error: " + ex.Message;//devuelve mensaje de error 
            }
        }

        public void TraerDatos(DataGridView grilla)
        {
            try
            {
                ConectarBD();
                comandoBD = new OleDbCommand();// primero crearlo en la memoria 
                comandoBD.Connection = conexionBD;//vincular comando con la conexion 
                comandoBD.CommandType = System.Data.CommandType.TableDirect;//que tipo de dato quiero que me traiga (una tabla completa)
                comandoBD.CommandText = "SOCIOS";//que tabla traigo

                lectorBD = comandoBD.ExecuteReader();//trae la tabla socios y lo mete en el lector 

                grilla.Columns.Add("Nombre","Nombre");//el primero para la grilla el segundo para el codigo
                grilla.Columns.Add("Apellido", "Apellido");
                grilla.Columns.Add("Nacionalidad", "Nacionalidad");
                grilla.Columns.Add("Edad", "Edad");
                
                
                grilla.Columns.Add("Ingreso", "Ingreso");
                grilla.Columns.Add("Puntaje", "Puntaje");
                grilla.Columns.Add("Estado", "Estado");






                while (lectorBD.Read())
                {//si el lector puede leer hay datos, lee un registro (conjunto de datos heterogeneos) 
                    {
                        grilla.Rows.Add(lectorBD[1], lectorBD[2], lectorBD[3], lectorBD[4], lectorBD[6], lectorBD[7],"Activo");
                    }


                }
            }catch (Exception ex)
            {
                errores = ex.Message;
            }
            

        }

        public void TraerDatosDataSet(DataGridView grilla)
        {//Realiza lo mismo que el data reader pero con el dataset
            try
            {
                ConectarBD();
                comandoBD = new OleDbCommand();// primero crearlo en la memoria 
                comandoBD.Connection = conexionBD;//vincular comando con la conexion 
                comandoBD.CommandType = System.Data.CommandType.TableDirect;//que tipo de dato quiero que me traiga (una tabla completa)
                comandoBD.CommandText = "SOCIOS";//que tabla traigo

                adaptadorDS = new OleDbDataAdapter(comandoBD);//crea el objeto dataadapter pasando como parametro el objeto comando que queremos vincular 

                adaptadorDS.Fill(objDataSet);//traer socios y cargarlo en objeto data set

                if (objDataSet.Tables[0].Rows.Count > 0)//si tiene datos

                {

                    grilla.Columns.Add("ID", "ID");
                    grilla.Columns.Add("Nombre", "Nombre");
                    grilla.Columns.Add("Apellido", "Apellido");

                    foreach (DataRow fila in objDataSet.Tables[0].Rows)
                    {
                        //datosextraidos += fila[1]+ "\n";//trae los datos de la fila 1 concatenando

                        grilla.Rows.Add(fila[0], fila[1], fila[2]);
                    }
                }
            }
            catch (Exception ex)
            {
                errores = ex.Message;
            }
            

        }


        public void RegistrarDatosDataSet(string nombre)
        {
            try
            {
                ConectarBD();
                comandoBD = new OleDbCommand();// primero crearlo en la memoria 
                comandoBD.Connection = conexionBD;//vincular comando con la conexion 
                comandoBD.CommandType = System.Data.CommandType.TableDirect;//que tipo de dato quiero que me traiga (una tabla completa)
                comandoBD.CommandText = "SOCIOS";//que tabla traigo

                adaptadorDS = new OleDbDataAdapter(comandoBD);//crea el objeto dataadapter pasando como parametro el objeto comando que queremos vincular 
                //lo que pide el comando se lo pasa al adapter 
                adaptadorDS.Fill(objDataSet);//traer socios y cargarlo en objeto data set

               DataTable tablagrabar = objDataSet.Tables[0];//crea un objeto datatable para crear una nueva fila  y que se cargue con lo tabla socios que esta en el dataset
                DataRow dr = tablagrabar.NewRow();//crea un nuevo DataRow con los campos de
                                                  // la tabla pero con su contenido vacío, es decir sin valores iniciales.

                dr[1] = nombre;//asiganamos los valores al campo de datarow
                tablagrabar.Rows.Add(dr);//agregamos el datarow a la tabla socios
                OleDbCommandBuilder constructor = new OleDbCommandBuilder(adaptadorDS);//// creamos el objeto OledBCommandBuilder pasando como parámetro el DataAdapter
                adaptadorDS.Update(objDataSet);// actualizamos la base con los cambios realizados
            }
            catch (Exception ex)
            {
                errores = ex.Message;
            }


        }

        public void BuscarSocioPorApellido(string apellido,DataGridView grilla)
        {
            try
            {
                ConectarBD();
                comandoBD = new OleDbCommand();

                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = System.Data.CommandType.TableDirect;
                comandoBD.CommandText = "SOCIOS";

                lectorBD = comandoBD.ExecuteReader();

                

                if (lectorBD.HasRows)
                {
                    while (lectorBD.Read())
                    {
                        if (lectorBD[2].ToString() == apellido)
                        {
                            
                            grilla.Rows.Clear();
                            grilla.Rows.Add( lectorBD[1], lectorBD[2], lectorBD[3], lectorBD[4], lectorBD[6], lectorBD[7]);
                        }
                        
                    }

                   
                }
            }
            catch (Exception error)
            {
                estadoConexion = "Error:" + error.Message;
            }
        }


    }
}
