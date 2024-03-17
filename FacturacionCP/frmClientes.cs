using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacturacionCN;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FacturacionCP
{
    public partial class frmClientes : Form
    {
        private bool Editar = false;
        ClienteCN objetoCN = new ClienteCN();
        private string Clienteid = null;

        public frmClientes()
        {
            InitializeComponent();
        }
     
        private void MostrarCliente()
        {
            ClienteCN objeto = new ClienteCN();
            DGVClientes.DataSource = objeto.MostrarCliente();


        }
        private void limpiardatos()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox1.Focus();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            MostrarCliente();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarCliente(textBox1.Text, textBox2.Text, textBox3.Text,textBox4.Text);

                    MessageBox.Show("se inserto correctamente");
                    MostrarCliente();
                    limpiardatos();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede insertar los datos por" + ex);

                }
                

            }
                else
                if (Editar == true)
                {
                    try
                    {
                        objetoCN.EditarCliente(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, int.Parse(Clienteid));
                        limpiardatos();
                        MostrarCliente() ;
                        Editar = false;

                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se logro Editar los datos por" + ex);

                    }
                }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DGVClientes.SelectedRows.Count > 0)
            {
                Editar = true;
                textBox1.Text = DGVClientes.CurrentRow.Cells["CodigoDeCliente"].Value.ToString();
                textBox2.Text = DGVClientes.CurrentRow.Cells["NombredeCliente"].Value.ToString();
                textBox3.Text = DGVClientes.CurrentRow.Cells["ApellidosdeCliente"].Value.ToString();
                textBox4.Text = DGVClientes.CurrentRow.Cells["DirecciondeCliente"].Value.ToString();
                Clienteid = DGVClientes.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DGVClientes.SelectedRows.Count > 0)
            {
                Clienteid = DGVClientes.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarCliente(int.Parse(Clienteid));
                MessageBox.Show("Registro eliminado");
                   MostrarCliente();
            }
            else
            {
                MessageBox.Show("seleccione una fila");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
