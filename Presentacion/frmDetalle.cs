using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmDetalle : Form
    {
        private Articulo articulo = null;
        public frmDetalle()
        {
            InitializeComponent();
        }
        public frmDetalle(Articulo articulo)
        {
            InitializeComponent();
            this.articulo  = articulo;
            this.ActiveControl = btnCerrar;
            Text = articulo.Nombre;
        }

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = articulo.Codigo;
            txtNombre.Text = articulo.Nombre;
            txtDescripcion.Text = articulo.Descripcion;
            txtPrecio.Text = articulo.Precio.ToString();
            CargarImagen(articulo.ImagenUrl);
            txtMarca.Text = articulo.Marca.Descripcion;
            txtCategoria.Text = articulo.Categoria.Descripcion;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void CargarImagen(string imagen)
        {
            try
            {
                ptbDetalle.Load(imagen);
            }
            catch (Exception ex)
            {
                
                ptbDetalle.Load("https://dummyimage.com/600x300");

            }
        }
    }
}
