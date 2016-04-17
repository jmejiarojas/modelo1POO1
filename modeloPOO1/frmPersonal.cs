using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modeloPOO1
{
    public partial class frmPersonal : Form
    {

        int n;   

        public frmPersonal()
        {
            InitializeComponent();
        }

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            cargarCombo();
            configurarLista();
            cargarFecha();
            
        }

        private void cargarFecha()
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();
        }

        private void configurarLista()
        {

            lvR.View = View.Details;
            lvR.GridLines = true;
            lvR.Columns.Add("Código", 40);
            lvR.Columns.Add("Usuario", 100);
            lvR.Columns.Add("Curso", 120);
            lvR.Columns.Add("Horas", 40);
            lvR.Columns.Add("Costo", 40);
            lvR.Columns.Add("Fecha", 40);
            lvR.Columns.Add("Descuento", 90);
            lvR.Columns.Add("Neto", 90);
        }

        private void cargarCombo()
        {
            cboCurso.Items.Add("Desarrollo de aplicaciones con Visual C# 2015");
            cboCurso.Items.Add("Desarrollo Web con ASP Net 2015");
            cboCurso.Items.Add("Desarrollo de aplicaciones moviles");
            cboCurso.SelectedIndex = 0;

        }

        private void cboCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            Corporativo obj = new Corporativo();
            obj.curso = cboCurso.Text;

            lblCosto.Text = obj.asignarCosto().ToString();
            lblHoras.Text = obj.asignarHoras().ToString();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n++;
            generarCodigo();
            Corporativo obj = new Corporativo();
            obj.curso = cboCurso.Text;
            obj.nombre = txtUsuario.Text;
            obj.fecha = Convert.ToDateTime(lblFecha.Text);
            obj.codigo = lblcodigo.Text;
            mostrarListado(obj);
        }

        private void mostrarListado(Corporativo obj)
        {   
            ListViewItem fila = new ListViewItem(obj.codigo);
            fila.SubItems.Add(obj.nombre);
            fila.SubItems.Add(obj.curso);
            fila.SubItems.Add(obj.asignarHoras().ToString());
            fila.SubItems.Add(obj.asignarCosto().ToString());
            fila.SubItems.Add(obj.fecha.ToString());
            fila.SubItems.Add(obj.descuento().ToString());
            fila.SubItems.Add(obj.calculaNeto().ToString());
            lvR.Items.Add(fila);
        }

        private void generarCodigo()
        {
            //M-0001
            lblcodigo.Text = "M-" + n.ToString("0000");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult r = MessageBox.Show("¿desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
