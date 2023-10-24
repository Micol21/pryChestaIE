﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryChestaIE
{
    public partial class FrmConectar : Form
    {
        ClsAccesoDatos objBaseDeDatos;
        clsLogs objLogs;
        public FrmConectar()
        {
            InitializeComponent();
        }
        
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            


        }

        public void FrmConectar_Load(object sender, EventArgs e)
        {
            objBaseDeDatos = new ClsAccesoDatos();
            objBaseDeDatos.AbrirBD();
            
            objBaseDeDatos.TraerDatos(dgvGrilla);
            
            
            //objBaseDatos = new clsAccesoDatos();
            //objBaseDatos.ConectarBD();
            //lblEstadoConexion.Text = objBaseDatos.estadoConexion;
            //lblDatos.Text = objBaseDatos.datosTabla;
            //objBaseDatos.TraerDatos(dgvGrilla);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           objBaseDeDatos.BuscarPorID(int.Parse(txtBuscar.Text));
            
            //objBaseDatos.BuscarPorID(int.Parse(txtBuscar.Text));
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            objBaseDeDatos.nuevoregistro(txtBuscar.Text,txtPassword.Text);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
