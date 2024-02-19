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
    public partial class frmCadastroAvaliacaoIndividual : Form
    {
        private bool editar;
        private int id;
        private int idAluno;
        public frmCadastroAvaliacaoIndividual(bool editar, int id, int idAluno)
        {
            this.idAluno = idAluno;
            this.editar = editar;
            this.id = id;
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            DateTime dataAvaliacao = DateTime.Parse(txtDataAvaliacao.Text);
        
            double bracoDireito = !String.IsNullOrWhiteSpace(txtBracoDireito.Text) ? double.Parse(txtBracoDireito.Text) : 0;
            double bracoEsquerdo = !String.IsNullOrWhiteSpace(txtBracoEsquerdo.Text) ? double.Parse(txtBracoEsquerdo.Text) : 0;
            double pernaDireita = !String.IsNullOrWhiteSpace(txtPernaDireita.Text) ? double.Parse(txtPernaDireita.Text) : 0;
            double pernaEsquerda = !String.IsNullOrWhiteSpace(txtPernaEsquerda.Text) ? double.Parse(txtPernaEsquerda.Text) : 0;

            if (editar)
            {
                string sql = $@"UPDATE AVALIACAOALUNO
                    SET IDALUNO = '{idAluno}', DATAAVALIACAO = '{dataAvaliacao: yyyy - MM - dd}', DESCRICAO = '{descricao}' ,BRACODIREITO = '{bracoDireito.ToString(CultureInfo.InvariantCulture)}', BRACOESQUERDO = '{bracoEsquerdo.ToString(CultureInfo.InvariantCulture)}', PERNADIREITA = '{pernaDireita.ToString(CultureInfo.InvariantCulture)}', PERNAESQUERDA = '{pernaEsquerda.ToString(CultureInfo.InvariantCulture)}'
                 WHERE ID = '{id}'";

                conexaoBanco.Executar(sql);
            }
            else
            {
                string sql = $@"INSERT INTO AVALIACAOALUNO (IDALUNO, DATAAVALIACAO, DESCRICAO, BRACODIREITO, BRACOESQUERDO, PERNADIREITA, PERNAESQUERDA)
                    VALUES ('{idAluno}', '{dataAvaliacao: yyyy - MM - dd}' , '{descricao}' ,{bracoDireito.ToString(CultureInfo.InvariantCulture)}, {bracoEsquerdo.ToString(CultureInfo.InvariantCulture)}, {pernaDireita.ToString(CultureInfo.InvariantCulture)}, {pernaEsquerda.ToString(CultureInfo.InvariantCulture)})";

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
                

                string sql = $"SELECT * FROM LUSUARIO WHERE ID = '{idAluno}'";
               

                txtNomeCompleto.Text = conexaoBanco.GetRowAsString(sql, "NOME");
                txtCPF.Text             = conexaoBanco.GetRowAsString(sql, "CPF");
                txtDataNascimento.Text = conexaoBanco.GetRowAsString(sql, "DATANASCIMENTO");

                string sqlAval = $"SELECT * FROM AVALIACAOALUNO WHERE ID = '{id}'";
                txtPernaDireita.Text = conexaoBanco.GetRowAsString(sqlAval, "PERNADIREITA");
                txtPernaEsquerda.Text = conexaoBanco.GetRowAsString(sqlAval, "PERNAESQUERDA");
                txtBracoDireito.Text = conexaoBanco.GetRowAsString(sqlAval, "BRACODIREITO");
                txtBracoEsquerdo.Text = conexaoBanco.GetRowAsString(sqlAval, "BRACOESQUERDO");
                txtDataAvaliacao.Text = conexaoBanco.GetRowAsString(sqlAval, "DATAAVALIACAO");
                txtDescricao.Text = conexaoBanco.GetRowAsString(sqlAval, "DESCRICAO");
            }
            else
            {
                string sql = $"SELECT * FROM LUSUARIO WHERE ID = '{idAluno}'";

                txtNomeCompleto.Text = conexaoBanco.GetRowAsString(sql, "NOME");
                txtCPF.Text = conexaoBanco.GetRowAsString(sql, "CPF");
                txtDataNascimento.Text = conexaoBanco.GetRowAsString(sql, "DATANASCIMENTO");
            }
        }
    }
}
