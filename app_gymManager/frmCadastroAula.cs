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
    public partial class frmCadastroAula : Form
    {
        private bool editar;
        private int id;
        public frmCadastroAula(bool editar, int id)
        {
            this.editar = editar;
            this.id = id;
            InitializeComponent();

            if (editar)
            {
                btnVerParticipantes.Visible = true;
            }

            if (conexaoBanco.idPermissao == 4)
            {
                txtDescricaoAula.ReadOnly =  true;
                txtTituloAula.ReadOnly =  true;
                txtProfessores.ReadOnly = true;
                txtHoraAula.ReadOnly = true;
                

                txtStatus.Enabled = false;
                txtDataAula.Enabled =  false;

                btnCadastrar.Visible = false;
                btnCancelar.Visible = false;
                btnVerParticipantes.Visible = false;
                btnParticiparAula.Visible = true;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string titulo = txtTituloAula.Text;
            string professores = txtProfessores.Text;
            string descricao = txtDescricaoAula.Text;
            string estado = txtStatus.Text;
            string dataString = txtDataAula.Text + " " + txtHoraAula.Text;
            DateTime dataAula;

            if (!DateTime.TryParse(dataString, out dataAula))
            {
                Console.WriteLine("Data e hora inválidas.");
                return;
            }

            if (editar)
            {
                string sql = $@"UPDATE AULASDISPONIVEIS
                    SET TITULO = '{titulo}', PROFESSORES = '{professores}', DESCRICAO = '{descricao}', DATAHORARIO = '{dataAula}', ESTADO = '{estado}'
                 WHERE ID = '{id}'";

                conexaoBanco.Executar(sql);
            }
            else
            {
                string sql = $@"INSERT INTO AULASDISPONIVEIS (TITULO, PROFESSORES, DESCRICAO, DATAHORARIO, ESTADO)
                    VALUES ('{titulo}', '{professores}', '{descricao}', '{dataAula}', '{estado}')";

                conexaoBanco.Executar(sql);
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            if (editar)
            {
                

                string sql = $"SELECT * FROM AULASDISPONIVEIS WHERE ID = '{id}'";
         
                txtTituloAula.Text = conexaoBanco.GetRowAsString(sql, "TITULO");
                txtProfessores.Text = conexaoBanco.GetRowAsString(sql, "PROFESSORES");
                txtStatus.Text = conexaoBanco.GetRowAsString(sql, "ESTADO");
                DateTime dataHora;
                string dataHoraString = conexaoBanco.GetRowAsString(sql, "DATAHORARIO");
                if (DateTime.TryParse(dataHoraString, out dataHora))
                {
                }
                else
                {
                    Console.WriteLine("Não foi possível converter a string para DateTime.");
                }
                txtDataAula.Text = dataHora.ToShortDateString();
                txtHoraAula.Text = dataHora.ToShortTimeString();
                txtDescricaoAula.Text = conexaoBanco.GetRowAsString(sql, "DESCRICAO");

                if (conexaoBanco.GetRowAsString(sql, "QTDPESSOAS") == "")
                {
                    txtQtdeAlunos.Text = "0";
                }
                else
                {
                    txtQtdeAlunos.Text = conexaoBanco.GetRowAsString(sql, "QTDPESSOAS");
                }

                string sqlAula = $"SELECT COUNT(*) FROM AULAINFORMACAO WHERE IDAULA = '{id}' AND IDALUNO = '{conexaoBanco.idUser}'";
                int rowCount = Convert.ToInt32(conexaoBanco.GetRowAsString(sqlAula, "ID"));
                if (rowCount > 0)
                {
                    btnParticiparAula.Enabled = false;
                }
                else
                {
                    btnParticiparAula.Enabled = true;
                }
            }
            else
            {

            }
        }

        private void btnParticiparAula_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Tem certeza que deseja realizar esta ação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                if (int.TryParse(txtQtdeAlunos.Text, out int qtdeAlunos))
                {
                    qtdeAlunos++;
                    txtQtdeAlunos.Text = qtdeAlunos.ToString();


                    string sql = $@"INSERT INTO AULAINFORMACAO (IDALUNO, IDAULA)
                    VALUES ('{conexaoBanco.idUser}', '{id}')";

                    conexaoBanco.Executar(sql);

                    string sqlGetQtdPessoas = $"SELECT QTDPESSOAS FROM AULASDISPONIVEIS WHERE ID = '{id}'";
                    DataTable dataTable = conexaoBanco.GetDataTable(sqlGetQtdPessoas);

                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        string sqlUpdateQtdPessoas = $"UPDATE AULASDISPONIVEIS SET QTDPESSOAS = '{txtQtdeAlunos.Text}' WHERE ID = '{id}'";
                        conexaoBanco.Executar(sqlUpdateQtdPessoas);
                    }

                    MessageBox.Show("Você está participando desta aula", "Parabéns", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    btnParticiparAula.Enabled = false;
                }
                else
                {

                }
            }
            else
            {

            }
        }

        private void btnVerParticipantes_Click(object sender, EventArgs e)
        {
            frmVisaoAulaAlunos frm = new frmVisaoAulaAlunos(id);
            frm.ShowDialog();
        }
    }
}
