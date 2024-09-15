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
using Entidades;
using Datos;
using System.Diagnostics.Eventing.Reader;

namespace Presentacion
{
    public partial class frmArticulos : Form
    {
        private List<Articulo> listaArticulos;
        public frmArticulos()
        {
            InitializeComponent();
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Codigo");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoria");

            cboCriterio.Items.Add("Comienza con");
            cboCriterio.Items.Add("Termina con");
            cboCriterio.Items.Add("Contiene");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        public void Cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.Listar();
            dgvArticulos.DataSource = listaArticulos;
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["Categoria"].Visible = false;
            CargarImagen(listaArticulos[0].ImagenUrl);
        }

        public void CargarImagen(string imagen)
        {
            try
            {
                ptbArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                ptbArticulo.Load("https://dummyimage.com/600x300");

            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                CargarImagen(seleccionado.ImagenUrl);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (validarFiltro())
                    return;
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text.ToString();
                dgvArticulos.DataSource = negocio.Filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validarFiltro()
        {
            if((cboCampo.SelectedIndex == -1) && (cboCriterio.SelectedIndex == -1))
            {
                MessageBox.Show("Por favor, seleccione parametros para filtrar.");
                return true;
            }
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione un campo para filtrar.");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione un criterio para filtrar.");
                return true;
            }
            if (txtFiltro.Text == null || txtFiltro.Text == "")
            {
                MessageBox.Show("Escriba algo para filtrar.");
                return true;
            }

            return false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo frmAltaArticulo = new frmAltaArticulo();
            frmAltaArticulo.ShowDialog();
            Cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                        negocio.Eliminar(seleccionado.Id);
                        Cargar();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un articulo para eliminar");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            try
            {
                if(dgvArticulos.CurrentRow != null)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    frmAltaArticulo frmaltaarticulo = new frmAltaArticulo(seleccionado);
                    frmaltaarticulo.ShowDialog();
                    Cargar();
                }
                else
                {
                    MessageBox.Show("Seleccione un articulo de la grilla para modificar.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;

            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    frmDetalle frmaltaarticulo = new frmDetalle(seleccionado);
                    frmaltaarticulo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Seleccione un articulo para verlo en detalle.");
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
