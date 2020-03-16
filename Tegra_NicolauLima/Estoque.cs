using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tegra_NicolauLima {
    public partial class Estoque : Form {
        public Estoque() {
            InitializeComponent();
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            if (radioButton1.Checked == true) {
                txtNome.Enabled = true;
                txtAutor.Enabled = true;
                txtPreco.Enabled = true;
                txtQuantidade.Enabled = true;
                txtID.Enabled = false;
                btnAcao.Text = "Cadastrar Livro";
                btnAcao.Enabled = true;

                txtNome.Text = string.Empty;
                txtAutor.Text = string.Empty;
                txtPreco.Text = string.Empty;
                txtQuantidade.Text = string.Empty;
                txtID.Text = string.Empty;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            if (radioButton2.Checked == true) {
                txtNome.Enabled = false;
                txtAutor.Enabled = false;
                txtPreco.Enabled = false;
                txtQuantidade.Enabled = false;
                txtID.Enabled = true;
                btnAcao.Text = "Remover Livro";
                btnAcao.Enabled = true;

                txtNome.Text = string.Empty;
                txtAutor.Text = string.Empty;
                txtPreco.Text = string.Empty;
                txtQuantidade.Text = string.Empty;
                txtID.Text = string.Empty;

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) {
            if (radioButton3.Checked == true) {
                txtNome.Enabled = false;
                txtAutor.Enabled = false;
                txtPreco.Enabled = true;
                txtQuantidade.Enabled = false;
                txtID.Enabled = true;
                btnAcao.Text = "Alterar Preço";
                btnAcao.Enabled = true;

                txtNome.Text = string.Empty;
                txtAutor.Text = string.Empty;
                txtPreco.Text = string.Empty;
                txtQuantidade.Text = string.Empty;
                txtID.Text = string.Empty;

            }
        }

        MySqlConnection conn = new MySqlConnection("server=localhost; port=3306;User id=root;database=tegra;password=1234");

        private void button1_Click(object sender, EventArgs e) {
            try {

                try {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                }
                catch {
                    MessageBox.Show("Verifique a sua conexão com a internet!\n\nSe você estiver conectado, contate seu administrador de sistemas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM LIVRO", conn);

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;

                conn.Close();

            }
            catch (Exception erro) {

                conn.Close();

                MessageBox.Show("Erro encontrado:\n\n" + erro);

            }
        }

        private void Estoque_Load(object sender, EventArgs e) {
            button1_Click(null, EventArgs.Empty);
        }

        private void btnAcao_Click(object sender, EventArgs e) {

            try {
                conn.Open();
            }
            catch {
                MessageBox.Show("Verifique a sua conexão com a internet!\n\nSe você estiver conectado, contate seu administrador de sistemas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (conn.State == ConnectionState.Open) {
                try {



                    //colocar a seleção dos 3 tipos de de cadastro

                    if (radioButton1.Checked) {

                        MySqlCommand cmd = new MySqlCommand("INSERT INTO LIVRO VALUES (NULL, @nome, @autor, @preco, @quantidade)", conn);




                        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@autor", txtAutor.Text);
                        cmd.Parameters.AddWithValue("@preco", txtPreco.Text.Replace(',', '.'));
                        cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text);

                        cmd.ExecuteNonQuery();



                        button1_Click(null, EventArgs.Empty);
                    }
                    else if (radioButton2.Checked) {

                        MySqlCommand cmd = new MySqlCommand("DELETE FROM LIVRO WHERE IDLIVRO = @idlivro", conn);

                        cmd.Parameters.AddWithValue("@idlivro", txtID.Text);

                        cmd.ExecuteNonQuery();


                        button1_Click(null, EventArgs.Empty);
                    }
                    else if (radioButton3.Checked) {


                        MySqlCommand cmd = new MySqlCommand("UPDATE LIVRO SET PRECO = @preco WHERE IDLIVRO = @idlivro", conn);

                        cmd.Parameters.AddWithValue("@preco", txtPreco.Text.Replace(',', '.'));
                        cmd.Parameters.AddWithValue("@idlivro", txtID.Text);

                        cmd.ExecuteNonQuery();


                        button1_Click(null, EventArgs.Empty);
                    }

                }
                catch (Exception erro) {
                    conn.Close();

                    MessageBox.Show("Erro encontrado:\n\n" + erro);
                }
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e) {
            if (radioButton2.Checked || radioButton3.Checked) {

                try {
                    int Indexx = -1;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                        if (row.Cells[0].Value.ToString().Equals(txtID.Text)) {
                            Indexx = row.Index;

                            txtNome.Text = row.Cells[1].Value.ToString();
                            txtAutor.Text = row.Cells[2].Value.ToString();
                            txtPreco.Text = row.Cells[3].Value.ToString();
                            txtQuantidade.Text = row.Cells[4].Value.ToString();

                            break;
                        }
                }
                catch {

                    txtNome.Text = string.Empty;
                    txtAutor.Text = string.Empty;
                    txtPreco.Text = string.Empty;
                    txtQuantidade.Text = string.Empty;
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {


            int index = e.RowIndex;
            if (index > -1 && index < dataGridView1.Rows.Count - 1) {

                DataGridViewRow selectedRow = dataGridView1.Rows[index];

                txtNome.Text = selectedRow.Cells[1].Value.ToString();
                txtAutor.Text = selectedRow.Cells[2].Value.ToString();
                txtPreco.Text = selectedRow.Cells[3].Value.ToString();
                txtQuantidade.Text = selectedRow.Cells[4].Value.ToString();
                txtID.Text = selectedRow.Cells[0].Value.ToString();
            }
            else {

                txtNome.Text = string.Empty;
                txtAutor.Text = string.Empty;
                txtPreco.Text = string.Empty;
                txtQuantidade.Text = string.Empty;
                txtID.Text = "";
            }




        }


    }
}
