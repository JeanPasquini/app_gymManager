using System;
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
    public partial class frmVisaoAvaliacaoIndividuais : Form
    {
        private int idAluno;

        public frmVisaoAvaliacaoIndividuais(int idAluno)
        {
            this.idAluno = idAluno;
            InitializeComponent();
            AtualizaGrid();
        }

        private void txtVerGrid_Click(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            int id = 0;
            frmCadastroAvaliacaoIndividual frm = new frmCadastroAvaliacaoIndividual(false, id, idAluno);
            frm.ShowDialog();
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            string sql = $"SELECT * FROM AVALIACAOALUNO WHERE IDALUNO = '{idAluno}'";
            dataGridView1.DataSource = conexaoBanco.GetDataTable(sql);


            string sqlinfo = $"SELECT * FROM LUSUARIO WHERE ID = '{idAluno}'";
            toolStripLabel1.Text = conexaoBanco.GetRowAsString(sqlinfo, "NOME");
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

            frmCadastroAvaliacaoIndividual frm = new frmCadastroAvaliacaoIndividual(true, id, idAluno);
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

                    string sql = $"DELETE FROM AVALIACAOALUNO WHERE ID = '{id}'";

                    conexaoBanco.Executar(sql);

                    MessageBox.Show("Avaliação de id: " + id + " foi removido!");
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma avaliação antes de prosseguir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            frmCadastroAvaliacaoIndividual frm = new frmCadastroAvaliacaoIndividual(true, id, idAluno);
            frm.ShowDialog();
            AtualizaGrid();
        }

        private void btnEnviarAvaliacao_Click(object sender, EventArgs e)
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
            string sql = $"SELECT * FROM LUSUARIO WHERE ID = '{idAluno}'";
            string sqlAval = $"SELECT * FROM AVALIACAOALUNO WHERE ID = '{id}'";

            string mensagemEmail = ObterPeriodoDoDia() + " " + conexaoBanco.GetRowAsString(sql, "NOME ") + "\n\n";
            mensagemEmail += "Descrição: " + conexaoBanco.GetRowAsString(sqlAval, "DESCRICAO") + "\n\n";
            mensagemEmail += "Perna Direita: " + conexaoBanco.GetRowAsString(sqlAval, "PERNADIREITA") + "\n";
            mensagemEmail += "Perna Esquerda: " + conexaoBanco.GetRowAsString(sqlAval, "PERNAESQUERDA") + "\n";
            mensagemEmail += "Braço Direito: " + conexaoBanco.GetRowAsString(sqlAval, "BRACODIREITO") + "\n";
            mensagemEmail += "Braço Direito: " + conexaoBanco.GetRowAsString(sqlAval, "BRACOESQUERDO") + "\n\n";
            mensagemEmail += "Att Admin";

            email.EnviarEmail(conexaoBanco.GetRowAsString(sql, "EMAIL"), "Avaliação - " + conexaoBanco.GetRowAsString(sqlAval, "DATAAVALIACAO"), mensagemEmail);

        }

        public string ObterPeriodoDoDia()
        {
            DateTime agora = DateTime.Now;

            TimeSpan manhaInicio = new TimeSpan(6, 0, 0);
            TimeSpan tardeInicio = new TimeSpan(12, 0, 0); 
            TimeSpan noiteInicio = new TimeSpan(18, 0, 0); 

            if (agora.TimeOfDay < tardeInicio)
            {
                return "Bom dia";
            }
            else if (agora.TimeOfDay < noiteInicio)
            {
                return "Boa tarde";
            }
            else
            {
                return "Boa noite";
            }
        }
    }
}
