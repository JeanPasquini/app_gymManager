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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            string sqlUsuario = $"SELECT * FROM LUSUARIO WHERE LOGINUSER = '{usuario}'";
            string sqlSenha = $"SELECT * FROM LUSUARIO WHERE LOGINUSER = '{usuario}' AND SENHA = '{senha}'";


            string usuarioBanco = conexaoBanco.GetRowAsString(sqlUsuario, "LOGINUSER");
            string senhaBanco = conexaoBanco.GetRowAsString(sqlSenha, "SENHA");
            

            // Verificar se a senha do banco pode ser convertida para int
            if (usuario == usuarioBanco && senha != senhaBanco)
            {
                
                MessageBox.Show("Usuário ou senha incorreto!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            else if (usuario != usuarioBanco || senha != senhaBanco)
            {
                MessageBox.Show("Erro ao verificar a senha do usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                this.Hide();
                int id = int.Parse(conexaoBanco.GetRowAsString(sqlSenha, "ID"));
                conexaoBanco.idUser = id;
                frmMain mainForm = new frmMain(id);
                mainForm.ShowDialog();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string usuario = txtUsuario.Text;
                string senha = txtSenha.Text;

                string sqlUsuario = $"SELECT * FROM LUSUARIO WHERE LOGINUSER = '{usuario}'";
                string sqlSenha = $"SELECT * FROM LUSUARIO WHERE LOGINUSER = '{usuario}' AND SENHA = '{senha}'";


                string usuarioBanco = conexaoBanco.GetRowAsString(sqlUsuario, "LOGINUSER");
                string senhaBanco = conexaoBanco.GetRowAsString(sqlSenha, "SENHA");


                // Verificar se a senha do banco pode ser convertida para int
                if (usuario == usuarioBanco && senha != senhaBanco)
                {

                    MessageBox.Show("Usuário ou senha incorreto!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (usuario != usuarioBanco || senha != senhaBanco)
                {
                    MessageBox.Show("Erro ao verificar a senha do usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.Hide();
                    int id = int.Parse(conexaoBanco.GetRowAsString(sqlSenha, "ID"));
                    conexaoBanco.idUser = id;
                    frmMain mainForm = new frmMain(id);
                    mainForm.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
