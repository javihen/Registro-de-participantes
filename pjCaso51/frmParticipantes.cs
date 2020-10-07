using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjCaso51
{
    public partial class frmParticipantes : Form
    {
        int num;
        int cJefe, cOperario, cAdministrativo, cPracticante;

        public frmParticipantes()
        {
            InitializeComponent();
            tHora.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta seguro de salir?",
                                              "Llamadas",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes) this.Close();
        }

        private void frmParticipantes_Load(object sender, EventArgs e)
        {
            num++;
            lblFecha.Text = DateTime.Now.Date.ToString("d");
            lblNumero.Text = num.ToString("D4");
        }

        private void tHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando los datos 
            DateTime fecha, hora;
            string participante, cargo;
            int numero;
            participante = txtParticipante.Text;
            numero = int.Parse(lblNumero.Text);
            fecha = DateTime.Parse(lblFecha.Text);
            hora = DateTime.Parse(lblHora.Text);
            cargo = cboCargo.Text;

            //Contabilizar la cantidad segun los cargos
            switch (cargo) {
                case "Jefe": cJefe++; break;
                case "Operario": cOperario++; break;
                case "Administrativo": cAdministrativo++; break;
                case "Practicante": cPracticante++; break;
            }

            //Imprimiendo el registro 
            ListViewItem fila = new ListViewItem(numero.ToString());
            fila.SubItems.Add(participante);
            fila.SubItems.Add(cargo);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(hora.ToString("hh:mm:ss"));
            lvParticipantes.Items.Add(fila);

            //Imprimiendo las estadisticas
            lvEstadisticas.Items.Clear();
            string[] elementosFila = new string[2];
            ListViewItem row;

            //Añadimos la primera fila al lvEstadisticas 
            elementosFila[0] = "Jefe";
            elementosFila[1] = cJefe.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //Añadimos la segunda fila al lvEstadisticas 
            elementosFila[0] = "Operario";
            elementosFila[1] = cOperario.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //Añadimos la tercera fila al lvEstadisticas 
            elementosFila[0] = "Administrativo";
            elementosFila[1] = cAdministrativo.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //Añadimos la cuarta fila al lvEstadisticas 
            elementosFila[0] = "Practicante";
            elementosFila[1] = cPracticante.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //Mostrando el nuevo numero de registro
            num++;
            lblNumero.Text = num.ToString("D4");

            //Limpiando los controles
            txtParticipante.Clear();
            cboCargo.SelectedIndex = -1;
            txtParticipante.Focus();
        }
    }
}
