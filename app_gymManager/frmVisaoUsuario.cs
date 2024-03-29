﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_gymManager
{
    public partial class frmVisaoUsuario : Form
    {
        public frmVisaoUsuario()
        {
            InitializeComponent();
            toolStrip1.Dock = DockStyle.Top;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.BringToFront();
            AtualizaGrid();
        }

        private void txtVerGrid_Click(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            int id = 0;
            frmCadastroUsuario frm = new frmCadastroUsuario(false, id);
            frm.ShowDialog();
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            string sql = "SELECT * FROM LUSUARIO";
            dataGridView1.DataSource = conexaoBanco.GetDataTable(sql);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            }
            else
            {
            }

            frmCadastroUsuario frm = new frmCadastroUsuario(true, id);
            frm.ShowDialog();
            AtualizaGrid();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja realizar esta ação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {

                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    id = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                    string sql = $"DELETE FROM LUSUARIO WHERE ID = '{id}'";

                    conexaoBanco.Executar(sql);

                    MessageBox.Show("O usuário de id: " + id + " foi removido!");
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um usuário antes de prosseguir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            AtualizaGrid();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            }
            else
            {
            }

            frmCadastroUsuario frm = new frmCadastroUsuario(true, id);
            frm.ShowDialog();
            AtualizaGrid();
        }
    }
}
