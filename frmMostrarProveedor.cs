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
using System.Runtime.ConstrainedExecution;

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
            if (info.Exists)//: Esta línea de código verifica si el directorio representado por la variable info existe en el sistema de archivos.
            {
                rootNode = new TreeNode(info.Name);//Se crea un nuevo nodo de árbol (TreeNode) con el nombre del directorio representado por info y se almacena en la variable rootNode
                //Este nodo actuará como el nodo raíz del árbol de directorios.
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);//Se llama a una función llamada GetDirectories y se le pasa un arreglo de objetos DirectoryInfo que representa los subdirectorios del directorio actual 
                treeView1.Nodes.Add(rootNode);//Finalmente, el nodo rootNode se agrega como un nodo raíz al control TreeView llamado treeView1
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
            TreeNode newSelected = e.Node;// Se declara una variable `newSelected` de tipo `TreeNode`//e.Node` se refiere al nodo del `TreeView` que ha sido seleccionado por el usuario o que ha generado algún evento relacionado con el `TreeView`.// se asigna ese nodo seleccionado a la variable `newSelected`, lo que facilita su uso posterior.
            listView1.Items.Clear();// Esta línea de código se encarga de borrar todos los elementos existentes en el control 
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;// El código utiliza una conversión explícita (DirectoryInfo) para obtener el valor de Tag como un objeto DirectoryInfo y lo almacena en la variable nodeDirInfo
            ListViewItem.ListViewSubItem[] subItems;//Se declara un arreglo de objetos ListViewSubItem, que se utilizará más adelante para contener subelementos de un elemento de lista en el control ListView
            ListViewItem item = null;//Se declara una variable item de tipo ListViewItem y se inicializa en null. Esta variable se utilizará para crear y agregar elementos de lista (filas) en el control ListView más adelante en el código.

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())//Se utiliza un bucle foreach para recorrer todos los directorios contenidos en el directorio representado por nodeDirInfo. nodeDirInfo.GetDirectories() obtiene una lista de subdirectorios dentro del directorio.
            {
                item = new ListViewItem(dir.Name, 0);//Dentro del bucle, se crea un nuevo elemento de lista (ListViewItem) llamado item
                subItems = new ListViewItem.ListViewSubItem[]//Se crea un arreglo de objetos ListViewSubItem llamado subItems
                    {new ListViewItem.ListViewSubItem(item, "Directory"),
             new ListViewItem.ListViewSubItem(item,
                dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())//Se utiliza un bucle foreach para recorrer todos los archivos contenidos en el directorio representado por nodeDirInfo. nodeDirInfo.GetFiles()
            {
                item = new ListViewItem(file.Name, 1);//Dentro del bucle, se crea un nuevo elemento de lista (ListViewItem) llamado item. El primer argumento (file.Name) establece el texto principal del elemento de lista, que será el nombre del archivo (file.Name).
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"),
             new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);//Se agregan los subelementos de lista (subItems) al elemento principal item utilizando el método AddRange. Esto asocia los subelementos con el elemento principal y los muestra en el mismo renglón en el ListView.
                listView1.Items.Add(item);//: Finalmente, el elemento item se agrega al control ListView (listView1). Esto muestra la información sobre el archivo en el ListView, con el nombre del archivo en la primera columna, "File" en la segunda columna y la fecha de último acceso en la tercera columna (si corresponde).
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); se utiliza para ajustar automáticamente el ancho de las columnas en un control ListView (listView1) de acuerdo con el tamaño de las cabeceras de columna.

        //listView1: Es el nombre del control ListView al que se aplica este ajuste de ancho de columna.

        //AutoResizeColumns: Es un método que permite ajustar automáticamente el ancho de las columnas en función de su contenido o cabeceras de columna.

        //ColumnHeaderAutoResizeStyle.HeaderSize: Este es el argumento que se pasa al método AutoResizeColumns. Indica que el ancho de las columnas debe ajustarse para que coincida con el tamaño de las cabeceras de columna. Esto significa que cada columna tendrá un ancho igual al ancho de su cabecera, lo que suele ser útil cuando deseas que las columnas se ajusten al texto de la cabecera.
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmPrincipal form1 = new FrmPrincipal();
            form1.Show();
        }
    }
}
