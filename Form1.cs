using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyControlInv
{
    public partial class Form1 : Form
    {
        Ruta ruta;
        Base base1;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            DateTime minutos = Convert.ToDateTime(txtCantidad.Text);

            base1 = new Base(nombre, minutos);
            ruta.agregar(base1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ruta = new Ruta();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            base1 = ruta.buscar(txtNombre.Text);
            if(base1==null)
            {
                txtReporte.Text = "No encontrado";
            }
            else
            {
                txtReporte.Text = base1.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ruta.eliminar(txtNombre.Text);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = ruta.reporte();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            DateTime minutos = Convert.ToDateTime(txtCantidad.Text);
            string nombreD = txtNombreD.Text;

            base1 = new Base(nombre, minutos);
            ruta.insertarDespuesDe(base1, nombreD);
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            DateTime minutos = Convert.ToDateTime(txtCantidad.Text);

            base1 = new Base(nombre, minutos);
            ruta.agregarEnInicio(base1);
        }

        private void btnReporteInverso_Click(object sender, EventArgs e)
        {
            txtReporte.Text = ruta.reporteInverso();
        }

        private void btnEliminarInicio_Click(object sender, EventArgs e)
        {
            ruta.eliminarInicio();
        }

        private void btnEliminarUlt_Click(object sender, EventArgs e)
        {
            ruta.eliminarUltimo();
        }
    }
}
