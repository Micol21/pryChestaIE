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
        OleDbConnection conexionBD;
        OleDbCommand comandoBD;
        OleDbDataReader lectorBD;
        DataSet objds = new DataSet();
        OleDbDataAdapter objda;


        string cadenaConexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\BaseProveedores.accdb";

        public string estadoConexion = "";

        public string datosTabla = "";


        public void AbrirBD()

           {

            try
            {
                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = cadenaConexion;
                conexionBD.Open();
                estadoConexion = "Conectado";
            }
        
            catch (Exception ex ){
                //iria un mensaje
                
             estadoConexion = "Error: " + ex.Message;
            }
            
        }

        public void TraerDatos(DataGridView grilla)
        {
            comandoBD = new OleDbCommand();

            comandoBD.Connection = conexionBD;
            comandoBD.CommandType = System.Data.CommandType.TableDirect;  //q tipo de operacion quiero hacer y que me traiga TODA la tabla con el tabledirect
            comandoBD.CommandText = "Users"; //Que tabla traigo

            lectorBD = comandoBD.ExecuteReader(); //abre la tabla y muestra por renglon
            grilla.Columns.Add("Nombre", "Nombre");
            grilla.Columns.Add("Apellido", "Apellido");
            grilla.Columns.Add("Pais", "Pais");

            if (lectorBD.HasRows) //SI TIENE FILAS
            {
                while (lectorBD.Read()) //mientras pueda leer, mostrar (leer)
                {
                    datosTabla += "-" + lectorBD[0]; //dato d la comlumna 0
                    grilla.Rows.Add(lectorBD[0], lectorBD[1], lectorBD[2]);
                }

            }

        }


        public void BuscarPorID(int codigo)
        {

            comandoBD = new OleDbCommand();

            comandoBD.Connection = conexionBD;
            comandoBD.CommandType = System.Data.CommandType.TableDirect;  //q tipo de operacion quierp hacer y que me traiga TOD la tabla con el tabledirect
            comandoBD.CommandText = "SOCIOS"; //Que tabla traigo

            lectorBD = comandoBD.ExecuteReader(); //abre la tabla y muestra por renglon



            if (lectorBD.HasRows) //SI TIENE FILAS
            {
                bool Find = false;
                while (lectorBD.Read()) //mientras pueda leer, mostrar (leer)
                {
                    if (int.Parse(lectorBD[0].ToString()) == codigo)
                    {

                        //datosTabla += "-" + lectorBD[0]; //dato d la comlumna 0
                        MessageBox.Show("Cliente Existente" + lectorBD[0], "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Find = true;
                        break;
                    }

                }
                if (Find = false)
                {

                    MessageBox.Show("NO Existente" + lectorBD[0], "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                
            }
            
        }
        public void nuevoregistro(string Nombre,string Password)
        {



            // obtenemos una referencia a la tabla de users
            DataTable dt = new DataTable();
                dt = objds.Tables["Users"];
            // creamos el nuevo DataRow con la estructura de campos de la tabla users
            DataRow dr = dt.NewRow();

            // asignamos los valores a todos los campos del DataRow
            dr["Nombre"] = Nombre;
            dr["ID"] = Password;
            // agregamos el DataRow a la tabla de Cantantes
            dt.Rows.Add(dr);

            // creamos el objeto OledBCommandBuilder pasando como parámetro el DataAdapter
            OleDbCommandBuilder cb = new OleDbCommandBuilder(objda);

            // actualizamos la base con los cambios realizados

            objda.Update(objds, "Users");


        }

    }
}

