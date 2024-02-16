using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace app_gymManager
{
    public partial class frmMain : Form
    {
        private int id;
        private List<ToolStrip> toolStrips = new List<ToolStrip>();
        public frmMain(int id)
        {
            InitializeComponent();
            toolStrips.Add(toolStrip2);
            toolStrips.Add(toolStrip4);
            //toolStrips.Add(toolStrip3);
            this.id = id;
            infoUser();
        }

        private void infoUser()
        {
            string sql = $"SELECT LU.*, DP.DESCRICAO FROM LUSUARIO LU INNER JOIN DINAMICAPERMISSOES DP ON LU.CODPERMISSAO = DP.ID WHERE LU.ID = '{id}'";

            toolStripStatusLabel1.Text = conexaoBanco.GetRowAsString(sql, "NOME");
            txtPermissao.Text = "- " + conexaoBanco.GetRowAsString(sql, "DESCRICAO");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MostrarToolStrip(toolStrip2);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //MostrarToolStrip(toolStrip3);
        }
        private void MostrarToolStrip(ToolStrip toolStripAMostrar)
        {
            foreach (var toolStrip in toolStrips)
            {
                toolStrip.Visible = (toolStrip == toolStripAMostrar);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (permissaoBotoes.permissao(4)){
                frmVisaoAlunos frm = new frmVisaoAlunos();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.ControlBox = false;


                mainTela.Controls.Clear();
                mainTela.Controls.Add(frm);

                frm.Show();
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (permissaoBotoes.permissao(5))
            {
                frmVisaoAvaliacao frm = new frmVisaoAvaliacao();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.ControlBox = false;


                mainTela.Controls.Clear();
                mainTela.Controls.Add(frm);

                frm.Show();
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (permissaoBotoes.permissao(1))
            {
                frmVisaoUsuario frm = new frmVisaoUsuario();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.ControlBox = false;


                mainTela.Controls.Clear();
                mainTela.Controls.Add(frm);

                frm.Show();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MostrarToolStrip(toolStrip4);
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (permissaoBotoes.permissao(2))
            {
                frmVisaoPermissoes frm = new frmVisaoPermissoes();
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.ControlBox = false;


                mainTela.Controls.Clear();
                mainTela.Controls.Add(frm);

                frm.Show();
            }
        }
    }
}
