using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0.1;
            this.TransparencyKey = Color.Turquoise;
            this.Mensaje();
               
        }
        Cola cola = new Cola();        
        int cont = 0;
        Point posicionventana;
        bool mover = false;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Mensaje()
        {
            MessageBox.Show("INFROMACION\n PARA CAPTURAR PANTALLA =PRESIONAR TECLA 'C'\nPARA VER LAS CAPTURAS = PRESIONAR TECLA 'S'\n PARA SALIR PRESIONAR TECLA ESC o EXIT ","INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.C)) { CapturaPantalla(); }
            if ((e.KeyCode == Keys.S)) { enviar(); }
            if ((e.KeyCode == Keys.Escape)) { this.Close(); }
        }
        public void CapturaPantalla()
        {
            try
            {
                //Bitmap capturabit = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height, PixelFormat.Format32bppArgb);
                Bitmap capturabit = new Bitmap(this.Width,this.Height, PixelFormat.Format32bppArgb);
                Rectangle captura = Screen.AllScreens[0].Bounds;
                Graphics capturagrafico = Graphics.FromImage(capturabit);
                capturagrafico.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, captura.Size);
                Clipboard.SetImage(capturabit);                
                if(cola.AgregarNodo(capturabit))
                {
                    MessageBox.Show("REGION CAPTURADA");
                }
                else
                {
                    MessageBox.Show("REGION NO CAPTURADA");
                }
                cont += 1;      
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);             
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            posicionventana = new Point(Cursor.Position.X-Location.X,Cursor.Position.Y);
            mover = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Location = new Point(  Cursor.Position.X-posicionventana.X,Cursor.Position.Y-posicionventana.Y);

            }
        }
        public void enviar()
        {
            Ver v = new Ver();
            v.Cargando(cola);
            v.ShowDialog();
            //v.Cargar(im);
           
        }
     
    }
}
