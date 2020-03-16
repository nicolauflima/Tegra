using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tegra_NicolauLima {
    public partial class Menu : Form {
        public Menu() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {
            Estoque objEstoque = new Estoque();
            objEstoque.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) {
            Cliente objCliente = new Cliente();
            objCliente.ShowDialog();
        }
    }
}
