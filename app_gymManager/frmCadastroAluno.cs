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
    public partial class frmCadastroAluno : Form
    {
        private bool editar;
        private int id;
        public frmCadastroAluno(bool editar, int id)
        {
            this.editar = editar;
            this.id = id;
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            string email = txtEmail.Text + txtEmail2.Text; // Apenas para correção, considerando que txtEmail2.Text contenha o domínio de email
            string nomeCompleto = txtNomeCompleto.Text;
            string cpf = txtCPF.Text;
            string telefone = txtNumeroTelefone.Text;
            DateTime dataNascimento = DateTime.Parse(txtDataNascimento.Text);
            string cidade = txtCidade.Text;
            string rua = txtRua.Text;
            string bairro = txtBairro.Text;
            string casa = txtNumeroCasa.Text;
            string cep = txtCEP.Text; // Alterado para string para preservar os zeros à esquerda, se houver

            if (editar)
            {
                string sql = $@"UPDATE ALUNO
                    SET LOGINUSER = '{usuario}', SENHA = '{senha}', EMAIL = '{email}', NOME = '{nomeCompleto}', CPF = '{cpf}', TELEFONE = '{telefone}', DATANASCIMENTO = '{dataNascimento:yyyy-MM-dd}' , 
                        CIDADE = '{cidade}', RUA = '{rua}' , BAIRRO = '{bairro}', CASA = '{casa}' , CEP = '{cep}'
                 WHERE ID = '{id}'";

                conexaoBanco.Executar(sql);
            }
            else
            {
                string sql = $@"INSERT INTO ALUNO ( LOGINUSER,
                                        SENHA,
                                        EMAIL ,
                                        NOME ,
                                        CPF ,
                                        TELEFONE ,
                                        DATANASCIMENTO ,
                                        CIDADE ,
                                        RUA ,
                                        BAIRRO ,
                                        CASA ,
                                        CEP)
                    VALUES ('{usuario}', '{senha}', '{email}', '{nomeCompleto}', '{cpf}', '{telefone}', '{dataNascimento:yyyy-MM-dd}' , '{cidade}', '{rua}' , '{bairro}', '{casa}' , '{cep}')";

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
                string sql = $"SELECT * FROM ALUNO WHERE ID = '{id}'";

                txtUsuario.Text = conexaoBanco.GetRowAsString(sql, "LOGINUSER");
                txtSenha.Text = conexaoBanco.GetRowAsString(sql, "SENHA");
                txtNomeCompleto.Text = conexaoBanco.GetRowAsString(sql, "NOME");
                txtCPF.Text             = conexaoBanco.GetRowAsString(sql, "CPF");
                txtNumeroTelefone.Text = conexaoBanco.GetRowAsString(sql, "TELEFONE").ToString();
                txtDataNascimento.Text = conexaoBanco.GetRowAsString(sql, "DATANASCIMENTO");
                txtCidade.Text          = conexaoBanco.GetRowAsString(sql, "CIDADE");
                txtRua.Text             = conexaoBanco.GetRowAsString(sql, "RUA");
                txtBairro.Text = conexaoBanco.GetRowAsString(sql, "BAIRRO");
                txtNumeroCasa.Text      = conexaoBanco.GetRowAsString(sql, "CASA");
                txtCEP.Text = conexaoBanco.GetRowAsString(sql, "CEP").ToString(); 

                string email = conexaoBanco.GetRowAsString(sql, "EMAIL");
                int posicao = email.IndexOf("@");
                if (posicao >= 0)
                {
                    string before = email.Substring(0, posicao);
                    string after = email.Substring(posicao + 1);
                    txtEmail.Text = before;
                    txtEmail2.Text =  "@" + after;
                }
            }
        }
    }
}
