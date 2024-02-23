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
    public partial class frmVisaoEmail : Form
    {
        private int id;
        private List<string> emails { get; set; }
        public frmVisaoEmail(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void btnSelecionaPermissao_Click(object sender, EventArgs e)
        {
            frmSelecionaEmail frm = new frmSelecionaEmail();
            frm.ShowDialog();
            if (frm.emails != null && frm.emails.Count > 0)
            {
                string allEmails = string.Join(", ", frm.emails);
                txtEmail.Text = allEmails;
                emails = frm.emails;
            }
            else
            {
                txtEmail.Text = "";
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja realizar esta ação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    string sql = $"SELECT * FROM AVALIACAOALUNO AV INNER JOIN LUSUARIO LU ON AV.IDALUNO = LU.ID WHERE AV.ID = '{id}'";

                    string mensagemEmail = ObterPeriodoDoDia() + " " + conexaoBanco.GetRowAsString(sql, "NOME ") + "\n\n";
                    mensagemEmail += "Descrição: " + conexaoBanco.GetRowAsString(sql, "DESCRICAO") + "\n\n";
                    mensagemEmail += "Perna Direita: " + conexaoBanco.GetRowAsString(sql, "PERNADIREITA") + "\n";
                    mensagemEmail += "Perna Esquerda: " + conexaoBanco.GetRowAsString(sql, "PERNAESQUERDA") + "\n";
                    mensagemEmail += "Braço Direito: " + conexaoBanco.GetRowAsString(sql, "BRACODIREITO") + "\n";
                    mensagemEmail += "Braço Direito: " + conexaoBanco.GetRowAsString(sql, "BRACOESQUERDO") + "\n\n";
                    mensagemEmail += "Att Admin";

                    foreach (string emails in emails)
                    {
                        email.EnviarEmail(emails, "Avaliação - " + conexaoBanco.GetRowAsString(sql, "DATAAVALIACAO"), mensagemEmail);
                    }
                    
                }
            }
        }

        private bool Validar()
        {
            if (String.IsNullOrWhiteSpace(txtEmail.Text)) { MessageBox.Show("O campo do Email não pode estar vazio", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            else {; return true; }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
