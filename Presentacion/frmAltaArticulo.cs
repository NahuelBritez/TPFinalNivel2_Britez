using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Datos;
using Entidades;
using System.IO;
using System.Configuration;

namespace Presentacion
{

    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
        }       
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marca = new MarcaNegocio();
            CategoriaNegocio categoria = new CategoriaNegocio();

            try
            {
                cboMarca.DataSource = marca.Listar();
                cboMarca.ValueMember = "IdMarca";
                cboMarca.DisplayMember = "Descripcion";                
                cboCategoria.DataSource = categoria.Listar();
                cboCategoria.ValueMember = "IdCategoria";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtImagen.Text = articulo.ImagenUrl;
                    CargarImagen(articulo.ImagenUrl);
                    cboMarca.SelectedValue = articulo.Marca.IdMarca;
                    cboCategoria.SelectedValue = articulo.Categoria.IdCategoria;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (articulo == null) 
                { 
                    articulo = new Articulo();
                }
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;

                if ((txtDescripcion.Text == "") || (txtDescripcion.Text == null))
                    articulo.Descripcion = "No se encontro descripcion de este articulo.";
                else
                    articulo.Descripcion = txtDescripcion.Text;

                articulo.ImagenUrl = txtImagen.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;

                string validacion = ValidarDatos(articulo);
                if (validacion != null)
                {
                    MessageBox.Show(validacion);
                    return;
                }

                if (articulo.Id != 0)
                {
                    negocio.Modificar(articulo);
                    MessageBox.Show("Articulo modificado correctamente");
                }
                else
                {
                    negocio.Agregar(articulo);
                    MessageBox.Show("Agregado correctamente");
                }
                if (archivo != null && !(txtImagen.Text.ToUpper().Contains("HTTP")))
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
                Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string ValidarDatos(Articulo articulo)
        {
            if ((articulo.Codigo == ""  || articulo.Codigo == "") || (articulo.Codigo == null || articulo.Codigo == null))
                return "El código y el nombre del artículo no pueden estar vacíos.";

            if (!(SoloNumeros(txtPrecio.Text)))
                return "El precio debe ser un número válido.";

            articulo.Precio = decimal.Parse(txtPrecio.Text);

            return null;
        }

        private bool SoloNumeros(string cadena)
        {

            foreach (char caracter in cadena)
            {
                if ((char.IsLetter(caracter)))
                return false;
            }

            return true;
        }

        public void CargarImagen(string imagen)
        {
            try
            {
                ptbActualizar.Load(imagen);
            }
            catch (Exception ex)
            {
                ptbActualizar.Load("https://dummyimage.com/600x300");

            }
        }

        private void txtImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtImagen.Text);
        }

        private void btnImagenL_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagen.Text = archivo.FileName;
                CargarImagen(archivo.FileName);
            }
        }
    }
}
