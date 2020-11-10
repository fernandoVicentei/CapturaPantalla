using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapturaPantalla
{
    class NodoCola
    {
        private NodoCola siguiente;
        private Bitmap imagen;
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Bitmap Imagen
        {
            get{ return imagen; }
            set{ imagen = value; }
        }

        public NodoCola Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
    }
}
