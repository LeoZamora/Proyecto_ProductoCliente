using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacturacionCN;


namespace FacturacionCP
{
    public partial class form1 : Form
    {
        private bool Editar = false;
        ProductoCN objetoCN = new ProductoCN();
        private string Productoid = null;

        public form1()
        {
            InitializeComponent();
        }
        
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProducto();

        }
        private void MostrarProducto()
        {
            ProductoCN objeto = new ProductoCN();
            DGVProductos.DataSource = objeto.MostrarProducto();
           

        }
        private void limpiardatos()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox1.Focus();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Editar==false)
            {
                try
                {
                    objetoCN.InsertarProducto(int.Parse(textBox1.Text), textBox2.Text,double.Parse(textBox3.Text), int.Parse(textBox4.Text),int.Parse(textBox5.Text),int.Parse(textBox6.Text));

                    MessageBox.Show("se inserto correctamente");
                    MostrarProducto();
                    limpiardatos();

                }
                catch (Exception ex) 
                {
                    MessageBox.Show("No se puede insertar los datos por" + ex);

                }

            }
                else
                if (Editar==true)
                {
                    try 
                    {
                        objetoCN.EditarProducto (textBox1.Text, textBox2.Text, double.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text),int.Parse(Productoid));
                        MostrarProducto ();
                        limpiardatos ();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se logro Editar los datos por" + ex);

                    }
                }
            }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            var newform = new frmClientes();
            newform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DGVProductos.SelectedRows.Count > 0)
            {
                Editar = true;
              textBox1.Text = DGVProductos.CurrentRow.Cells["CodigoDeProducto"].Value.ToString();
              textBox2.Text = DGVProductos.CurrentRow.Cells["DescripcionDeProducto"].Value.ToString();
              textBox3.Text = DGVProductos.CurrentRow.Cells["PrecioProducto"].Value.ToString();
              textBox4.Text = DGVProductos.CurrentRow.Cells["Cantidad"].Value.ToString();
              textBox5.Text = DGVProductos.CurrentRow.Cells["CantidadMinima"].Value.ToString();
              textBox6.Text = DGVProductos.CurrentRow.Cells["CantidadMaxima"].Value.ToString();
              Productoid = DGVProductos.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DGVProductos.SelectedRows.Count>0)
            {
                Productoid = DGVProductos.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarProducto(int.Parse(Productoid));
                MessageBox.Show("Registro eliminado");
                MostrarProducto();
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
