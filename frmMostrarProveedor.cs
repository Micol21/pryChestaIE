using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pryChestaIE
{
    public partial class frmMostrarProveedor : Form
    {
        public frmMostrarProveedor()
        {
            InitializeComponent();
            PopulateTreeView();
            
        }
        private void PopulateTreeView()
        {
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(@"../..");//se crea una nueva instacia de la clase
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs,
            TreeNode nodeToAddTo)
        {
            TreeNode aNode;//Se declara una variable `aNode` de tipo `TreeNode`, que se utilizará para representar un nodo del árbol de directorios
            DirectoryInfo[] subSubDirs;// Se declara un arreglo de objetos,  que se utilizará para almacenar los subdirectorios del directorio actual representado por subDir
            foreach (DirectoryInfo subDir in subDirs)//Se inicia un bucle foreach para recorrer cada objeto DirectoryInfode la colección subDirs
            {
                aNode = new TreeNode(subDir.Name, 0, 0);//Se crea un nuevo nodo TreeNodellamado aNode
                aNode.Tag = subDir; //Se asigna el objeto subDir la propiedad Tagdel nodo aNode
                aNode.ImageKey = "folder";//Se establece la clave de imagen del nodo aNodecomo "carpeta"
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)//Se verifica si hay subdirectorios dentro del directorio actual.
                {
                    GetDirectories(subSubDirs, aNode);//Se llama de forma recursiva a la función GetDirectories, pasando como argumentos la lista de subdirectorios  y el nodo
                    //Esto permite construir la estructura de directorios de manera recursiva, agregando nodos para los subdirectorios dentro del subdirectorio actual.
                }
                nodeToAddTo.Nodes.Add(aNode);//Finalmente, el nodo aNodese agrega como hijo al nodo nodeToAddTo,que es el nodo al que se agregarán todos los subdirectorios. 
                //Esto construye el árbol de directorios,donde nodeToAddTorepresenta el nodo del directorio padre y aNoderepresenta uno de sus subdirectorios.
            }
        }
        private void frmMostrarProveedor_Load(object sender, EventArgs e)
        {

        }
        void treeView1_NodeMouseClick(object sender,
             TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"),
             new ListViewItem.ListViewSubItem(item,
                dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"),
             new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal form1 = new FrmPrincipal();
            form1.Show();
        }
    }
}
