using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapturaPantalla
{
    public class Cola
    {
        private NodoCola primer = new NodoCola();
        private NodoCola final = new NodoCola();

        public Cola()
        {
            primer = null;
            final = null;
        }

        public bool AgregarNodo(Bitmap img)
        {
            try
            {
                NodoCola nuevonodo = new NodoCola();
                nuevonodo.Nombre = "Captura" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + ".jpg";
                nuevonodo.Imagen = img;
                if (primer == null)
                {
                    primer = nuevonodo;
                    primer.Siguiente = null;
                    //le damos a final un nuevo nodo, para que pueda aparcarse desde el final y mostrarlo de ambas formas
                    final = nuevonodo;
                }
                else
                {
                    final.Siguiente = nuevonodo;
                    nuevonodo.Siguiente = null;
                    final = nuevonodo;                   
                }
                return true;
            }
            catch (Exception e)
            {
                return false;               
            }           
        }
        public void MostrarImg(ref DataGridView cc)
        {
            NodoCola actual = new NodoCola();
            actual = primer;
            int aux = 0;
            while (actual != null)
            {                 
                DataGridViewImageColumn columna = new DataGridViewImageColumn();
                columna.Image = new PictureBox().Image =actual.Imagen;




                PictureBox c = new PictureBox();
                c.Height = 100;
                c.Width = 100;
                c.Image = actual.Imagen;
                c.SizeMode= PictureBoxSizeMode.StretchImage;
               
                columna.Name = actual.Nombre;              
            
                columna.Width = 150;               
                columna.ImageLayout = DataGridViewImageCellLayout.Zoom;


                cc.Columns.Add(columna);
                cc.Rows[0].Cells[aux].Value = new PictureBox().Image =actual.Imagen;
               


                aux++;                
                actual = actual.Siguiente;
            }
           
        }

        public void Eliminar(string nombreimagen)
        {
            NodoCola actual = new NodoCola();
            actual = primer;
            NodoCola anterio = new NodoCola();
            anterio = null;
            bool encontrado = false;
            while (actual != null && encontrado != true)
            {
                if (actual.Nombre == nombreimagen)
                {
                    encontrado = true;
                    if (actual == primer)
                    {
                        primer = primer.Siguiente;
                    }
                    else if (actual == final)
                    {
                        anterio.Siguiente = null;
                        final = anterio;
                    }
                    else
                    {
                        anterio.Siguiente = actual.Siguiente;
                    }
                }
                anterio = actual;
                //le damos a actual el valor de la cola o posicion siguiente, tanto que pierde de lugar el primero yel segundo chau
                actual = actual.Siguiente;
            }       
         
        }
        public void Guardartodo(string ruta)
        {
            string name = "";
            NodoCola actual = new NodoCola();
            actual = primer;
            int aux = 0;
            while (actual != null)
            {
                Bitmap b =  actual.Imagen;
                name = "" + ruta + "\\Captura" + actual.Nombre + ".jpg";
                b.Save(name, ImageFormat.Jpeg);
                aux++;
                actual = actual.Siguiente;
            }
            primer = null;
            final = null;
        }
    }
}
