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
    public partial class frmCadastroUsuario : Form
    {
        private bool editar;
        private int id;
        public frmCadastroUsuario(bool editar, int id)
        {
            this.editar = editar;
            this.id = id;
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;   
            string senha = txtSenha.Text;
            string email = txtEmail.Text + txtEmail2.Text; 
            string nomeCompleto = txtNomeCompleto.Text;
            string codePermissao = txtID.Text;

            if (editar)
            {
                string sql = $@"UPDATE LUSUARIO 
                SET SENHA = '{senha}', EMAIL = '{email}', NOME = '{nomeCompleto}', LOGINUSER = '{usuario}', CODPERMISSAO = '{codePermissao}'
                 WHERE ID = '{id}'";

                conexaoBanco.Executar(sql);
            }
            else
            {
                string sql = $@"INSERT INTO LUSUARIO (LOGINUSER, SENHA, EMAIL, NOME, CODPERMISSAO)
                    VALUES ('{usuario}', '{senha}', '{email}', '{nomeCompleto}' , '{codePermissao}')";

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
                string sql = $"SELECT LU.*, DP.DESCRICAO FROM LUSUARIO LU INNER JOIN DINAMICAPERMISSOES DP ON LU.CODPERMISSAO = DP.ID WHERE LU.ID = '{id}'";

                txtUsuario.Text = conexaoBanco.GetRowAsString(sql, "LOGINUSER");
                txtSenha.Text = conexaoBanco.GetRowAsString(sql, "SENHA");
                txtNomeCompleto.Text = conexaoBanco.GetRowAsString(sql, "NOME");
                txtID.Text = conexaoBanco.GetRowAsString(sql, "CODPERMISSAO");
                txtPermissao.Text = conexaoBanco.GetRowAsString(sql, "DESCRICAO");

                string email = conexaoBanco.GetRowAsString(sql, "EMAIL");
                int posicao = email.IndexOf("@");
                if (posicao >= 0)
                {
                    string before = email.Substring(0, posicao);
                    string after = email.Substring(posicao + 1);
                    txtEmail.Text = before;
                    txtEmail2.Text = "@" + after;
                }
            }
        }

        private void btnSelecionaPermissao_Click(object sender, EventArgs e)
        {
            frmSelecionaPermissao frm = new frmSelecionaPermissao();
            frm.ShowDialog();
            txtID.Text = frm.id.ToString();
            txtPermissao.Text = frm.permissao.ToString();
        }
    }
}
