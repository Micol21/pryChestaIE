namespace pryChestaIE
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cargarProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pantallaABMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eLCLUBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarProveedoresToolStripMenuItem,
            this.mostrarProveedorToolStripMenuItem,
            this.toolStripMenuItem1,
            this.pantallaABMToolStripMenuItem,
            this.eLCLUBToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(815, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cargarProveedoresToolStripMenuItem
            // 
            this.cargarProveedoresToolStripMenuItem.Name = "cargarProveedoresToolStripMenuItem";
            this.cargarProveedoresToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.cargarProveedoresToolStripMenuItem.Text = "Cargar Proveedores";
            this.cargarProveedoresToolStripMenuItem.Click += new System.EventHandler(this.cargarProveedoresToolStripMenuItem_Click);
            // 
            // mostrarProveedorToolStripMenuItem
            // 
            this.mostrarProveedorToolStripMenuItem.Name = "mostrarProveedorToolStripMenuItem";
            this.mostrarProveedorToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.mostrarProveedorToolStripMenuItem.Text = "Mostrar Proveedor";
            this.mostrarProveedorToolStripMenuItem.Click += new System.EventHandler(this.mostrarProveedorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(14, 24);
            // 
            // pantallaABMToolStripMenuItem
            // 
            this.pantallaABMToolStripMenuItem.Name = "pantallaABMToolStripMenuItem";
            this.pantallaABMToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.pantallaABMToolStripMenuItem.Text = "Mostrar Lista";
            this.pantallaABMToolStripMenuItem.Click += new System.EventHandler(this.pantallaABMToolStripMenuItem_Click);
            // 
            // eLCLUBToolStripMenuItem
            // 
            this.eLCLUBToolStripMenuItem.Name = "eLCLUBToolStripMenuItem";
            this.eLCLUBToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.eLCLUBToolStripMenuItem.Text = "EL CLUB";
            this.eLCLUBToolStripMenuItem.Click += new System.EventHandler(this.eLCLUBToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::pryChestaIE.Properties.Resources._857042ce4db2b08b32ce2b60394bfdbbd5ba1ff26ca82ff84651507ff9b5c8c67fc51b12feb50b61_rw_1200;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(815, 467);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cargarProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pantallaABMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eLCLUBToolStripMenuItem;
    }
}

