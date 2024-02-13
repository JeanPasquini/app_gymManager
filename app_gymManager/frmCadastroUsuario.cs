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
            int senha = int.Parse(txtSenha.Text);
            string email = txtEmail.Text + txtEmail2.Text; 
            string nomeCompleto = txtNomeCompleto.Text;

            if (editar)
            {
                string sql = $@"UPDATE LUSUARIO 
                SET SENHA = '{senha}', EMAIL = '{email}', NOME = '{nomeCompleto}', USUARIO = '{usuario}'
                 WHERE ID = '{id}'";

                conexaoBanco.Executar(sql);
            }
            else
            {
                string sql = $@"INSERT INTO LUSUARIO (USUARIO, SENHA, EMAIL, NOME)
                    VALUES ('{usuario}', '{senha}', '{email}', '{nomeCompleto}')";

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
                string sql = $"SELECT * FROM LUSUARIO WHERE ID = '{id}'";

                txtUsuario.Text = conexaoBanco.GetRowAsString(sql, "USUARIO");
                txtSenha.Text = conexaoBanco.GetRowAsString(sql, "SENHA");
                txtNomeCompleto.Text = conexaoBanco.GetRowAsString(sql, "NOME");

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
    }
}
