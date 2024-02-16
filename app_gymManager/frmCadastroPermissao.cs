using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_gymManager
{
    public partial class frmCadastroPermissao : Form
    {
        private int id;
        public frmCadastroPermissao(int id)
        {
            this.id = id;
            InitializeComponent();
            AtualizaGrid();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSelecionaPermissao_Click(object sender, EventArgs e)
        {
            frmSelecionaBotao frm = new frmSelecionaBotao();
            frm.ShowDialog();
            txtID.Text = frm.id.ToString();
            txtPermissao.Text = frm.botao.ToString();
        }

        private void AtualizaGrid()
        {
            string sql = $"SELECT BP.ID, DB.ID AS IDBOTAO, DB.DESCRICAO FROM BOTOESPERMISSOES BP INNER JOIN DINAMICABOTOES DB ON BP.IDBOTAO = DB.ID WHERE BP.IDUSUARIO = '{id}' ORDER BY DB.ID";
            dataGridView1.DataSource = conexaoBanco.GetDataTable(sql);
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

                    string sql = $"DELETE FROM BOTOESPERMISSOES WHERE ID = '{id}'";

                    conexaoBanco.Executar(sql);

                    MessageBox.Show("O botão de id: " + id + " foi removido!");
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um botão antes de prosseguir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            AtualizaGrid();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string idbotao = txtID.Text;
            string usuario = id.ToString();
            string sql = $@"INSERT INTO BOTOESPERMISSOES (IDBOTAO, IDUSUARIO)
                    VALUES ('{idbotao}', '{usuario}')";

            conexaoBanco.Executar(sql);
            MessageBox.Show("Foi permitido o botão de id: " + idbotao);
            AtualizaGrid();
        }
    }
}
