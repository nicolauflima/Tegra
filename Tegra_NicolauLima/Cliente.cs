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
    public partial class Cliente : Form {
        public Cliente() {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e) {
            MySqlConnection conn = new MySqlConnection("server=localhost; port=3306;User id=root;database=tegra;password=1234");

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



            table.Columns.Add("ID Carrinho", typeof(int));
            table.Columns.Add("NomeLivro", typeof(string));
            table.Columns.Add("Autor(es)", typeof(string));
            table.Columns.Add("Preço", typeof(double));
            table.Columns.Add("Quantidade", typeof(int));

            dataGridView2.DataSource = table;

            txtSubTotal.Text = 0.ToString("C2");
            txtTotal.Text = 0.ToString("C2");

        }


        int indexAdicionar = -1;
        DataGridViewRow selectedRowAdd;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            indexAdicionar = e.RowIndex;
            if (indexAdicionar > -1 && indexAdicionar < dataGridView1.Rows.Count - 1) {

                selectedRowAdd = dataGridView1.Rows[indexAdicionar];

                txtEstoque.Text = selectedRowAdd.Cells[1].Value.ToString();
            }
            else
                txtEstoque.Text = "Selecione...";

        }


        int indexRemover = -1;
        DataGridViewRow selectedRowRem;

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) {
            indexRemover = e.RowIndex;

            if (indexRemover > -1 && indexRemover < dataGridView2.Rows.Count - 1) {
                selectedRowRem = dataGridView2.Rows[indexRemover];

                txtCarrinho.Text = selectedRowRem.Cells[1].Value.ToString();
            }
            else
                txtCarrinho.Text = "Selecione...";

        }

        DataTable table = new DataTable();
        private void btnAdicionar_Click(object sender, EventArgs e) {
            if (indexAdicionar > -1 && indexAdicionar < dataGridView1.Rows.Count - 1) {

                bool flagg = false;

                foreach (DataRow row in table.Rows) {
                    if (row[0].ToString() == selectedRowAdd.Cells[0].Value.ToString()) {
                        if (Convert.ToInt32(row[4]) < Convert.ToInt32(selectedRowAdd.Cells[4].Value)) {
                            row[4] = Convert.ToInt32(row[4]) + 1;
                            flagg = true;
                        }
                        else {
                            MessageBox.Show("Número de Livros insuficientes no estoque!");
                            flagg = true;
                        }
                    }
                }

                if (flagg == false)
                    table.Rows.Add(selectedRowAdd.Cells[0].Value, selectedRowAdd.Cells[1].Value.ToString(), selectedRowAdd.Cells[2].Value.ToString(), selectedRowAdd.Cells[3].Value, 1);



                dataGridView2.DataSource = table;

                if (table.Rows.Count != 0) {
                    double subtotal = 0.0;
                    foreach (DataRow row in table.Rows) {
                        subtotal += Convert.ToDouble(row[3]) * Convert.ToInt32(row[4]);
                    }
                    txtSubTotal.Text = subtotal.ToString("C2");
                    if(txtCupom.Text == "TrabalheNaTegra") {
                        MessageBox.Show("Não Implementado!");
                    }
                    else {
                        txtTotal.Text = subtotal.ToString("C2");
                    }
                }
            }
            else {
                MessageBox.Show("Selecione um livro!");
            }
        }

        private void btnRemover_Click(object sender, EventArgs e) {
            if (indexRemover > -1 && indexRemover < dataGridView2.Rows.Count - 1) {

                bool flagg = false;

                foreach (DataRow row in table.Rows) {
                    if (row[0].ToString() == selectedRowRem.Cells[0].Value.ToString()) {
                        if (Convert.ToInt32(row[4]) == 1) {

                            flagg = true;
                        }
                        else {
                            row[4] = Convert.ToInt32(row[4]) - 1;

                        }
                    }
                }

                if (flagg) {
                    table.Rows[indexRemover].Delete();
                    indexRemover = -1;
                    txtCarrinho.Text = "";
                }
                dataGridView2.DataSource = table;

                if (table.Rows.Count != 0) {
                    double subtotal = 0.0;
                    foreach (DataRow row in table.Rows) {
                        subtotal += Convert.ToDouble(row[3]) * Convert.ToInt32(row[4]);
                    }
                    txtSubTotal.Text = subtotal.ToString("C2");
                    if (txtCupom.Text == "TrabalheNaTegra") {
                        MessageBox.Show("Não Implementado!");
                    }
                    else {

                        txtTotal.Text = subtotal.ToString("C2");

                    }

                }else {
                    txtSubTotal.Text = 0.ToString("C2");
                    txtTotal.Text = 0.ToString("C2");
                }

            }
            else {
                MessageBox.Show("Selecione um livro!");
            }
        }
    }
}
