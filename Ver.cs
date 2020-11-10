using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapturaPantalla
{
    public partial class Ver : Form
    {
        public Ver()
        {
            InitializeComponent();
        }
        public string nameImagen;
        Cola cCopy = new Cola();
        private void Ver_Load(object sender, EventArgs e)
        {
            
        }
        
        public void Cargando(Cola cc)
        {
            cCopy = cc;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            cCopy.MostrarImg(ref dataGridView1);
        }
        public void Cargar(Bitmap[] b)
        {

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] != null)
                {
                    DataGridViewImageColumn columna = new DataGridViewImageColumn();
                    columna.Image = new PictureBox().Image = b[i];

                    dataGridView1.Columns.Add(columna);
                    dataGridView1.Rows[0].Cells[i].Value = new PictureBox().Image = b[i];
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //   Image m = new  Image(this.dataGridView1.CurrentCell.Value.ToString());
            this.iconPictureBox1.Image =(Image) this.dataGridView1.CurrentCell.Value;
            nameImagen = this.dataGridView1.CurrentCell.OwningColumn.HeaderText.ToString();
            Bitmap b = new Bitmap((Image)this.dataGridView1.CurrentCell.Value);
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            cCopy.Eliminar(nameImagen);
            this.Cargando(cCopy);
            this.iconPictureBox1.Image = null;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Image;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Black;
            this.nameImagen = "";
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog carpeta = new FolderBrowserDialog();
            string ruta = "";
            if (carpeta.ShowDialog() == DialogResult.OK)
            {
                ruta = carpeta.SelectedPath;
                cCopy.Guardartodo(ruta);
                MessageBox.Show("Guardado correctamente ");
                this.Cargando(cCopy);
                this.iconPictureBox1.Image = null;
                this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Image;
                this.iconPictureBox1.IconColor = System.Drawing.Color.Black;
                this.nameImagen = "";
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog carpeta = new FolderBrowserDialog();
            string ruta = "";
            if (carpeta.ShowDialog() == DialogResult.OK)
            {
                Bitmap b = (Bitmap)this.iconPictureBox1.Image;
                ruta = carpeta.SelectedPath;
                b.Save("" + ruta + "\\" + nameImagen, ImageFormat.Jpeg);
                MessageBox.Show("Guardado correctamente " + nameImagen);
            }

        }
    }
}
