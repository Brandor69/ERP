using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Modulo_Produccion
{
    public partial class Form1 : Form
    {
        private SqlConnection conexion;
        private SqlCommand cmd;
        //private SqlDataReader read;
        public static String dat = "server = localhost; database = restaurante; Uid = root; pwd = 1234;";
        public static String nombre = "";

        public Form1()
        {
            InitializeComponent();
        }

        private SqlConnection ObtenerConexion() {

            conexion = new SqlConnection();
            conexion.ConnectionString = dat;
            conexion.Open();
            return conexion;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("Receta1","Q. "+50,"20 Min","yo");
            dataGridView1.Rows.Add("Receta2", "Q. "+55, "25 Min", "tu");
            dataGridView1.Rows.Add("Receta3", "Q. " + 60, "30 Min", "ella");
        }

        private void mostrarReceta() {

            DataSet ds = new DataSet();
            cmd = new SqlCommand("Select nombre, precio, tiempo_preparacion, autor from Receta",ObtenerConexion());
            SqlDataAdapter recetas = new SqlDataAdapter(cmd);
            recetas.Fill(ds);
            dataGridView1.DataSource=ds.Tables[1];
            

        }











        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ClickBoton(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                var row = dataGridView1.CurrentRow;

                tabControl1.SelectedTab = tabModRec;
                var nombre = tabModRec.Controls["txtNombre"];
                var precio = tabModRec.Controls["txtPrecio"];
                var tiempo = tabModRec.Controls["txtTPrep"];
                var autor = tabModRec.Controls["txtAutor"];

                nombre.Text = row.Cells[0].Value.ToString();
                precio.Text = row.Cells[1].Value.ToString();
                tiempo.Text = row.Cells[2].Value.ToString();
                autor.Text = row.Cells[3].Value.ToString();


            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
      

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Receta Modificada Exitosamente");

            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtTPrep.Text = "";
            txtAutor.Text = "";

            tabControl1.SelectedTab = tabVerRec;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtTPrep.Text = "";
            txtAutor.Text = "";

            tabControl1.SelectedTab = tabVerRec;
        }
    }
}
