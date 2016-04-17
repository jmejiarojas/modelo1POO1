using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace certamenBelleza
{
    public partial class frmCertamen : Form
    {
        int n;
        ArrayList candidatas = new ArrayList();

        public frmCertamen()
        {
            InitializeComponent();
        }

        private void frmCertamen_Load(object sender, EventArgs e)
        {
            cargarCombo();
            configurarLista();
        }

        private void configurarLista()
        {

            lvR.View = View.Details;
            lvR.GridLines = true;
            lvR.Columns.Add("Código", 80);
            lvR.Columns.Add("Nombre", 140);
            lvR.Columns.Add("Edad", 60);
            lvR.Columns.Add("Talla", 80);
            lvR.Columns.Add("Medidas", 100);
            lvR.Columns.Add("Distrito", 100);
        }

        private void cargarCombo()
        {
            cboDistrito.Items.Add("Los Olivos");
            cboDistrito.Items.Add("Independencia");
            cboDistrito.Items.Add("Puente Piedra");
            cboDistrito.Items.Add("Comas");
            cboDistrito.SelectedIndex = 0;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            n++;
            txtCodigo.Text = "CAN" + n.ToString("000");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Candidata obj = new Candidata();
            obj.codigo = txtCodigo.Text;
            obj.nombre = txtNombre.Text;
            obj.edad = int.Parse(txtEdad.Text);
            obj.medidas = txtMedidas.Text;
            obj.distrito = cboDistrito.Text;
            obj.talla = double.Parse(txtTalla.Text);

            //Evaluamos si se repite el nombre
            foreach (Candidata c in candidatas)
            {
                if (obj.nombre == c.nombre)
                {
                    MessageBox.Show("Candidata ya registrada");
                    return;
                }
            }

            candidatas.Add(obj);
            listado();
            limpiarCajas();
        }

        private void limpiarCajas()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtTalla.Clear();
            txtMedidas.Clear();
            txtEdad.Clear();
            cboDistrito.SelectedIndex = 0;
            txtNombre.Focus();

        }

        private void listado()
        {
            lvR.Items.Clear();
            foreach (Candidata c in candidatas)
            {
                ListViewItem fila = new ListViewItem(c.codigo);
                fila.SubItems.Add(c.nombre);
                fila.SubItems.Add(c.edad.ToString());
                fila.SubItems.Add(c.talla.ToString());
                fila.SubItems.Add(c.medidas);
                fila.SubItems.Add(c.distrito);
                lvR.Items.Add(fila);
            }


        }

        private void lvR_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem valor = lvR.GetItemAt(e.X, e.Y);
            txtCodigo.Text = valor.Text;
            txtNombre.Text = valor.SubItems[1].Text;
            txtEdad.Text = valor.SubItems[2].Text;
            txtTalla.Text = valor.SubItems[3].Text;
            txtMedidas.Text = valor.SubItems[4].Text;
            cboDistrito.Text = valor.SubItems[5].Text;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            foreach (Candidata c in candidatas)
            {
                if(txtNombre.Text == c.nombre)
                {
                    MessageBox.Show("Nombre ya existe");
                    return;
                }

                if (txtCodigo.Text == c.codigo)
                {
                    c.nombre = txtNombre.Text;
                    c.edad = int.Parse(txtEdad.Text);
                    c.talla = double.Parse(txtTalla.Text);
                    c.medidas = txtMedidas.Text;
                    c.distrito = cboDistrito.Text;
                    break;        
                }
            }

            
            listado();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            DialogResult r = MessageBox.Show("¿Desea salir ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
