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
            if (Validar()) { 
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

                if (VerificaBanco(usuario, email))
                {
                    if (editar)
                    {
                        string sql = $@"UPDATE LUSUARIO
                    SET LOGINUSER = '{usuario}', SENHA = '{senha}', EMAIL = '{email}', NOME = '{nomeCompleto}', CPF = '{cpf}', TELEFONE = '{telefone}', DATANASCIMENTO = '{dataNascimento:yyyy-MM-dd}',
                        CIDADE = '{cidade}', RUA = '{rua}', BAIRRO = '{bairro}', CASA = '{casa}', CEP = '{cep}'
                    WHERE ID = '{id}'";

                        conexaoBanco.Executar(sql);
                    }
                    else
                    {
                        string sql = $@"INSERT INTO LUSUARIO (CODPERMISSAO, LOGINUSER, SENHA, EMAIL, NOME, CPF, TELEFONE, DATANASCIMENTO, CIDADE, RUA, BAIRRO, CASA, CEP )
                    VALUES ('4', '{usuario}', '{senha}', '{email}', '{nomeCompleto}', '{cpf}', '{telefone}', '{dataNascimento:yyyy-MM-dd}', '{cidade}', '{rua}', '{bairro}', '{casa}', '{cep}')";

                        conexaoBanco.Executar(sql);
                    }

                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            if (editar)
            {
                string sql = $"SELECT * FROM LUSUARIO WHERE ID = '{id}'";

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

        private bool Validar()
        {
            if (String.IsNullOrWhiteSpace(txtUsuario.Text)) { MessageBox.Show("O campo do usuário não pode estar vazio", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            else if (String.IsNullOrWhiteSpace(txtSenha.Text)) { MessageBox.Show("O campo de senha não pode estar vazio", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            else if (String.IsNullOrWhiteSpace(txtNomeCompleto.Text)) { MessageBox.Show("O campo nome completo não pode estar vazio", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            else {; return true; }
        }

        private bool VerificaBanco(string p1, string p2)
        {
            string sqlid = $@"SELECT * FROM LUSUARIO WHERE ID = '{id}'";
            string sql = $@"SELECT * FROM LUSUARIO WHERE LOGINUSER = '{p1}'";
            string sqlemail = $@"SELECT * FROM LUSUARIO WHERE EMAIL = '{p2}'";

            string existingLoginUser = conexaoBanco.GetRowAsString(sql, "LOGINUSER");
            string existingEmail = conexaoBanco.GetRowAsString(sqlemail, "EMAIL");

            if (!String.IsNullOrWhiteSpace(existingLoginUser)) { if (conexaoBanco.GetRowAsString(sqlid, "LOGINUSER") == p1) { } else { MessageBox.Show("Já existe um usuário cadastrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; } }
            if (!String.IsNullOrWhiteSpace(existingEmail)) { if (conexaoBanco.GetRowAsString(sqlid, "EMAIL") == p2) { } else { MessageBox.Show("Já existe um email cadastrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; } }
            return true;
        }
    }
}
